namespace RiseStudyCase.WebApi.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        ContactType ContactType { get; set; }

        public string ContactInfo { get; set; }

    }

    enum ContactType
    {
        PhoneNumber,
        Email,
        Location,
    }
}
