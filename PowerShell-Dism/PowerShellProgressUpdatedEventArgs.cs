using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell_Dism
{
    public delegate void PowerShellProgressUpdatedEventHandler(object sender, PowerShellProgressUpdatedEventArgs e);

    public class PowerShellProgressUpdatedEventArgs : EventArgs
    {
        public int Progress { get; private set; }
        public PowerShellProgressUpdatedEventArgs(int percentDone)
        {
            this.Progress = percentDone;
        }
    }
}
