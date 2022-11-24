using KanchoBank.BusinessLogicLayer.BALContracts;
using System.Collections.Generic;
using KanchoBank.Entities;
using KanchoBank.Exceptions;
using KanchoBank.DataAccessLayer.DALContrcts;
using KanchoBank.DataAccessLayer;

namespace KanchoBank.BussinesLogicLayer
{
    /// <summary>
    /// Represent customer business logic
    /// </summary>
    public class CustomersBusinessLogicLayer:ICustomersBusinessLogicLayer
    {
        #region Private Fields
        private ICustomerDataAccesLayer _customersDataAccessLayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initialize the CustomerDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomerDataAccesLayer();
        }
        #endregion

        #region Private Property
        /// <summary>
        /// Private property that represents the reference of CustomerDataAccessLayer
        /// </summary>
        private ICustomerDataAccesLayer CustomerDataAccesLayer
        {
            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }
        #endregion

        #region Methods

        /// <summary>
        ///Returns all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //Invoke DAL
                return CustomerDataAccesLayer.GetCustomers();
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
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression that has a condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //Invoke DAL
                return CustomerDataAccesLayer.GetCustomersByCondition(predicate);
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
        /// Adds new customer to the existing customer list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true if customer is added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //Get all existing customers
                List<Customer> allCustomers = CustomerDataAccesLayer.GetCustomers();
                long maxCustomerCode = 0;
                foreach (Customer item in allCustomers)
                {
                    if (item.CustomerCode > maxCustomerCode)
                    {
                        maxCustomerCode = item.CustomerCode;
                    }
                }
                //Generate customer number
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustomerCode + 1;
                }
                else
                {
                   customer.CustomerCode = KanchoBank.Configuration.Settings.BaseCustomerNo + 1;
                }
                //Invoke DAL
                return CustomerDataAccesLayer.AddCustomer(customer);
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
        /// Updates existing customer 
        /// </summary>
        /// <param name="customer">Customer object that contains details to update</param>
        /// <returns>Returns true if customer is added successfully</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //Invoke DAL
                return CustomerDataAccesLayer.UpdateCustomer(customer);
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
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Returns true if customer is added successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                //Invoke DAL
                return CustomerDataAccesLayer.DeleteCustomer(customerId);
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