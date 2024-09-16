using System.ComponentModel.DataAnnotations;

namespace CustomerManagementApi.DTOs
{
  public class UpdateCustomerDTO
  {
    public string? Name { get; set; }
    public char? Gender { get; set; }
    public int? CustomerTypeId { get; set; }
    public int? CustomerStatusId { get; set; }
  }
}
