using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(500)]
        public required string Genres { get; set; }

        [Range(1, 300)]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(200)]
        public required string ImageUri { get; set; }


    }
}