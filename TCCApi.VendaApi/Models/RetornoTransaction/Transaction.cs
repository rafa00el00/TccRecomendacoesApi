using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TCCApi.VendaApi.Models.RetornoTransaction
{
    [XmlRoot(ElementName = "paymentMethod")]
    public class PaymentMethod
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class Items
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "phone")]
    public class Phone
    {
        [XmlElement(ElementName = "areaCode")]
        public string AreaCode { get; set; }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "sender")]
    public class Sender
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "phone")]
        public Phone Phone { get; set; }
    }

    [XmlRoot(ElementName = "address")]
    public class Address
    {
        [XmlElement(ElementName = "street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "complement")]
        public string Complement { get; set; }
        [XmlElement(ElementName = "district")]
        public string District { get; set; }
        [XmlElement(ElementName = "postalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "state")]
        public string State { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "shipping")]
    public class Shipping
    {
        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "cost")]
        public string Cost { get; set; }
    }

    [XmlRoot(ElementName = "transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "lastEventDate")]
        public string LastEventDate { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }
        [XmlElement(ElementName = "paymentLink")]
        public string PaymentLink { get; set; }
        [XmlElement(ElementName = "grossAmount")]
        public string GrossAmount { get; set; }
        [XmlElement(ElementName = "discountAmount")]
        public string DiscountAmount { get; set; }
        [XmlElement(ElementName = "feeAmount")]
        public string FeeAmount { get; set; }
        [XmlElement(ElementName = "netAmount")]
        public string NetAmount { get; set; }
        [XmlElement(ElementName = "extraAmount")]
        public string ExtraAmount { get; set; }
        [XmlElement(ElementName = "installmentCount")]
        public string InstallmentCount { get; set; }
        [XmlElement(ElementName = "itemCount")]
        public string ItemCount { get; set; }
        [XmlElement(ElementName = "items")]
        public Items Items { get; set; }
        [XmlElement(ElementName = "sender")]
        public Sender Sender { get; set; }
        [XmlElement(ElementName = "shipping")]
        public Shipping Shipping { get; set; }
    }
}
