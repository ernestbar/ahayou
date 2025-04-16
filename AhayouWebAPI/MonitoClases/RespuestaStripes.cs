using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class AdaptivePricing
    {
        public bool enabled { get; set; }
    }

    public class Address
    {
        public string country { get; set; }
    }

    public class AutomaticTax
    {
        public bool enabled { get; set; }
    }

    public class Card
    {
        public string request_three_d_secure { get; set; }
    }

    public class ConsentCollection
    {
        public string promotions { get; set; }
        public string terms_of_service { get; set; }
    }

    public class CurrencyConversion
    {
        public int amount_subtotal { get; set; }
        public int amount_total { get; set; }
        public string fx_rate { get; set; }
        public string source_currency { get; set; }
    }

    public class CustomerDetails
    {
        public Address address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string tax_exempt { get; set; }
    }

    public class Data
    {
        public Object @object { get; set; }
    }

    public class InvoiceCreation
    {
        public bool enabled { get; set; }
    }

    public class Object
    {
        public AdaptivePricing adaptive_pricing { get; set; }
        public bool allow_promotion_codes { get; set; }
        public int amount_subtotal { get; set; }
        public int amount_total { get; set; }
        public AutomaticTax automatic_tax { get; set; }
        public string billing_address_collection { get; set; }
        public string cancel_url { get; set; }
        public string client_reference_id { get; set; }
        public ConsentCollection consent_collection { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public CurrencyConversion currency_conversion { get; set; }
        public string customer { get; set; }
        public string customer_creation { get; set; }
        public CustomerDetails customer_details { get; set; }
        public int expires_at { get; set; }
        public string id { get; set; }
        public InvoiceCreation invoice_creation { get; set; }
        public bool livemode { get; set; }
        public string locale { get; set; }
        public string mode { get; set; }
        public string @object { get; set; }
        public string payment_intent { get; set; }
        public string payment_link { get; set; }
        public string payment_method_collection { get; set; }
        public PaymentMethodOptions payment_method_options { get; set; }
        public List<string> payment_method_types { get; set; }
        public string payment_status { get; set; }
        public PhoneNumberCollection phone_number_collection { get; set; }
        public SavedPaymentMethodOptions saved_payment_method_options { get; set; }
        public string status { get; set; }
        public string submit_type { get; set; }
        public string success_url { get; set; }
        public TotalDetails total_details { get; set; }
        public string ui_mode { get; set; }
    }

    public class PaymentMethodOptions
    {
        public Card card { get; set; }
    }

    public class PhoneNumberCollection
    {
        public bool enabled { get; set; }
    }

    public class RespuestaStripes
    {
        public string api_version { get; set; }
        public int created { get; set; }
        public Data data { get; set; }
        public string id { get; set; }
        public bool livemode { get; set; }
        public string @object { get; set; }
        public int pending_webhooks { get; set; }
        public string type { get; set; }
    }

    public class SavedPaymentMethodOptions
    {
        public List<string> allow_redisplay_filters { get; set; }
    }

    public class TotalDetails
    {
        public int amount_discount { get; set; }
        public int amount_shipping { get; set; }
        public int amount_tax { get; set; }
    }
}
