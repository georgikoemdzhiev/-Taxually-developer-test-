using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.VatRegisters;

public interface IVatRegister
{
    public Task Register(VatRegistrationModel model);
}