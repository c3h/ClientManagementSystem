namespace CustomerManagementApi.Models
{
  public class Customer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public char Gender { get; set; }

    public int CustomerTypeId { get; set; }
    public CustomerType CustomerType { get; set; }

    public int CustomerStatusId { get; set; }
    public CustomerStatus CustomerStatus { get; set; }
  }
}
