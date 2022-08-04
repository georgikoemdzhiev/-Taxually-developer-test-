using System.Xml.Serialization;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public class XmlVatRegister : IVatRegister
{
    public Task Register(VatRegistrationModel model)
    {
        using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationModel));
            serializer.Serialize(stringwriter, this);
            var xml = stringwriter.ToString();
            var xmlQueueClient = new TaxuallyQueueClient();
            // Queue xml doc to be processed
            return xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}