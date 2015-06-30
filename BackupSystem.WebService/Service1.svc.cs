using BackupSystem.Model;
using BackupSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BackupSystem.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private IScheduleService _ScheduleService;
        public Service1(IScheduleService  scheduleService)
        {
            if (scheduleService == null)
                throw new ArgumentNullException("service");

            this._ScheduleService = scheduleService;
        }

        public List<wcfSchedule_Detail> GetAllSchedulebyIP(string IP)
        {
            var selectedSchedules = (from schedule in _ScheduleService.getSchedulebyIp(IP)
                                     select new wcfSchedule_Detail { }).ToList ();




            return selectedSchedules;
        }
    }
}
