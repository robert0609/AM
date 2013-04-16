using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BlueFox.AM.UI
{
    public class RemovableDriveEventArgs : EventArgs
    {
        public DriveInfo RemovableDrive
        {
            get;
            private set;
        }

        public RemovableDriveEventArgs(DriveInfo drive)
        {
            this.RemovableDrive = drive;
        }
    }

    public delegate void DelegateRemovableDriveArrived(object sender, RemovableDriveEventArgs e);

    public delegate void DelegateRemovableDrivePulled(object sender, RemovableDriveEventArgs e);
}
