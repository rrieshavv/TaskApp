using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Library;
using TaskApp.Services.Models.Report;

namespace TaskApp.Services.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly DAO _dao;
        public ReportService(DAO dao)
        {
            _dao = dao; 
        }

        public async Task<List<TransferReportResponse>> GetTransferResponse(string email, string fromdate, string todate)
        {
            var results = await _dao.ExecuteStoredProcedureAsync<TransferReportResponse>("sp_report_transfers", new
            {
                useremail = email,
                from = fromdate,
                to = todate
            });

            return results.ToList();
        }
    }
}
