using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using SteakShop.Models.DTO;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace SteakShop.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly Steak_ShopContext _context;

        public BlogController(Steak_ShopContext context)
        {
            _context = context;
        }
       
        public ActionResult Blog()
        {
            var blogs = _context.Blogs
                .Include(b => b.UidNavigation)
                .Include(b => b.BlogsCategories)
                .Include(b => b.Comments)
                .ToList();

            var categories = _context.BlogsCategories
                .Include(b => b.CidNavigation)
                .ToList();

            var comments = _context.Comments
                .ToList();

            var category = _context.BlogCategories.ToList();

            var blogImages = _context.BlogImages.ToList();

            var viewModel = new BlogViewDTO
            {
                BlogImages = blogImages,
                BlogCategories = category,
                Comments = comments,
                Blogs = blogs,
                Categories = categories
            };

            return View(viewModel);
        }
        public ActionResult Search(string searchKeyword)
        {
            
            List<Blog> results = null;
            if (searchKeyword == null)
            {
                results = _context.Blogs
               .Include(b => b.UidNavigation)
               .Include(b => b.BlogsCategories)
               .Include(b => b.Comments)
               .ToList();
            }
            else
            {
                searchKeyword = RemoveDiacritics(searchKeyword.ToLower());
                results = _context.Blogs
               .Include(b => b.UidNavigation)
               .Include(b => b.BlogsCategories)
               .Include(b => b.Comments)
               .Where(b =>
               b.BlogTitle.Contains(searchKeyword) 
               || b.BlogDetails.Contains(searchKeyword))
               .ToList();
            }

            var categories = _context.BlogsCategories
                .Include(b => b.CidNavigation)
                .ToList();

            var comments = _context.Comments
                .ToList();

            var category = _context.BlogCategories.ToList();

            var blogImages = _context.BlogImages.ToList();

            var viewModel = new BlogViewDTO
            {
                BlogImages = blogImages,
                BlogCategories = category,
                Comments = comments,
                Blogs = results,
                Categories = categories
            };

            return View("~/Views/Blog/Blog.cshtml", viewModel);
        }
        public ActionResult GetBlogsByCate(int categoryId)
        {
            var category = _context.BlogCategories.ToList();

            var getCate = _context.BlogsCategories
                .Include(b => b.BidNavigation)
                .Include(b => b.CidNavigation)
                .Where(b => b.Cid == categoryId).ToList();

            var blogs = _context.Blogs
                .Include(b => b.UidNavigation)
                .Include(b => b.BlogsCategories)
                .Include(b => b.Comments)
                .ToList();

            var categories = _context.BlogsCategories
                .Include(b => b.CidNavigation)              
                .ToList();

            var comments = _context.Comments.ToList();

            var blogImages = _context.BlogImages.ToList();

            var viewModel = new BlogViewDTO
            {
                BlogImages = blogImages,
                Blogs = blogs,
                BlogCategories = category,
                Comments = comments,
                Categories = getCate
            };

            return View("~/Views/Blog/Blog.cshtml", viewModel);
        }
        //Chuẩn hóa chuỗi 
        public string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

    }
}
