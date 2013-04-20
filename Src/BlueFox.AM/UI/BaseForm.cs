using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace BlueFox.AM.UI
{
    public partial class BaseForm : Form
    {
        protected const int WM_DEVICECHANGE = 0x219;//U盘插入后，OS的底层会自动检测到，然后向应用程序发送“硬件设备状态改变“的消息
        protected const int DBT_DEVICEARRIVAL = 0x8000;  //就是用来表示U盘可用的。一个设备或媒体已被插入一块，现在可用。
        protected const int DBT_CONFIGCHANGECANCELED = 0x0019;  //要求更改当前的配置（或取消停靠码头）已被取消。
        protected const int DBT_CONFIGCHANGED = 0x0018;  //当前的配置发生了变化，由于码头或取消固定。
        protected const int DBT_CUSTOMEVENT = 0x8006; //自定义的事件发生。 的Windows NT 4.0和Windows 95：此值不支持。
        protected const int DBT_DEVICEQUERYREMOVE = 0x8001;  //审批要求删除一个设备或媒体作品。任何应用程序也不能否认这一要求，并取消删除。
        protected const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;  //请求删除一个设备或媒体片已被取消。
        protected const int DBT_DEVICEREMOVECOMPLETE = 0x8004;  //一个设备或媒体片已被删除。
        protected const int DBT_DEVICEREMOVEPENDING = 0x8003;  //一个设备或媒体一块即将被删除。不能否认的。
        protected const int DBT_DEVICETYPESPECIFIC = 0x8005;  //一个设备特定事件发生。
        protected const int DBT_DEVNODES_CHANGED = 0x0007;  //一种设备已被添加到或从系统中删除。
        protected const int DBT_QUERYCHANGECONFIG = 0x0017;  //许可是要求改变目前的配置（码头或取消固定）。
        protected const int DBT_USERDEFINED = 0xFFFF;  //此消息的含义是用户定义的

        protected IList<DriveInfo> currentRemovableDrives;

        public event DelegateRemovableDriveArrived RemovableDriveArrived;
        public event DelegateRemovableDrivePulled RemovableDrivePulled;

        public BaseForm()
        {
            InitializeComponent();
            DriveInfo[] s = DriveInfo.GetDrives();
            this.currentRemovableDrives = (from loop in s where loop.DriveType == DriveType.Removable select loop).ToList();
        }

        protected virtual void OnRemovableDriveArrived(DriveInfo d)
        {
            if (this.RemovableDriveArrived != null)
            {
                this.RemovableDriveArrived(this, new RemovableDriveEventArgs(d));
            }
        }

        protected virtual void OnRemovableDrivePulled(DriveInfo d)
        {
            if (this.RemovableDrivePulled != null)
            {
                this.RemovableDrivePulled(this, new RemovableDriveEventArgs(d));
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE://
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    var cnt = (from loop in this.currentRemovableDrives
                                               where loop.Name == drive.Name
                                               select loop).Count();
                                    if (cnt < 1)
                                    {
                                        this.currentRemovableDrives.Add(drive);
                                        this.OnRemovableDriveArrived(drive);
                                    }
                                }
                            }
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                            DriveInfo[] d = DriveInfo.GetDrives();
                            var rd = (from loop in d
                                      where loop.DriveType == DriveType.Removable
                                      select loop).ToList();
                            foreach (var loop in this.currentRemovableDrives)
                            {
                                var cnt = (from o in rd where o.Name == loop.Name select o).Count();
                                if (cnt < 1)
                                {
                                    this.OnRemovableDrivePulled(loop);
                                }
                            }
                            this.currentRemovableDrives = rd;
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED://可用，设备变化时
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.WndProc(ref m);
        }
    }
}
