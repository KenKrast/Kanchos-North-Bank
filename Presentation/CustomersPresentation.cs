using System;
using System.Collections.Generic;
using KanchoBank.Entities;
using KanchoBank.Exceptions;
using KanchoBank.BusinessLogicLayer.BALContracts;
using KanchoBank.BussinesLogicLayer;

namespace KanchoBank.Presentation
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //Create an object of customer
                Customer customer = new Customer();

                //Read all detail from the user
                Console.WriteLine("\n**********ADD CUSTOMER**********");
                Console.Write("Enter Name");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Enter Address");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark");
                customer.Landmark = Console.ReadLine();
                Console.Write("City");
                customer.City = Console.ReadLine();
                Console.Write("Country");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile");
                customer.Mobile = Console.ReadLine();

                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);              

                List<Customer> matchingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);
                if (matchingCustomer.Count >= 1)
                {
                    Console.WriteLine("New customer code" + matchingCustomer[0].CustomerCode);
                    Console.WriteLine("Customer Added\n");

                }
                else
                {
                    Console.WriteLine("Customer not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        internal static void ViewCustomers()
        {
            try
            {
                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
              
                List<Customer> allCustomer = customersBusinessLogicLayer.GetCustomers();

                Console.WriteLine("\n**********ALL CUSTOMERS**********");
                //Read all customers
                foreach (var item in allCustomer)
                {
                    Console.WriteLine("Customer code" +item.CustomerCode);
                    Console.WriteLine("Customer name" +item.CustomerName);
                    Console.WriteLine("Address" +item.Address);
                    Console.WriteLine("Landmark" + item.Landmark);
                    Console.WriteLine("City" +item.City);
                    Console.WriteLine("Country" +item.Country);
                    Console.WriteLine("Mobile" +item.Mobile);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.GetType());
            }
            
        }
    }
}
