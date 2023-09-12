using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Abstract
{
    public interface IContactReportRepository
    {
        ContactReportModel GetReportByLocation();

        ContactReportModel GetReportOfLocationRank();

        ContactReportModel GetReportOfLocationContactCount(string location);

        ContactReportModel GetReportOfLocationPhoneNumberCount(string location);

    }
}
