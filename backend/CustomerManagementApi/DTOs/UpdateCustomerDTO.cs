using System.ComponentModel.DataAnnotations;

namespace CustomerManagementApi.DTOs
{
  public class UpdateCustomerDTO
  {
    [MinLength(3, ErrorMessage = "The name must be at least 3 characters.")]
    [MaxLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Invalid CPF. Use the format 000.000.000-00.")]
    public char Gender { get; set; }

    [Required]
    public int CustomerTypeId { get; set; }

    [Required]
    public int CustomerStatusId { get; set; }
  }
}
