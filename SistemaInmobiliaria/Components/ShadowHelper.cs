using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Components
{
    internal static class ShadowHelper
    {
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x85;
        private const int DWMWA_NCRENDERING_POLICY = 2;
        private const int DWMNCRP_ENABLED = 2;
        private const int GCL_STYLE = -26;

        // Estructura para márgenes
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        // Importaciones de DLL
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// Aplica efecto de sombra al formulario
        /// </summary>
        public static void ApplyShadow(this Form form)
        {
            if (IsCompositionEnabled())
            {
                ApplyAeroShadow(form);
            }
            else
            {
                ApplyLegacyShadow(form);
            }
        }

        private static bool IsCompositionEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return enabled == 1;
            }
            return false;
        }

        private static void ApplyAeroShadow(Form form)
        {
            try
            {
                var v = DWMNCRP_ENABLED;
                DwmSetWindowAttribute(form.Handle, DWMWA_NCRENDERING_POLICY, ref v, sizeof(int));

                MARGINS margins = new MARGINS()
                {
                    bottomHeight = 1,
                    leftWidth = 1,
                    rightWidth = 1,
                    topHeight = 1
                };
                DwmExtendFrameIntoClientArea(form.Handle, ref margins);
            }
            catch
            {
                ApplyLegacyShadow(form);
            }
        }

        private static void ApplyLegacyShadow(Form form)
        {
            int classStyle = GetClassLong(form.Handle, GCL_STYLE);
            if ((classStyle & CS_DROPSHADOW) == 0)
            {
                SetClassLong(form.Handle, GCL_STYLE, classStyle | CS_DROPSHADOW);
            }
        }
    }
}
