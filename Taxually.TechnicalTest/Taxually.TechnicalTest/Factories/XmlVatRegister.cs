using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public class XmlVatRegister : IVatRegister
{
    public Task Register(IVatRegistrationModel model)
    {
        using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationModel));
            serializer.Serialize(stringwriter, this);
            var xml = stringwriter.ToString();
            // TODO we can use constructor Dependency Injection and inject the queue client
            var xmlQueueClient = new TaxuallyQueueClient();
            // Queue xml doc to be processed
            // TODO move queue name to appsettings
            return xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}