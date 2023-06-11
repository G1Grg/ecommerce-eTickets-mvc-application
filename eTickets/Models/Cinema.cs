using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Logo is required")]
        [Display(Name = "Logo")]
        public string? Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Should be between 3 and 30")]
        public string? Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema Description is required")]
        public string? Description { get; set; }

        //relationships between Cinema and Movies (1 to Many)
        public List<Movie>? movies { get; set; }

    }
}
