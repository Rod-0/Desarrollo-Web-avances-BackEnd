using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Input;

public class DestinationInput
{
    [Required]
    [MaxLength(30)]
    [MinLength(1)]

    public string name { get; set; }
    public int maxUser { get; set; }
    public int isRisky { get; set; }
}
