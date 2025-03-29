using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string UserName { get; set; } 

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Mail { get; set; }

    [Required]
    [StringLength(255)]
    public string Pass { get; set; }  

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    [Required]
    [StringLength(3)]
    public string Status { get; set; } 
}

