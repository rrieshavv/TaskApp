namespace Application.Models.Report
{
    public class TransferReportViewModel
    {
        public List<TransferData>? TransferData { get; set; }
    }

    public class TransferData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverMiddleName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCountry { get; set; }
        public string BankName { get; set; }
        public string payoutAmount { get; set; }
        public string exchangeRate { get; set; }
        public string TransferAmount { get; set; }
        public string TransferIso3 { get; set; }
        public string PayoutIso3 { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
