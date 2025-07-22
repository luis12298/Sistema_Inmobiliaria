using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    public class LicenciaInfo
    {
        public bool estado { get; set; }
        public DateTime ultimaVerificacion { get; set; }


        public bool VerificarLicencia(string cliente)
        {
            string pathJson = @"C:\Data\licencia.json";

            // Crear directorio si no existe
            string directorio = Path.GetDirectoryName(pathJson);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            LicenciaInfo licencia;

            // Si no existe el archivo, crear uno por defecto
            if (!File.Exists(pathJson))
            {
                licencia = new LicenciaInfo { estado = false, ultimaVerificacion = DateTime.MinValue };
                try
                {
                    File.WriteAllText(pathJson, JsonConvert.SerializeObject(licencia, Formatting.Indented));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear archivo de licencia: {ex.Message}", "Error - Licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Cargar archivo JSON local
            try
            {
                licencia = JsonConvert.DeserializeObject<LicenciaInfo>(File.ReadAllText(pathJson))
                    ?? new LicenciaInfo { estado = false, ultimaVerificacion = DateTime.MinValue };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer archivo de licencia: {ex.Message}", "Error - Licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // VERIFICACIÓN PRINCIPAL: Basada en archivo local
            if (!licencia.estado)
            {
                MessageBox.Show("¡Licencia vencida! Contacte al proveedor.", "Licencia Vencida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Intentar actualizar desde Firebase en segundo plano
                ActualizarDesdeFirebase(pathJson, licencia, cliente);
                return false;
            }

            // Verificar si necesita renovación (opcional: cada 30 días)
            if (licencia.ultimaVerificacion != DateTime.MinValue)
            {
                TimeSpan tiempoSinVerificar = DateTime.Today - licencia.ultimaVerificacion;
                if (tiempoSinVerificar.Days > 30)
                {
                    MessageBox.Show("Se recomienda verificar licencia online.", "Aviso - Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Intentar actualizar desde Firebase
                    ActualizarDesdeFirebase(pathJson, licencia, cliente);
                }
            }

            //MessageBox.Show("Licencia activa", "Licencia Activa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Intentar actualizar desde Firebase en segundo plano (sin afectar el resultado)
            ActualizarDesdeFirebase(pathJson, licencia, cliente);

            return true;
        }

        private void ActualizarDesdeFirebase(string pathJson, LicenciaInfo licenciaLocal, string cliente)
        {
            try
            {
                // Configuración Firebase
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "AIzaSyASah_0fZEcxkBVC_d1NHQyhTyFlqevlGs",
                    BasePath = "https://usuarios-94a70-default-rtdb.firebaseio.com"
                };

                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                if (client == null) return; // Salir silenciosamente si no hay conexión

                // Obtener estado desde Firebase
                FirebaseResponse response = client.Get($"Licencia/{cliente}");

                if (response == null || string.IsNullOrEmpty(response.Body) || response.Body == "null")
                {
                    return; // Salir silenciosamente si no hay datos
                }

                var datosFirebase = JsonConvert.DeserializeObject<EstadoLicencia>(response.Body);
                if (datosFirebase == null) return;

                // Actualizar archivo local solo si hay cambios
                bool hubocambios = false;

                if (licenciaLocal.estado != datosFirebase.estado)
                {
                    licenciaLocal.estado = datosFirebase.estado;
                    hubocambios = true;
                }

                if (hubocambios || DateTime.Today != licenciaLocal.ultimaVerificacion)
                {
                    licenciaLocal.ultimaVerificacion = DateTime.Today;
                    hubocambios = true;
                }

                if (hubocambios)
                {
                    File.WriteAllText(pathJson, JsonConvert.SerializeObject(licenciaLocal, Formatting.Indented));
                }
            }
            catch
            {
                // Silencioso: Si Firebase falla, no afecta la operación principal
                // El sistema sigue funcionando con el archivo local
            }
        }
        // Clase auxiliar


        public class EstadoLicencia
        {
            public bool estado { get; set; }
        }
    }
}