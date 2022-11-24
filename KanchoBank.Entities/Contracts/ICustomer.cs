namespace KanchoBank.Entities.Contracts
{
    /// <summary>
    /// Represents the interface of the customer entity
    /// </summary>
    public interface ICustomer
    {
        #region Proteries
        Guid CustomerID { get; set; } 
       long CustomerCode { get; set; }
       string CustomerName { get; set; }
       string Address { get; set; }
       string Landmark { get; set; }
       string City { get; set; }
       string Country { get; set; }
       string Mobile { get; set; }
       #endregion
    }
}