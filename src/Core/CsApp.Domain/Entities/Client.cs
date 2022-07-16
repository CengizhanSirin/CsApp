using CsApp.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsApp.Domain.Entities
{
    public class Client : BaseEntity
    {
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "İsim Boş Geçilemez")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Soyisim Boş Geçilemez")]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage = "Telefon Boş Geçilemez")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        [Required(ErrorMessage = "Cinsiyet Boş Geçilemez")]
        public string Gender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(160)]
        [Required(ErrorMessage = "Adres Boş Geçilemez")]
        public string Address { get; set; }


        public ICollection<Complaint> Complaints { get; set; }
    }
}
