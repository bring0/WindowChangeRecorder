using System;
using System.Collections.Generic;

namespace CSScratch
{
    class IntervalEvent : IDisposable
    {
        public string WindowHandle { get; set; }
        public List<System.Windows.Forms.KeyEventArgs> KeyData { get; set; }
        public DateTime StartTime { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}