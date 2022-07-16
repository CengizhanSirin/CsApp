using System;

namespace CsApp.Application.Dto
{
    public class ClientViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
