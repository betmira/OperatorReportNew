using Powerfront.Database;
using Powerfront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerfront.Repository
{
    public class OperatorReportFilterRepository : IOperatorReportFilterRepository
    {
        public OperatorReportFilter GetOperatorReportFilter()
        {
            OperatorReportFilter operatorReportFilter = new OperatorReportFilter();
          
            operatorReportFilter.WebSite = new List<string>();
            operatorReportFilter.DateModels = new List<DateModel>();
            operatorReportFilter.Devices = new List<Device>();
            using (var db = new chatEntities())
            {
                // Get filters data

                GetWebsites(operatorReportFilter, db);
                GetDates(operatorReportFilter);
                GetDevices(operatorReportFilter,db);


            }
            return operatorReportFilter;

        }

  

        private void GetDates(OperatorReportFilter operatorReportFilter)
        {
            var tw = DateRangeRepository.ThisWeek(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "this week", startDate = tw.Start, endDate = tw.End });
            var lastweek = DateRangeRepository.LastWeek(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "last week", startDate = lastweek.Start, endDate = lastweek.End });
            var thisMonth = DateRangeRepository.ThisMonth(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "this month", startDate = thisMonth.Start, endDate = thisMonth.End });
            var lastMonth = DateRangeRepository.LastMonth(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "last month", startDate = lastMonth.Start, endDate = lastMonth.End });
            var thisYear = DateRangeRepository.ThisYear(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "this year", startDate = thisYear.Start, endDate = thisYear.End });
            var lastYear = DateRangeRepository.LastYear(DateTime.Now);
            operatorReportFilter.DateModels.Add(new DateModel() { name = "last year", startDate = lastYear.Start, endDate = lastYear.End });


        }


        private void GetWebsites(OperatorReportFilter operatorReportFilter, chatEntities db)
        {
            operatorReportFilter.WebSite = db.Conversation.Select(x => x.Website).Distinct().ToList();
        }
        
        private void GetDevices(OperatorReportFilter operatorReportFilter, chatEntities db)
        {
            var devicesDB = db.Visitor.Select(x=>x.Device).Distinct();
            var visitor = db.Visitor;

            foreach(var device in devicesDB)
            {
                operatorReportFilter.Devices.Add(new Device()
                {
                    Name = device,
                    Ids = visitor.Where(x => x.Device == device).Select(x => x.VisitorID).ToList()
                });
            }
            

        }

    }


}