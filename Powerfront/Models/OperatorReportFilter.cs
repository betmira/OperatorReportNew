using Powerfront.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerfront.Models
{
    public class OperatorReportFilter
    {
       // public IList<Visitor> Visitors { get; set; }

        public IList<Device> Devices { get; set; }
        public IList<String> WebSite { get; set; }
        public IList<DateModel> DateModels { get; set; }
    }
}