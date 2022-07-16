using CsApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsApp.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Başlık Boş Geçilemez")]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        [Required(ErrorMessage = "İçerik Boş Geçilemez")]
        public string Content { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
