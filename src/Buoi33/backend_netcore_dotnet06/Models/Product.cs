using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //Nvarchar(255)
    // day la validation cho truong Name
    [Required]
    [StringLength(255)]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? Alias { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? Description { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string ImageUrl { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}