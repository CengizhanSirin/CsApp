using System;
using System.ComponentModel.DataAnnotations;

namespace CsApp.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
