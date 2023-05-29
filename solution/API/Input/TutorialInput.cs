using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Input;

public class TutorialInput
{
    [Required]
    [MaxLength(10)]
    [MinLength(3)]

    public string Name { get; set; }
    public string Description { get; set; }
}
