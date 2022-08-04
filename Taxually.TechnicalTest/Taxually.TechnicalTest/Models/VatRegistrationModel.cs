using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Models;

public class VatRegistrationModel : IVatRegistrationModel
{
    public string? CompanyName { get; set; }
    public string? CompanyId { get; set; }
    public string? Country { get; set; }
}