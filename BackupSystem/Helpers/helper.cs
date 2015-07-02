using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackupSystem.Helpers
{
    public static class helper
    { 
        public static MvcHtmlString RowColor(this HtmlHelper htmlHelper, 
        	int EventTypeId)
        {   string style="";
            if (EventTypeId==3)
              style="style=color:red";

            return MvcHtmlString.Create(style);
        
   
}
    }
}