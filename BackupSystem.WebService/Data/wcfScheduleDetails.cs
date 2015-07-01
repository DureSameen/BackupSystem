using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackupSystem.WebService.Data
{
    [DataContract]
    public class wcfScheduleDetails
    {
        [DataMember]

        public long Schedule_Detail_Id { get; set; }
       
        [DataMember]
         
        public string Name { get; set; }
       
         [DataMember]
        public string SourcePath { get; set; }
         [DataMember]
         public string TargetPath { get; set; }
         [DataMember]
         public string SourceUserId { get; set; }
         [DataMember]
         public string SourceUser_DomainName { get; set; }
         [DataMember]
         public string SourceUser_Password { get; set; }
         [DataMember]
         public string TargetUserId { get; set; }
         [DataMember]
         public string TargetUser_DomainName { get; set; }
         [DataMember]
         public string TargetUser_Password { get; set; }
         [DataMember]
         public Enums.BackupType BackupType  { get; set; }
         


    }
}