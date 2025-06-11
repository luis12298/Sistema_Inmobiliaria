using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class TextBoxIndent
{
    private const int EM_SETMARGINS = 0x00D3;
    private const int EC_LEFTMARGIN = 0x0001;
    private const int EC_RIGHTMARGIN = 0x0002;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    public static void AplicarIndentacionVisual(TextBox textBox, int indentPixels)
    {
        if (textBox == null || textBox.IsDisposed)
            return;

        // Asegurar que el control tiene un handle creado
        if (!textBox.IsHandleCreated)
        {
            textBox.HandleCreated += (sender, e) => AplicarIndentacionVisual(textBox, indentPixels);
            return;
        }

        // Aplicar el margen izquierdo directamente en píxeles
        // Usamos MAKELPARAM para crear el valor de margenes (loword = left, hiword = right)
        IntPtr margins = (IntPtr)((indentPixels & 0xFFFF) | (0 << 16));
        SendMessage(textBox.Handle, EM_SETMARGINS, (IntPtr)EC_LEFTMARGIN, margins);
    }
}