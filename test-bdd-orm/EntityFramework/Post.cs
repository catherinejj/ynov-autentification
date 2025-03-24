using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;// à ajouter sinon on a une erreur
namespace EntityFramework
{
    public class Post
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(1200)]
        public required string Text { get; set; }

        //[Required]
        //[ForeignKey("UserId")]
        public int UserId { get; set; }

        public required virtual User User { get; set; }

    }
}