using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Abstract
{
    public interface IContactReportRepository
    {
        ContactReportModel GetReportByLocation();

        ContactReportModel GetReportOfLocationRank();

        ContactReportModel GetReportOfLocationContactCount();

        ContactReportModel GetReportOfLocationPhoneNumberCount();

    }
}
