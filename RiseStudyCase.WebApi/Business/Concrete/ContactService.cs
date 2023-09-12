using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Controllers;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Concrete
{
    public class ContactService : IContactService
    {
        private readonly ILogger<ContactController> _logger;

        public ContactService(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public bool AddInfo(Guid id, ContactType contactType, string contactInfo)
        {
            throw new NotImplementedException();
        }

        public ContactModel Create(ContactModel contact)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ContactModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ContactModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveInfo(Guid id, ContactType contactType)
        {
            throw new NotImplementedException();
        }

        public ContactModel Update(ContactModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
