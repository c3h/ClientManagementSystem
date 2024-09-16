namespace CustomerManagementApi.Models
{
  public class PagedResult<T>
  {
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
  }
}
