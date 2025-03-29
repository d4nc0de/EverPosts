﻿using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RelPostCategorie
{
    [Key]
    public int RelId { get; set; }

    [ForeignKey("Post")]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }

    [ForeignKey("Categorie")]
    public int CategorieId { get; set; }
    public virtual Categorie Categorie { get; set; }
    [Required]
    [StringLength(3)]
    public string Status { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}

