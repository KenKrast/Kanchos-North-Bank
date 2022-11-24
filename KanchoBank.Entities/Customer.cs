using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanchoBank.Entities.Contracts;
using KanchoBank.Exceptions;

namespace KanchoBank.Entities
{
    /// <summary>
    /// Represent the customer info of the bank
    /// </summary>
    public class Customer : ICustomer, ICloneable
    {
        #region Private fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Public properties
        public Guid CustomerID { get => _customerID; set => _customerID = value; }

        public long CustomerCode
        { get => _customerCode;
            set
            {
                //customer code should be positive number
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code must be positive number");
                }
            }
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                //customer name should not be null and less than 40 characters
                if (value.Length <= 40 && string.IsNullOrEmpty(value) == false)
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("Name should be above 0 under 40 characters long");
                }
            }
        }
        public string Address { get => _address; set => _address = value; }
        public string Landmark { get => _landmark; set => _landmark = value; }
        public string City { get => _city; set => _city = value; }
        public string Country { get => _country; set => _country = value; }
        public string Mobile { get => _mobile;
            set
            {
                //mobile number should be 10 digits
                if (value.Length == 10)
                {
                   _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number should be 10 digits");
                }
            }
            

        }
        #endregion

        #region Methonds

        public object Clone()
        {
            return new Customer(){CustomerID = this.CustomerID, CustomerCode = this.CustomerCode, CustomerName = this.CustomerName, Address = this.Address, Landmark = this.Landmark, City = this.City, Country = this.Country, Mobile = this.Mobile};
        }
        #endregion
    }
}
