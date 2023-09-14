using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Controllers;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Repositories.EntitiyFramework
{
    public class EfContactReportRepository : IContactReportRepository
    {
        RiseStudyContext _context;
        private readonly ILogger _logger;

        public EfContactReportRepository(RiseStudyContext context, ILogger<ContactController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public ContactReportModel GetReportByLocation()
        {
            const string methodName = nameof(GetReportByLocation);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                ContactReportModel report = new();

                _logger.LogDebug($"[{methodName}] Getting contact type location");
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

                _logger.LogTrace($"[{methodName}] Returning result.");
                return report;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }

        }

        public ContactReportModel GetReportOfLocationContactCount(string location)
        {
            const string methodName = nameof(GetReportOfLocationContactCount);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                ContactReportModel contactReport = new();

                _logger.LogDebug($"[{methodName}] Getting count of contact in location");
                var personCountInLocation = _context.ContactsInfos
                    .Count(ci => ci.ContactType == ContactType.Location && ci.Content == location);

                contactReport.LocationContactCount = Tuple.Create(location, personCountInLocation);

                _logger.LogTrace($"[{methodName}] Returning result.");
                return contactReport;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public ContactReportModel GetReportOfLocationPhoneNumberCount(string location)
        {
            const string methodName = nameof(GetReportOfLocationPhoneNumberCount);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                ContactReportModel contactReport = new();

                _logger.LogDebug($"[{methodName}] Getting count of phone numbers in location");
                ContactType targetType = ContactType.PhoneNumber;

                var phoneNumberCountInLocation = _context.ContactsInfos
                    .Count(ci => ci.ContactType == targetType && ci.Content == location);

                contactReport.LocationContactPhoneNumberCount = Tuple.Create(location, phoneNumberCountInLocation);

                _logger.LogTrace($"[{methodName}] Returning result.");
                return contactReport;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public ContactReportModel GetReportOfLocationRank()
        {
            const string methodName = nameof(GetReportOfLocationRank);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                ContactReportModel contactReport = new();

                _logger.LogDebug($"[{methodName}] Getting report of location rank");
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

                _logger.LogTrace($"[{methodName}] Returning result.");
                return contactReport;
            }
            catch (Exception)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
            
        }
    }
}
