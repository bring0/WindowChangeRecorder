using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Timers;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using Timer = System.Timers.Timer;

namespace ScratchTwo
{
    class Program
    {
        static Timer _timer;
        private static BufferBlock<System.Windows.Forms.KeyEventArgs> _keyEvents;
        //private static ConcurrentDictionary<int, string> rRet = new ConcurrentDictionary<int, string>();
        static void Main(string[] args)
        {
            init();
            bool hee = false;
            while (!hee)
            {
                string hoo = Console.ReadLine();
                if (hoo == "exit")
                    hee = true;
            }
        }

        static void init()
        {
            _keyEvents = new BufferBlock<KeyEventArgs>();

            Thread userActivityThread = new Thread(Run_UserActivityThread);
            userActivityThread.Name = "UserActivityThread";
            userActivityThread.IsBackground = true;
            //Required to ensure thread is automatically stopped when application's main thread closes
            userActivityThread.Start();
            _timer = new Timer(5000); // Set up the timer for 3 seconds
            //
            // Type "_timer.Elapsed += " and press tab twice.
            //
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it


        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Task tsk = new Task(DoDumpAndClear);
            tsk.Start();
            tsk.Wait();
            // HOW DO I STOP THIS THANG --oh, get rid of readkey

        }

        static async void DoDumpAndClear()
        {
            Task<IList<KeyEventArgs>> result = DumpAndClear();
            IList<KeyEventArgs> ee = await result;
            Console.WriteLine("Writing to \"database\" thread {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < ee.Count; i++)
            {
                KeyEventArgs ke = ee[i];
                Console.WriteLine(ke.KeyCode.ToString());
            }
           
        }
        static async Task<IList<KeyEventArgs>> DumpAndClear()
        {
            IList<KeyEventArgs> rRet = new List<KeyEventArgs>();
           
            while (await _keyEvents.OutputAvailableAsync())
            {

                if (_keyEvents.TryReceiveAll(out rRet))
                {
                    Console.WriteLine("Recieved {0} items on thread {1}", rRet.Count,
                        Thread.CurrentThread.ManagedThreadId);
                    if (_keyEvents.Count == 0)
                    {
                        return rRet;
                    }
                }
                else
                {
                    Console.WriteLine("Aint recieve none on thread {0}", Thread.CurrentThread.ManagedThreadId);
                }
            }
            //KeyEventArgs key = await _keyEvents.ReceiveAsync();
            //Console.WriteLine(key.KeyCode.ToString());
            return rRet;
        }
        private static void Run_UserActivityThread()
        {
            HookManager.KeyDown += HookManager_KeyDown;

            while (true)
            {
                Application.DoEvents(); //required to get any events raised
                Thread.Sleep(9);        //Sleeping too long, e.g. 10ms will result in touch events arriving several seconds delayed due to event overload
            }
        }
        private static void HookManager_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            _keyEvents.Post(e);
            //Console.WriteLine("down: " + e.KeyCode);
        }
    }
}
