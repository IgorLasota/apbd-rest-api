using System.ComponentModel.DataAnnotations;

namespace RestApi.DTO;

public class AnimalInputDto
{
    [Required]
    public string Name { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Area { get; set; }
}

public class AnimalOutputDto
{
    [Required]
    public int IdAnimal { get; set; }
    
    [Required]
    public string Name { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Area { get; set; }
}
