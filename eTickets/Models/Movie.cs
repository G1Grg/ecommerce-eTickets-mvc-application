using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "image URL")]
        public string? imageURL { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationship between Movies and Actor_movies is 1 to Many

        public List<Actor_Movie>? Actors_Movies { get; set; }

        //cinema to Movie
        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema? cinema { get; set; }

        //cinema to Movie
        public int ProducerId{ get; set; }

        [ForeignKey("ProducerId")]
        public Producer? producer { get; set; }


    }
}
