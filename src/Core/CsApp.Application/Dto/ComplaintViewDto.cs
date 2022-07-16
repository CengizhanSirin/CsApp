using System;

namespace CsApp.Application.Dto
{
    public class ComplaintViewDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int ClientId { get; set; }
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
