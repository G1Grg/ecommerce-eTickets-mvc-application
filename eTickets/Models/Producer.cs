using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;
namespace eTickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Producer Image is required")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="Name should be between 3 and 30")]
        public string? FullName { get; set; }

        [Display (Name ="Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string? Bio { get; set; }

        
        //Relationship between producers and Movies (1 to many) 
        public List<Movie>? Movies { get; set; }
    }
}
