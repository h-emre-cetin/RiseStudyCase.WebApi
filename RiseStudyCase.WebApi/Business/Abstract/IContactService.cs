using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Abstract
{
    public interface IContactService
    {
        ContactModel Get(Guid id);

        List<ContactModel> GetAll();

        ContactModel Create(ContactModel contact);

        bool Remove(Guid id);

        ContactModel Update(ContactModel contact);

        bool Delete(Guid id);

        bool AddInfo(Guid id, ContactType contactType, string contactInfo);

        bool RemoveInfo(Guid id, ContactType contactType);
    }
}
