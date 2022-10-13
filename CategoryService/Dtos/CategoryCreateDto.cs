using System.ComponentModel.DataAnnotations;

namespace CategoryService.Dtos;

public class CategoryCreateDto
{
    [Required]
    public string Name { get; set; }
}