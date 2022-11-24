using System;
using KanchoBank.Entities;
using System.Collections.Generic;

namespace KanchoBank.DataAccessLayer.DALContrcts
{
    /// <summary>
    /// This interface contains all customers data acces layer
    /// </summary>
    public interface ICustomerDataAccesLayer
    {
        List<Customer> GetCustomers();
        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression that has a condition to check</param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);
        /// <summary>
        /// Adds new customer to the existing customer list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true if customer is added successfully</returns>
        Guid AddCustomer(Customer customer);
        /// <summary>
        /// Updates existing customer 
        /// </summary>
        /// <param name="customer">Customer object that contains details to update</param>
        /// <returns>Returns true if customer is added successfully</returns>
        bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Returns true if customer is added successfully</returns>
        bool DeleteCustomer(Guid customerId);
    }
}
