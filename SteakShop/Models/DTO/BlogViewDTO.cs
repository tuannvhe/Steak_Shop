namespace SteakShop.Models.DTO
{
    public class BlogViewDTO
    {   
        public Blog? SingleBlog { get; set; }
        public List<BlogCategory>? BlogCategories { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Blog>? Blogs { get; set; }
        public List<BlogsCategory>? Categories { get; set; }
        public List<BlogImage>? BlogImages { get; set; }
        public List<int>? SelectedCategories { get; set; }
    }
}
