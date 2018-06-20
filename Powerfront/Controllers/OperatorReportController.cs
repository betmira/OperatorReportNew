using Powerfront.Models;
using Powerfront.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Powerfront.Controllers
{
    public class OperatorReportController : ApiController
    {
        private IOperatorReportRepository _operatorReportRepository;       

        public OperatorReportController (IOperatorReportRepository operatorReportRepository)

        {
            _operatorReportRepository = operatorReportRepository;
        }


        // GET: api/Customers
        public OperatorReportItems GetOperatorReportRepository( string device,string web, string startDate, string endDate)
        {       
            var start = Request.Content;
            return _operatorReportRepository.GetOperatorsReport(device , web, startDate, endDate);
        }
    }
}
