using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace TrayApplication
{
    public class Listen : IDisposable
    {
        private static List<string> _data;
 
        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            string insert = string.Format("KeyDown - {0}\n", e.KeyCode);
            _data.Add(insert);
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            string insert = string.Format("KeyUp - {0}\n", e.KeyCode);
            _data.Add(insert);
        }


        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
           string insert = string.Format("KeyPress - {0}\n", e.KeyChar);
           _data.Add(insert);
        } 

        public Listen() 
        {
            _data = new List<string>();

            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.KeyUp += HookManager_KeyUp;
            HookManager.KeyPress += HookManager_KeyPress;
        }

        public List<string> GetData()
        {
            List<string> rRet = _data;
            return rRet;
        } 
        public void Dispose()
        {
            HookManager.KeyDown -= HookManager_KeyDown;
            HookManager.KeyUp -= HookManager_KeyUp;
            HookManager.KeyPress -= HookManager_KeyPress;
            _data = null;
        }
    }
}
