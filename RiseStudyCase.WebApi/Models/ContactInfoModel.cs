using System.ComponentModel.DataAnnotations;

namespace RiseStudyCase.WebApi.Models
{
    public class ContactInfoModel
    {
        public Guid ContactId { get; set; } 

        public ContactType ContactType { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public enum ContactType
    {
        PhoneNumber,
        Email,
        Location,
    }
}
