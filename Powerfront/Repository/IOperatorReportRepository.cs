using Powerfront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerfront.Repository
{
    public interface IOperatorReportRepository
    {
       
        OperatorReportItems GetOperatorsReport(string device, string web, string startDate, string endDate);
    }
}
