using BackupSystem.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupSystem.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyicon.Visible = true;
            notifyicon.ShowBalloonTip(100, "BackupSystem", "Backup Started",  ToolTipIcon.Info);
            this.Hide();
            BackupSystemService.BackupManagerClient svc = new BackupSystemService.BackupManagerClient();

            string IPAddress = IP.Find();
            svc.CreateScheduleDetails(IPAddress);

            var backups = svc.GetScheduleDetails(IPAddress);

            foreach(var backup in backups)
            {

                Backup.Folder(backup.SourcePath, backup.TargetPath, DateTime.Now, backup.Name,  backup.BackupType );
                svc.Update_ScheduleDetailStatus(backup.Schedule_Detail_Id, BackupSystemService.EnumsStatus.Done);
                notifyicon.ShowBalloonTip(100, "BackupSystem", backup.Name +" Backup done successfully", ToolTipIcon.Info);
            }

        }
    }
}



