using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Models.Report;

namespace TaskApp.Services.Services.Report
{
    public interface IReportService
    {
        Task<List<TransferReportResponse>> GetTransferResponse(string useremail, string from, string to);
    }
}
