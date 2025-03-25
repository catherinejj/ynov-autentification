using System.ComponentModel.DataAnnotations;// à ajouter sinon on a une erreur
using System.Collections.Generic;
namespace EntityFramework

{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }

        public required ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}