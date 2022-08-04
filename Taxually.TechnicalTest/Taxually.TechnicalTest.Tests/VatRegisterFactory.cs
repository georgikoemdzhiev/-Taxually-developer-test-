using NUnit.Framework;
using Taxually.TechnicalTest.Factories;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Tests.Models;

namespace Taxually.TechnicalTest.Tests;

public class Tests
{
    private VatRegisterFactory _vatRegisterFactory;

    [SetUp]
    public void Setup()
    {
        _vatRegisterFactory = new VatRegisterFactory();
    }

    public void Can_Create_HttpVatRegister()
    {
        // Arrange
        var countryCode = "GB";
        var xmlRegister = _vatRegisterFactory.GetVatRegister(countryCode);
        IVatRegistrationModel model = new MockVatRegistrationModel{Country = countryCode};

        // Act
        var actual = xmlRegister.Register(model);

        // Assert
        Assert.NotNull(xmlRegister);
    }
    
    [Test]
    public void Can_Create_CsvVatRegister()
    {
        // Arrange
        var countryCode = "FR";
        var csvRegister = _vatRegisterFactory.GetVatRegister(countryCode);
        IVatRegistrationModel model = new MockVatRegistrationModel{Country = countryCode};

        // Act
        var actual = csvRegister.Register(model);

        // Assert
        Assert.NotNull(csvRegister);
    }
    
    [Test]
    public void Can_Create_XmlVatRegister()
    {
        // Arrange
        var countryCode = "DE";
        var xmlRegister = _vatRegisterFactory.GetVatRegister(countryCode);
        IVatRegistrationModel model = new MockVatRegistrationModel{Country = countryCode};

        // Act
        var actual = xmlRegister.Register(model);

        // Assert
        Assert.NotNull(xmlRegister);
    }
    
    
}