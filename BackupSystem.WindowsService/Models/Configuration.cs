using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

using System.Configuration;
namespace BackupSystem.WindowsService.Models
{
{
   public static class Configuration
    {

        

        public static string SoapHeaderUserName
        {
            get
            {
                return ConfigurationManager.AppSettings["SoapHeaderUserName"].ToString();
            }
        }

        public static string SoapHeaderPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["SoapHeaderPassword"].ToString();
            }
        }
        
       
    }
}