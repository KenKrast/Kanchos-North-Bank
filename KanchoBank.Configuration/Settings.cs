namespace KanchoBank.Configuration
{
    /// <summary>
    /// Project level configuration seffings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Customer number starts from 1001; increments by 1
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;
    }
}