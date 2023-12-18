using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities;

public record GameDto(
    int Id,
    string Name,
    string Genres,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto
(
    [Required]
    [StringLength(100)]
    string Name,

    [Required]
    [StringLength(500)]
    string Genres,

    [Range(1, 300)]
     decimal Price,

    DateTime ReleaseDate,

    [Url]
    [StringLength(200)]
    string ImageUri
);

public record UpdateGameDto
(
    [Required]
    [StringLength(100)]
     string Name,
    [Required]
    [StringLength(500)]
     string Genres,
    [Range(1, 300)]
     decimal Price,

    DateTime ReleaseDate,

    [Url]
    [StringLength(200)]
    string ImageUri
);