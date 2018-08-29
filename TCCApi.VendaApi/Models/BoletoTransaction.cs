using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCApi.VendaApi.Models
{
    public abstract class TransactionObject{

        public TransactionObject()
        {
            paymentMode = "default";
            currency = "BRL";
        }

        public string Email { get; set; }
        public string token { get; set; }
        public string paymentMode { get; set; }
        public string paymentMethod { get; set; }
        public string receiverEmail { get; set; }
        public string currency { get; set; }
        public double extraAmount { get; set; }
        public string itemId1 { get; set; }
        public string itemDescription1 { get; set; }
        public double itemAmount1 { get; set; }
        public int itemQuantity1 { get; set; }
        public string notificationURL { get; set; }
        public string reference { get; set; }
        //Informações do comprador
        public string senderName { get; set; }
        public string senderCPF { get; set; }
        public string senderAreaCode { get; set; }
        public string senderPhone { get; set; }
        public string senderEmail { get; set; }
        public string senderHash { get; set; }
        //Informações de Entrega
        public string shippingAddressStreet { get; set; }
        public string shippingAddressNumber { get; set; }
        public string shippingAddressComplement { get; set; }
        public string shippingAddressDistrict { get; set; }
        public string shippingAddressPostalCode { get; set; }
        public string shippingAddressCity { get; set; }
        public string shippingAddressState { get; set; }
        public string shippingAddressCountry { get; set; }
        public int shippingType { get; set; }
        public double shippingCost { get; set; }

    }

    public class BoletoTransaction : TransactionObject

    {

        public BoletoTransaction()
        {
            paymentMethod = "Boleto";   
        }
    }

    public class DebitoTransaction : TransactionObject
    {
        public DebitoTransaction()
        {
            paymentMethod = "eft";
        }

        public string bankName { get; set; }
    }

    public class CreditoTransaction : TransactionObject
    {
        public CreditoTransaction()
        {
            paymentMethod = "creditCard";
        }

         
    public string creditCardToken { get; set; }
        public int installmentQuantity { get; set; }
        public double installmentValue { get; set; }
        public int noInterestInstallmentQuantity { get; set; }
        public string creditCardHolderName { get; set; }
        public string creditCardHolderCPF { get; set; }
        public string creditCardHolderBirthDate { get; set; }
        public string creditCardHolderAreaCode { get; set; }
        public string creditCardHolderPhone { get; set; }
        public string billingAddressStreet { get; set; }
        public string billingAddressNumber { get; set; }
        public string billingAddressComplement { get; set; }
        public string billingAddressDistrict { get; set; }
        public string billingAddressPostalCode { get; set; }
        public string billingAddressCity { get; set; }
        public string billingAddressState { get; set; }
        public string billingAddressCountry { get; set; }
    }
}
