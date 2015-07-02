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


             

            string IPAddress = IP.Find();

            if (!WorkStation.GetbyIP(IPAddress))
                WorkStation.AddWorkStation(IPAddress, IP.GetComputerName());

            BackupManager.CreateScheduleDetails(IPAddress);
           
            var backups = BackupManager.GetScheduleDetails(IPAddress);

            foreach(var backup in backups)
            {

                if (Backup.CopyFolder(backup.SourcePath, backup.TargetPath, DateTime.Now, backup.Name, backup.BackupType, backup.Schedule_Detail_Id, backup.SourceUserId, backup.SourceUser_Password, backup.SourceUser_DomainName, backup.TargetUserId, backup.TargetUser_Password, backup.TargetUser_DomainName))
                {
                    BackupManager.Update_ScheduleDetailStatus(backup.Schedule_Detail_Id, BackupSystemService.EnumsStatus.Done);

                    notifyicon.ShowBalloonTip(100, "BackupSystem", backup.Name + " Backup done successfully", ToolTipIcon.Info);
                }

                else
                { notifyicon.ShowBalloonTip(100, "BackupSystem", backup.Name + " Backup completed with errors", ToolTipIcon.Error ); }
            }
       timer_closeformapp.Enabled=true;  
        }

    
     

        private void timer_closeformapp_Tick(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        } 
  
    }
}



