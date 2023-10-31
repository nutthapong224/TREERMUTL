using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TREERMUTL.Models
{
    public class TREERMUTLCREATE
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public  string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public  string Description { get; set; }

        [MaxLength(500)]
        public  string PhotoUrl { get; set; }
        [NotMapped]
        
        public  IFormFile ProfilePhoto { get; set; }


    }
}
