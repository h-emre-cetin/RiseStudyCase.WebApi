using Microsoft.EntityFrameworkCore;
using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Repositories.EntitiyFramework
{
    public class EfContactRepository : IContactRepository
    {
        RiseStudyContext _context;

        public EfContactRepository(RiseStudyContext context)
        {
            _context = context;
        }
        public bool AddInfo(Guid id, ContactType contactType, string contactInfo)
        {
            var info = new ContactInfoModel { ContactId = id, ContactType = contactType, Content = contactInfo };

            var contact = _context.Contacts.Where(c=> c.Id == id).FirstOrDefault();

            contact.ContactInfos.Add(info);

            _context.SaveChanges();
            
            return true;
        }

        public ContactModel Create(ContactModel contact)
        {
           _context.Contacts.Add(contact);
           
            _context.SaveChanges();
            
            return contact;
        }

        public bool Delete(Guid id)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();
            
            _context.Contacts.Remove(contact);
            
            _context.SaveChanges();

            return true;
        }

        public ContactModel Get(Guid id)
        {
            return _context.Contacts.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<ContactModel> GetAll()
        {
            var getContact = _context.Contacts.ToList();
            
            return getContact;
        }

        public bool Remove(Guid id)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();
            
            contact.IsActive = false;
           
            _context.SaveChanges();
            
            return true;
        }

        public bool RemoveInfo(Guid id, ContactType contactType)
        {
            var contactInfo = _context.ContactsInfos.Where(c => c.ContactId == id && c.ContactType == contactType).FirstOrDefault();
            
            _context.ContactsInfos.Remove(contactInfo);
            
            _context.SaveChanges();
            
            return true;
        }

        public ContactModel Update(ContactModel contact)
        {
            var getContact = _context.Contacts.Where(c => c.Id == contact.Id).FirstOrDefault();

            getContact.Name = contact.Name;

            getContact.Surname = contact.Surname;

            getContact.Company = contact.Company;

            _context.SaveChanges();

            return contact;
        }
    }
}
