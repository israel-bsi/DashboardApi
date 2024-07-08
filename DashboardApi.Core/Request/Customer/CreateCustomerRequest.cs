using System.ComponentModel.DataAnnotations;

namespace DashboardApi.Core.Request.Customer;

public class CreateCustomerRequest : Request
{
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    public string Name { get; set; } = string.Empty;
}