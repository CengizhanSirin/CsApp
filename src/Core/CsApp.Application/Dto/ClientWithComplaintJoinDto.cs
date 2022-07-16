using System;

namespace CsApp.Application.Dto
{
    public class ClientWithComplaintJoinDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }

        public string Content { get; set; }
    }
}
