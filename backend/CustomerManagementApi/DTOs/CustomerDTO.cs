namespace CustomerManagementApi.DTOs
{
  public class CustomerDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public char Gender { get; set; }
    public CustomerTypeDTO CustomerType { get; set; }
    public CustomerStatusDTO CustomerStatus { get; set; }
  }
}
