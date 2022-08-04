using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.VatRegisters;

public class XmlVatRegister : IVatRegister
{
    private ITaxuallyQueueClient _xmlQueueClient;

    public XmlVatRegister(ITaxuallyQueueClient xmlQueueClient)
    {
        _xmlQueueClient = xmlQueueClient;
    }


    public Task Register(VatRegistrationModel model)
    {
        var payload = BuildPayload(model);
        // Queue xml doc to be processed
        // TODO move queue name to appsettings
        return _xmlQueueClient.EnqueueAsync("vat-registration-xml", payload);
    }

    private string BuildPayload(VatRegistrationModel model)
    {
        using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationModel));
            serializer.Serialize(stringwriter, model);
            return stringwriter.ToString();
        }
    }
}