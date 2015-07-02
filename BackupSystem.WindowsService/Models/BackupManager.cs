
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.WindowsService.Models
{
{
    public static class BackupManager
    {


        public static void CreateScheduleDetails(string IPAddress) 
        {
            using (BackupSystemService.BackupManagerClient client = new BackupSystemService.BackupManagerClient())
            {

                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {


                    HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers.Add("RESTAPIUsername", Configuration.SoapHeaderUserName);
                    httpRequestProperty.Headers.Add("RESTAPIPassword", Configuration.SoapHeaderPassword);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                    client.CreateScheduleDetails(IPAddress);
                }
            }
        }
      
    }
}
