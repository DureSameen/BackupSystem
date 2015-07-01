using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Web;
using System.Configuration;

namespace BackupSystem.WebService.Security
{
    public class ServiceAuthenticator : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HttpRequestMessageProperty objHttpRMP = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            if (objHttpRMP.Headers["RESTAPIUsername"] == null)
                throw new WebFaultException<string>("Missing username - Authentication failed.", System.Net.HttpStatusCode.BadRequest);

            if (objHttpRMP.Headers["RESTAPIPassword"] == null)
                throw new WebFaultException<string>("Missing password - Authentication failed.", System.Net.HttpStatusCode.BadRequest);

            string sUsername = objHttpRMP.Headers["RESTAPIUsername"];
            string sPassword = objHttpRMP.Headers["RESTAPIPassword"];

            if (sUsername != ConfigurationManager.AppSettings["SoapHeaderUserName"].ToString() || sPassword != ConfigurationManager.AppSettings["SoapHeaderPassword"].ToString())
                throw new WebFaultException<string>("Authentication failed.", System.Net.HttpStatusCode.BadRequest);

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}