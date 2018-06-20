using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerfront.Models
{
    public class OperatorReportItems
    {
        public List<OperatorReportViewModel> OperatorProductivity { get { return _operatorReportViewModel; } set { _operatorReportViewModel = value; } }

        private List<OperatorReportViewModel> _operatorReportViewModel;

        public IEnumerator<OperatorReportViewModel> GetEnumerator()
        {
            return _operatorReportViewModel.GetEnumerator();
        }
    }
}