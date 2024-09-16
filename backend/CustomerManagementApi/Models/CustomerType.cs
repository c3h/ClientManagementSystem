namespace CustomerManagementApi.Models
{
  public class CustomerType
  {
    public int Id { get; set; }
    public string Description { get; set; }

    public ICollection<Customer> Customers { get; set; }
  }
}
