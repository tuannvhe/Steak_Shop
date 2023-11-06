namespace SteakShop.Models.DTO
{
    public class CustomerDTO
    {
        public string ?Username { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CustomerDTO> ?BigCustomers { get; set; }
        public List<CustomerDTO> ?MediumCustomers { get; set; }
    }
}
