using System.Text.Json.Serialization;

namespace DashboardApi.Core.Request.Customer;

public class UpdateCustomerRequest : CreateCustomerRequest
{
    [JsonIgnore]
    public int Id { get; set; }
}
