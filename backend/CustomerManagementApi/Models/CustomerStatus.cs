namespace CustomerManagementApi.Models
{
  public class CustomerStatus
  {
    public int Id { get; set; }
    public string Description { get; set; }

    public ICollection<Customer> Customers { get; set; }
  }
}
