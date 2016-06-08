using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Gma.UserActivityMonitorDemo
{
    public static class WindowStuff
    {
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
    }
    static class Program {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestFormStatic());
            Application.Run(new TestFormComponent());
            //Application.Run(new TestFormComponent());
        }
    }
}