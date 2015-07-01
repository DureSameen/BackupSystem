using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.WinApp.Models
{
   public static class IP
    {

       public static string Find()

       {  
       string ipAddress = "";
       if (Dns.GetHostAddresses(Dns.GetHostName()).Length > 0)
       {
           ipAddress = Dns.GetHostAddresses(Dns.GetHostName())[2].ToString();
       }

       return ipAddress;
       }
    }
}
