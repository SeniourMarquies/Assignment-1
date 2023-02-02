using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Product
    {
        /* Instance Variables: Declare fields (variables) in your class for saving input: name (string), count
    (int), unitPrice (double), foodItem (bool). Declare also variables for storing output: totalVAT
        (double) and totalNetValue (double). You can hard-code the values of vat rate in a couple of
    constants as follows: */

        private string m_name { get; set; }
        private decimal    m_count { get; set; }
        private decimal m_unitPrice { get; set; }
        private bool  m_foodItem { get; set; }
        private decimal m_totalVat { get; set; }
        private decimal m_totalNetValue { get; set; }
        private const decimal m_foodVATRate = 0.12m, m_otherVATRate = 0.25m;
        private decimal m_sumWithoutTax = 0;
 

        public void Start()
        {
            //Read Input
            ReadInput();

            // Calculate total tax
            CalculateValues();

            // Calculate Total Net Price, total price
            PrintReceipt();
        }
        private void ReadInput()
        {
            // Read Name of the product
            ReadName();

            // Read price without Vat
            ReadNetUnitPrice();

            // Ask the user if the item is a food.
            ReadIfFoodItem();

            // Read Number of items quantity
            ReadCount();
        }

        private void ReadName()
        {
            Console.Write("Product name  : ");
            m_name = Console.ReadLine();
        }

        private void ReadNetUnitPrice()
        {
            Console.Write("Net unit price :");
            m_unitPrice = decimal.Parse(Console.ReadLine());
            
        }

        private void ReadIfFoodItem()
        {
            Console.Write("Food item (y/n): ");
            char response = char.Parse(Console.ReadLine());
            if ((response == 'y') || (response == 'Y'))
                m_foodItem = true;
            else m_foodItem = false;
        }

        private void ReadCount()
        {
            Console.Write("Count :");
            m_count = decimal.Parse(Console.ReadLine());
        }
        private void CalculateValues()
        {
            m_sumWithoutTax =  m_count * m_unitPrice;
            if (m_foodItem == true) m_totalNetValue = m_sumWithoutTax * m_foodVATRate;
            else m_totalNetValue = m_sumWithoutTax * m_otherVATRate;
            
        }

        private void PrintReceipt()
        {
            Console.WriteLine("WELCOME TO MY VIRTUAL DRUGSTORE");
            Console.WriteLine(string.Format("Name of the product: {0,-20}\n Quantity: {1,20}\n Unity price: {2,20}\n Food Item: {3,20}\n Total amount to pay : {4:00.00}\n Including VAT at {5:P0} ", m_name, m_count, m_unitPrice, m_foodItem, m_totalNetValue, m_foodItem == true ? m_foodVATRate : m_otherVATRate));
        }

        

        
    }
}
