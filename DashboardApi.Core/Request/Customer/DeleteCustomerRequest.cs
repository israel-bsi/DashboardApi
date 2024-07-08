using System.Text.Json.Serialization;

namespace DashboardApi.Core.Request.Customer;

public class DeleteCustomerRequest
{
    [JsonIgnore]
    public int Id { get; set; }
}