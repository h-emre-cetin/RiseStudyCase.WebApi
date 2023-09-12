namespace RiseStudyCase.WebApi.Models
{
    public class ContactReportModel
    {
        public List<Dictionary<string, int>>? LocationInfo { get; set; }

        public int? LocationContanctCount { get; set; }

        public int? LocationContactPhoneNumberCount { get; set; }
    }
}
