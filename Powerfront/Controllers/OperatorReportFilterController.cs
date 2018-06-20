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
    public class OperatorReportFilterController : ApiController
    {
        private IOperatorReportFilterRepository _operatorReportFilterRepository;

        public OperatorReportFilterController(IOperatorReportFilterRepository operatorReportFilterRepository)

        {
            _operatorReportFilterRepository = operatorReportFilterRepository;

        }

        // GET: api/Customers
        public OperatorReportFilter GetOperatorReportRepository()
        {
            //OperatorReportRepository operatorReportRepository = new OperatorReportRepository();
            // _operatorReportRepository.
            
            return _operatorReportFilterRepository.GetOperatorReportFilter();
        }
    }
}
