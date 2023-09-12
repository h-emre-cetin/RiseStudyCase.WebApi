using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Abstract
{
    public interface IContactReportService
    {
        ContactReportModel GetReportByLocation();

        ContactReportModel GetReportOfLocationRank();

        ContactReportModel GetReportOfLocationContactCount();

        ContactReportModel GetReportOfLocationPhoneNumberCount();

    }
}
