using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Controllers;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Business.Concrete
{
    public class ContactRepository : IContactRepository
    {
        List<ContactModel> _contacts;

        private readonly ILogger<ContactController> _logger;

        public ContactRepository(ILogger<ContactController> logger)
        {
            _logger = logger;
            _contacts = new List<ContactModel>
            {
                new ContactModel
                {
                    Id=Guid.NewGuid(),
                    Name = "Emre",
                    Surname = "Cetin",
                    Company = "Rise",
                    IsActive = true
                }
            };
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
