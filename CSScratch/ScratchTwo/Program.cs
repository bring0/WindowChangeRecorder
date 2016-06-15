using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace ScratchTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            init();
            Console.ReadKey();
        }

        static void init()
        {
            Thread userActivityThread = new Thread(Run_UserActivityThread);
            userActivityThread.Name = "UserActivityThread";
            userActivityThread.IsBackground = true;     //Required to ensure thread is automatically stopped when application's main thread closes
            userActivityThread.Start();
        }
        private static void Run_UserActivityThread()
        {
            HookManager.KeyDown += HookManager_KeyDown;

            while (true)
            {
                Application.DoEvents(); //required to get any events raised
                Thread.Sleep(1);        //Sleeping too long, e.g. 10ms will result in touch events arriving several seconds delayed due to event overload
            }
        }
        private static void HookManager_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Console.WriteLine("down: " + e.KeyCode);
        }
    }
}
