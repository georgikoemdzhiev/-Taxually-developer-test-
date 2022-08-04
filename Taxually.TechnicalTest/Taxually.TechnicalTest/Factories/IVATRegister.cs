using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public interface IVatRegister
{
    public Task Register(VatRegistrationModel model);
}