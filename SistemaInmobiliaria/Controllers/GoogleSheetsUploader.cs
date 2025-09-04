using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Controllers
{
    internal class GoogleSheetsUploader
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "MiAppCSharp";

        // Service Account JSON - Necesitas crear uno en Google Cloud Console
        private static readonly string serviceAccountJson = @"{
         ""type"": ""service_account"",
  ""project_id"": ""lottin"",
  ""private_key_id"": ""c97c7a10b5111321c9d4a1c82f136ff05004faef"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDlrOo36kLbhkpd\nmqp3P6Vx697qwcRtTwsoxy56cUTVYUXnQ+Ojhya/I+RcgzmdYMLuj6XWaJ9ZQxhs\nbRPKX9XNC08TAI8GEjnRvmlRDWGNgESvFNw0zsTX17ZKY+l7YCDRDZUVeODS2lEb\nbE824n7W04uoxX0qs+HF6O1mtdQCQDCqHI3opZIPQjJkSPsTjLMJdI8u4vwLWw+z\nmuVBcvxERsYa8S4/mk0RaMzEuO4KibKO9m9HhpgsHoFBEbYIKt79A5fnyaskEYVK\nachTHqUWhH/Jlmt7wvR0+DJqrzVzwoTER3vumabooR9Af/8liSoPE3prRpCllPJa\nlxBAUSHTAgMBAAECggEAacg0zhEKvwIAcVFBjw/U2v3om1YoarH7sUnf2cweiGq3\nX/cwOsqOKX3V+VgFKrt8vJSTrIdeUSXqc1HfyhdOqRQ61MUumny9faGF7ytLEXmQ\n6NSiQX40QjdbgbK3wDe7lZ18Wznjzql3rro5V82E3tvrGI3xAsB7zYPlB6faYDgh\n1W2VeFQuaaPzF7djYtNMiBXtdjX/kac7OzrLI8+WQ4OXDFQL3vkl6RsimPPyhInh\nrqzvJAvlh7XM+c1k15cr1GUzwMeXEDVfeH1CsH9T3uOtvlDh6Q3nUpXX9pBdqouM\nmQ7gmOPMJ5yZ1il6SsXdbboJbNizOFjY4t2wXZi+IQKBgQD6qBpuJq8CYS8ajxul\nVzQtF1fYc0uDTiL+SiRb5j/I0LnS/SfEv2Mgy0dGkSQH9O2tH8s41mh54f52CSx8\n4NLCwBWsGsOfoyE6snZM6MV3nuA6jZzCpTNU+FHAz6ej1fLSb0KlowrgUkxY6JxN\nfF48RtYJnKupPzWQeTO9gD90cwKBgQDqkk/a2U9+J7eMsG2mqUl6lPsRjna03GOX\nE1p8dbF5/zYZAbaZY756dJt+l9dpobx8O9tRO+tOlJh2Umz1f97dNr35y4LUbKTL\ncNNS/wcFhxTMK3hE0OFV/k8XbRE6F2vJg7U9bZ53LK3SxBkaxSZl7yf6Tgm0pNcR\nEwCRBVelIQKBgQC+6l0/Ou2f1V/oTcoT1GjkU1xQe/ivKUuT/erVqHk6vmhbIQEy\nZUfeiZZfVFtqSA7kB0xlnUF0XELRqskc0K0XMvEO5k/L/pdnuthKWh1VsEg/sO8O\nfn+rn3u9bSzVqDbMO3w65wV4uJZ4PawXhLvOE3IhXhiNz5w/z2EuXEl4qwKBgQCl\nXu8TT97+BowdkIhNVc2qsPtr/i7sBO/lI0zIr8SmSGlgKdgMvcgc1raFAhFotBCI\n2T4eQAr9RD9UM3oDfdmlxSEbyQD8N3fawTkKqybNG9Vqtz677TLfiEFEN61MchSY\nZdVRcEWmqQYGsB8uw0z10iwyB/BJvWit7eKZWtXWYQKBgDIDQihk/86ETZljm0uJ\nqsYk845SnIIdGYHBn1d/msEJa/5QbZFhT7ACARL4cJOjqodh6/uKouV7KxB0mB7d\nv8wSfrE/fjrK4IqZnGYKYp2V44Kd3YGzbbQVIM04THvWHd8SZvWZXK8ZBfwYzN/U\nqr9xFEGh3MjhSs1fjXbe863o\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""lottin@lottin.iam.gserviceaccount.com"",
  ""client_id"": ""100769256879875896260"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/lottin%40lottin.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
        }";

        public static void SubirData(System.Data.DataTable dt, string spreadsheetId, string sheetName)
        {
            try
            {
                // Crear credencial desde Service Account JSON
                GoogleCredential credential;
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(serviceAccountJson)))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                }

                // Inicializar servicio de Sheets
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Preparar datos
                var values = new List<IList<object>>();

                // Cabeceras (nombres de las columnas del DataTable)
                var headers = new List<object>();
                foreach (DataColumn col in dt.Columns)
                    headers.Add(col.ColumnName);
                values.Add(headers);

                // Filas (datos del DataTable)
                foreach (DataRow row in dt.Rows)
                {
                    var fila = new List<object>();
                    foreach (var item in row.ItemArray)
                        fila.Add(item?.ToString() ?? "");
                    values.Add(fila);
                }

                // Limpiar el rango primero (opcional)
                try
                {
                    var clearRequest = service.Spreadsheets.Values.Clear(
                        new ClearValuesRequest(),
                        spreadsheetId,
                        $"'{sheetName}'!A1:ZZ1000");
                    clearRequest.Execute();
                }
                catch (Exception clearEx)
                {
                    Console.WriteLine($"Advertencia: No se pudo limpiar el rango: {clearEx.Message}");
                }

                // Preparar actualización
                var body = new ValueRange() { Values = values };
                var request = service.Spreadsheets.Values.Update(
                    body,
                    spreadsheetId,
                    $"'{sheetName}'!A1");
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

                // Ejecutar
                var response = request.Execute();
                Console.WriteLine($"Datos actualizados exitosamente. Celdas actualizadas: {response.UpdatedCells}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al subir datos a Google Sheets: {ex.Message}", ex);
            }
        }
    }
}

