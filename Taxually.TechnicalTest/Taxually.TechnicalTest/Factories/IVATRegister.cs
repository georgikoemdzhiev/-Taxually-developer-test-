using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Factories;

public interface IVatRegister
{
    public Task Register(IVatRegistrationModel model);
}