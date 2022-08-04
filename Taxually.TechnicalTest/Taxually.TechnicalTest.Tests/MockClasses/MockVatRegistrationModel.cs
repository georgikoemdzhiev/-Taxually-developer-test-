using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Tests.Models;

public class MockVatRegistrationModel : IVatRegistrationModel
{
    public string? CompanyName { get; set; }
    public string? CompanyId { get; set; }
    public string? Country { get; set; }
}