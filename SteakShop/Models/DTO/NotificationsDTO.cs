namespace SteakShop.Models.DTO
{
    public class NotificationsDTO
    {
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public int countNoti { get; set; }
        public List<NotificationsDTO> Notifications { get; set; }
    }
}
