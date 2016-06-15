using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace Gma.UserActivityMonitorDemo
{
    class countMe
    {
        int _counter;

        public countMe()
        {
            _counter = 0;
        }
        public int TheCount
        {
            get
            {
                this._counter++;
                return this._counter;
            }
            
        }
        
    }

    
    public static class ScreenShotThing
    {
        private static string _dateTimeString()
        {
            DateTime now = DateTime.Now;
            return now.ToString("yyyy-MM-dd-HH-mm-ss.fff");
        }
        public static void CaptureShot(int x, int y, string name)
        {
            int xCord = x;
            int yCord = y;
            
            //string fileName = _dateTimeString();
            Rectangle rect = new Rectangle((x - 250), (y - 250), 500, 500);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            //Pen p = new Pen(Color.Red, 7);
            
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            //g.DrawRectangle(p, (rect.Left - 250), (rect.Top - 250), 100, 100);
            bmp.Save("C:\\temp\\" + name + ".png", ImageFormat.Png);
        }
    }
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
            //Application.Run(new TestFormStatic());
            Application.Run(new TestFormComponent());
            //Application.Run(new TestFormComponent());
        }
    }
}