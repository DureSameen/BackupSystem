using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.WindowsService.Models
{
   public static class IP
    {
       public static string GetComputerName()
       { return Dns.GetHostName(); }
       public static string Find()

       {  
      
   IPHostEntry host;
   string localIP = "";
   host = Dns.GetHostEntry(Dns.GetHostName());
   foreach (IPAddress ip in host.AddressList)
   {
     if (ip.AddressFamily == AddressFamily.InterNetwork)
     {
       localIP = ip.ToString();
       break;
     }
   }
   return localIP;
 } 
    }
}
