using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Repositories.EntitiyFramework
{
    public class EfContactReportRepository : IContactReportRepository
    {
        RiseStudyContext _context;
        public EfContactReportRepository(RiseStudyContext context)
        {
                _context = context;
        }
        public ContactReportModel GetReportByLocation()
        {
            ContactReportModel report = new();

            var locationList = _context.ContactsInfos.Where(c => c.ContactType == ContactType.Location).ToList();
            IEnumerable<ContactModel> contacts = new List<ContactModel>();


            foreach (var location in locationList)
            {
                contacts = from c in _context.Contacts.ToList()
                           join ci in _context.ContactsInfos.ToList() on c.Id equals ci.ContactId
                           where ci.Content == location.Content
                           select c;

                report.LocationInfo.Add(location.Content, contacts.ToList());
            }

            return report;
        }
 
        public ContactReportModel GetReportOfLocationContactCount(string location)
        {
            ContactReportModel contactReport = new();
            var personCountInLocation = _context.ContactsInfos
                .Count(ci => ci.ContactType == ContactType.Location && ci.Content == location);

            contactReport.LocationContactCount = Tuple.Create(location, personCountInLocation);
            
            return contactReport;
        }

        public ContactReportModel GetReportOfLocationPhoneNumberCount(string location)
        {
            ContactReportModel contactReport = new();

            ContactType targetType = ContactType.PhoneNumber;

            var phoneNumberCountInLocation = _context.ContactsInfos
                .Count(ci => ci.ContactType == targetType && ci.Content == location);

            contactReport.LocationContactPhoneNumberCount = Tuple.Create(location, phoneNumberCountInLocation);

            return contactReport;
        }

        public ContactReportModel GetReportOfLocationRank()
        {
            ContactReportModel contactReport = new();

            var locationCounts = _context.ContactsInfos
            .Where(ci => ci.ContactType == ContactType.Location)
            .GroupBy(ci => ci.Content)
            .Select(group => new { Location = group.Key, Count = group.Count() })
            .OrderByDescending(item => item.Count)
            .ThenBy(item => item.Location)
            .ToList();

            foreach (var locationCount in locationCounts)
            {
                contactReport.LocationRank.Add(locationCount.Location, locationCount.Count);
            }

            return contactReport;
        }
    }
}
