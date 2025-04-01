using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }  
    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    [Required]
    [StringLength(3)]
    public string Status { get; set; }

    public int TotalComments { get; set; }

    public string ImageRoute { get; set; }
}

