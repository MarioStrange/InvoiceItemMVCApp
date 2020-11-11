using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace InvoiceItemMVCApp.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }


        private int? invoiceNumber;
        [DisplayName("Broj fakture")]
        public int? InvoiceNumber
        {
            get
            {
                return invoiceNumber;
            }
            set
            {
                invoiceNumber = InvoiceId;
            }
        }


        private DateTime? invoiceCreationDate;
        [DisplayName("Datum stvaranja fakture")]
        public DateTime? InvoiceCreationDate
        {
            get
            {
                return invoiceCreationDate;
            }
            set
            {
                invoiceCreationDate = DateTime.Today;
            }
        }


        private DateTime? invoicePaymentFinalDate;
        [DisplayName("Datum dospijeća fakture")]
        public DateTime? InvoicePaymentFinalDate
        {
            get
            {
                return invoicePaymentFinalDate;
            }
            set
            {
                invoicePaymentFinalDate = DateTime.Today.AddDays(30);
            }
        }


        [Required]
        [DisplayName("Opis prodane stavke")]
        public string ItemName { get; set; }


        [Required]
        [DisplayName("Količina prodane stavke")]
        [Range(1, 999999999, ErrorMessage = "Količina mora biti između 1 i 999999999")]
        public int ItemAmount { get; set; }


        [Required]
        [DisplayName("Jedinična cijena stavke bez poreza")]
        [Range(0.1, 999999999, ErrorMessage = "Cijena mora biti između 1 i 999999999")]
        public decimal ItemPrice { get; set; }


        private decimal? itemTotalPrice;
        [DisplayName("Ukupna cijena za stavku bez poreza")]
        public decimal? ItemTotalPrice
        {
            get
            {
                return itemTotalPrice;
            }
            set
            {
                itemTotalPrice = ItemPrice * ItemAmount;
            }
        }

        private decimal? invoiceTotalPriceWithTax;
        [DisplayName("Ukupna cijena s porezom")]
        public decimal? InvoiceTotalPriceWithTax
        {
            get
            {
                return invoiceTotalPriceWithTax;
            }
            set
            {
                invoiceTotalPriceWithTax = ItemTotalPrice + (ItemTotalPrice / 100 * 25);
            }
        }


        private string invoiceCreator;
        [DisplayName("Ulogirani korisnik")]
        public string InvoiceCreator
        {
            get
            {
                return invoiceCreator;
            }
            set
            {
                invoiceCreator = HttpContext.Current.User.Identity.Name.ToString();
            }
        }


        [DisplayName("Primatelj računa")]
        public string InvoiceCustomer { get; set; }
    }
}