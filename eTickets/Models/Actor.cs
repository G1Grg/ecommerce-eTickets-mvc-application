using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Profile Picture URL")]
        [Required(ErrorMessage ="Profile Picture is Required")]        
        public string? ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength (50,MinimumLength =3,ErrorMessage ="Full Name must be between 3 and 50 Chars")]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Biography is Required")]
        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        //relationship between Actor and Actor_Movie is 1 to Many
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
