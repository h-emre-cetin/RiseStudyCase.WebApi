namespace RiseStudyCase.WebApi.Models
{
    public class ContactReportModel
    {
        public Dictionary<string, List<ContactModel>>? LocationInfo { get; set; }

        public Dictionary<string, int>? LocationRank { get; set; }

        public Tuple<string, int>? LocationContactCount { get; set; }

        public Tuple<string, int>? LocationContactPhoneNumberCount { get; set; }
    }
}
