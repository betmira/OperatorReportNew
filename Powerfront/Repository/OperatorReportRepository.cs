using Powerfront.Database;
using Powerfront.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Powerfront.Repository
{
    public class OperatorReportRepository : IOperatorReportRepository
    {

        

        public OperatorReportItems GetOperatorsReport(string device, string web, string startDate, string endDate)
        {
            OperatorReportItems ProductivityReport = new OperatorReportItems();
            ProductivityReport.OperatorProductivity = new List<OperatorReportViewModel>();
            //ProductivityReport.Visitors = new List<Visitor>();
            //ProductivityReport.WebSite = new List<string>();
            //ProductivityReport.DateModels = new List<DateModel>();

            try
            {                
                using (var db = new chatEntities())
                {
                    // Get filters data
                    DateTime? startDateTime = null;
                    if (startDate != "null")
                    {
                        var tt = startDate.Replace("0:0:0", "00:00:00");
                        // startDateTime = DateTime.ParseExact(startDate.Replace(' ','-'), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture); // DateTime.Parse(startDate);
                        startDateTime = DateTime.ParseExact(tt, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    DateTime? endDateTime = null;
                    if (endDate != "null")
                    {
                        endDateTime = DateTime.ParseExact(endDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    if (web == "null")
                        web = null;

                    if (device == "null")
                    {
                        device = null;
                    }

                    var reports = db.OperatorProductivity(website: web, device: device, startDate: startDateTime, endDate: endDateTime).ToList();
                    GetProductivityReport(ProductivityReport, reports);
                    //GetVisitors(ProductivityReport, db);
                    //GetWebsites(ProductivityReport, db);
                    //GetDates(ProductivityReport);               


                }
            }
            catch (Exception e)
            {
                // will some message on window
                
            }
            
            return ProductivityReport;
        }

        private static void GetProductivityReport(OperatorReportItems ProductivityReport, List<OperatorProductivity_Result> reports)
        {
           
            
            foreach (var dr in reports)
            {
                OperatorReportViewModel opVM = new Models.OperatorReportViewModel();
                opVM.ID = Convert.ToInt32(dr.OperatorID);
                opVM.Name = Convert.ToString(dr.Name);
                opVM.ProactiveAnswered = Convert.ToInt32(dr.ProactiveAnswered);
                opVM.ProactiveSent = Convert.ToInt32(dr.ProactiveSent);
                opVM.ProactiveResponseRate = Convert.ToInt32(dr.ProactiveResponseRate);
                opVM.ReactiveAnswered = Convert.ToInt32(dr.ReactiveAnswered);
                opVM.ReactiveReceived = Convert.ToInt32(dr.ReactiveReceived);
                opVM.ReactiveResponseRate = Convert.ToInt32(dr.ReactiveResponseRate);
                opVM.AverageChatLength = Convert.ToString(dr.AverageChatLength)+"mm";           
                TimeSpan t = TimeSpan.FromMinutes(Convert.ToDouble(dr.TotalChatLength));

                string answer = string.Format("{0:D2}d:{1:D2}h:{2:D2}m",
                                t.Days,
                                t.Hours,
                                t.Minutes                               );
                opVM.TotalChatLength = answer;
                ProductivityReport.OperatorProductivity.Add(opVM);
            }
        }
    }
}