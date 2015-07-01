using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupSystem.WebService.Data
{
    public static class Enums
    {


        public  enum ScheduleType
        { NoType=0,
        Daily=1,
        Weekly=2,
        Monthly=3,
        Once=4
        
        
        }

        public  enum Status
        { NoStatus = 0,
          Pending=1,
          Done=2
        
        }
        public enum BackupType
        {
            NoType = 0,
            Simple_Folder_Copy = 1,
            Incremental_Backup = 2

        }

    }
}