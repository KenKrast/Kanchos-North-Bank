using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using KanchoBank.Entities;
using KanchoBank.Exceptions;
using KanchoBank.DataAccessLayer.DALContrcts;

namespace KanchoBank.DataAccessLayer
{
    /// <summary>
    /// Represent DAL for bank customers
    /// </summary>
    public class CustomerDataAccesLayer:ICustomerDataAccesLayer
    {
        #region Fields
        private static List<Customer> _customers;
        #endregion

        #region Constructor

        static CustomerDataAccesLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represent source customer collection
        /// </summary>
        private static List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion

        #region Method
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //Create new customer list
                List<Customer> customers = new List<Customer>();

                //copy all customers from the source into the new Customers list
                Customers.ForEach(item => customers.Add(item.Clone() as Customer));
                return customers;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //Create new customer list
                List<Customer> customers = new List<Customer>();

                // Filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                //Copy all customers from the source into the new Customers list
                filteredCustomers.ForEach(item => customers.Add(item.Clone() as Customer));
                return customers;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Adds new customer to the existing list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //Generate new Guid
                customer.CustomerID = Guid.NewGuid();

                //Add customer
                Customers.Add(customer);

                return customer.CustomerID;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            } 
        }
        /// <summary>
        /// Updates an existing customer's details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Determines whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //Find existing customer by CustomerID
                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //Update all details of the customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.City = customer.City;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true; // Indicates the customer is updated
                }
                else
                {
                    return false; // No object is updated
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// Deletes an existing customer based on CustomerID
        /// </summary>
        /// <param name="customerID">Customer ID to delete</param>
        /// <returns>Indicates whether the customer is deleted or n</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                //Delete customer by CustomerID
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true; //Indicates one or more customers are deleted
                }
                else
                {
                    return false; //Indicates no customer is deleted
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}