using System.Text;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public class CsvVatRegister : IVatRegister
{
    private ITaxuallyQueueClient _queueClient;
    public CsvVatRegister(ITaxuallyQueueClient queueClient)
    {
        this._queueClient = queueClient;
    }
    public Task Register(VatRegistrationModel model)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{model.CompanyName}{model.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        
        // TODO move to field and pass to constructor using an Interface
        // Queue file to be processed
        // TODO move queue name to appsettings
        return _queueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}