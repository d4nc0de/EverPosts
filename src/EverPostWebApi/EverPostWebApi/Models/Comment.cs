using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]
    public int CommentId { get; set; }  

    [Required]
    public string Content { get; set; }

    [ForeignKey("Post")]
    public int? PostId { get; set; }
    public virtual Post Post { get; set; }

    [Required]
    [StringLength(3)]
    public string Status { get; set; }

    [Required]
    [ForeignKey("User")]
    public int? UserId { get; set; }
    public virtual User User { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}

