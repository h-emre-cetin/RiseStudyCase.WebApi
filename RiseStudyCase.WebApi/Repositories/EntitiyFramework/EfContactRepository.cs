using Microsoft.EntityFrameworkCore;
using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Controllers;
using RiseStudyCase.WebApi.Models;
using System.Reflection;

namespace RiseStudyCase.WebApi.Repositories.EntitiyFramework
{
    public class EfContactRepository : IContactRepository
    {
        RiseStudyContext _context;
        private readonly ILogger _logger;
        
        public EfContactRepository(RiseStudyContext context, ILogger<ContactController> logger)
        {
            _logger = logger;
            _context = context;
        }
       
        public bool AddInfo(Guid id, ContactType contactType, string contactInfo)
        {
            const string methodName = nameof(AddInfo);
            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                var info = new ContactInfoModel { ContactId = id, ContactType = contactType, Content = contactInfo };

                _logger.LogDebug($"[{methodName}] Getting contact info with giving id");
                var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

                _logger.LogDebug($"[{methodName}] Adding infos to given contact");
                contact.ContactInfos.Add(info);

                _context.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public ContactModel Create(ContactModel contact)
        {
            const string methodName = nameof(Create);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Contact is creating");
                _context.Contacts.Add(contact);


                _context.SaveChanges();

                _logger.LogTrace($"[{methodName}] Returning result.");
                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }

        }

        public bool Delete(Guid id)
        {

            const string methodName = nameof(Delete);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting contact info with giving id");
                var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

                _logger.LogDebug($"[{methodName}] Contact is deleting");
                _context.Contacts.Remove(contact);

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }

        }

        public ContactModel Get(Guid id)
        {
            const string methodName = nameof(Get);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting contact with giving id");
                return _context.Contacts.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public List<ContactModel> GetAll()
        {
            const string methodName = nameof(GetAll);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting all contacts");
                var getContact = _context.Contacts.ToList();

                return getContact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public bool Remove(Guid id)
        {
            const string methodName = nameof(Remove);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting contact info with giving id");
                var contact = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

                _logger.LogDebug($"[{methodName}] Givinmg contact status setting to removed");
                contact.IsActive = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
            
        }

        public bool RemoveInfo(Guid id, ContactType contactType)
        {
            const string methodName = nameof(RemoveInfo);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting contact info with giving parameters");
                var contactInfo = _context.ContactsInfos.Where(c => c.ContactId == id && c.ContactType == contactType).FirstOrDefault();

                _logger.LogDebug($"[{methodName}] Contact infos are removing");
                _context.ContactsInfos.Remove(contactInfo);

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex )
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
            
        }

        public ContactModel Update(ContactModel contact)
        {
            const string methodName = nameof(Update);

            try
            {
                _logger.LogTrace($"[{methodName}] Invoked");

                _logger.LogDebug($"[{methodName}] Getting contact info with giving id");
                var getContact = _context.Contacts.Where(c => c.Id == contact.Id).FirstOrDefault();

                _logger.LogDebug($"[{methodName}] Setting contact infos");
                getContact.Name = contact.Name;

                getContact.Surname = contact.Surname;

                getContact.Company = contact.Company;

                _context.SaveChanges();


                _logger.LogTrace($"[{methodName}] Returning result.");
                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }
    }
}
