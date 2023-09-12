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

        public ContactReportModel GetReportOfLocationContactCount()
        {
            throw new NotImplementedException();
        }

        public ContactReportModel GetReportOfLocationPhoneNumberCount()
        {
            throw new NotImplementedException();
        }

        public ContactReportModel GetReportOfLocationRank()
        {
            throw new NotImplementedException();
        }
    }
}
