using System;
using System.ComponentModel.DataAnnotations;

public class Categorie
{
    [Key]
    public int CategorieId { get; set; } 

    [Required]
    public string Description { get; set; }
    [Required]
    [StringLength(3)]
    public string Status { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}

