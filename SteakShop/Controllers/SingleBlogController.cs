using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteakShop.Models;
using SteakShop.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace SteakShop.Controllers
{
    public class SingleBlogController : Controller
    {
        private readonly Steak_ShopContext _context;

        public SingleBlogController(Steak_ShopContext context)
        {
            _context = context;
        }
        public IActionResult SingleBlog(int Id)
        {
            string Username = HttpContext.Session.GetString("Username") ?? "";

            if (Username!= null)
            {
                var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
                ViewData["User"] = getUser;
            }
            else
            {
                ViewData["User"] = null;
            }

            var blog = _context.Blogs
                .Include(b => b.UidNavigation)
                .Include(b => b.BlogsCategories)
                .Include(b => b.Comments)
                .Where(b => b.Id == Id).FirstOrDefault();

            var categories = _context.BlogsCategories
                .Include(b => b.CidNavigation)
                .ToList();

            var comments = _context.Comments
                .ToList();

            var category = _context.BlogCategories.ToList();

            var image = _context.BlogImages.Where(b => b.Bid == Id).ToList();

            var viewModel = new BlogViewDTO
            {
                BlogImages = image,
                SingleBlog = blog,
                BlogCategories = category,
                Comments = comments,
                Categories = categories
            };
            return View("~/Views/Blog/SingleBlog.cshtml", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment()
        {
            try
            {
                int bid = int.Parse(Request.Form["SingleBlog.Id"]);
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string message = Request.Form["message"];
                Comment comment = new Comment
                {
                    Date = DateTime.Now,
                    Name = name,
                    Email = email,
                    Message = message,
                    Bid = bid                    
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("SingleBlog", new { Id = bid });
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        public IActionResult CreateBlog()
        {
            string Username = HttpContext.Session.GetString("Username") ?? "";

            if (Username != null)
            {
                var getUser = _context.Users.Where(u => u.Username == Username).FirstOrDefault();
                ViewData["User"] = getUser;
            }
            else
            {
                ViewData["User"] = null;
            }

            var cate = _context.BlogCategories.ToList();

            ViewData["CateIds"] = cate;
            return View("~/Views/Blog/CreateBlog.cshtml");
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogViewDTO blogViewDTO)
        {           
            int uid = int.Parse(Request.Form["uid"]);
            string BlogTitle = Request.Form["BlogTitle"];
            string BlogDetails = Request.Form["BlogDetails"];
            string Content = Request.Form["Content"];
            try
            {
                Blog blog = new Blog
                {
                    BlogTitle = BlogTitle,
                    BlogDetails = BlogDetails,
                    Date = DateTime.Now,
                    Content = Content,
                    Uid = uid,
                    Cid = 1
                };
                _context.Blogs.Add(blog);
                _context.SaveChanges();

                List<int> selectedCategories = blogViewDTO.SelectedCategories;
                if (blogViewDTO.SelectedCategories != null && blogViewDTO.SelectedCategories.Any())
                {
                    foreach (int categoryId in selectedCategories)
                    {
                        BlogsCategory blogsCategory = new BlogsCategory
                        {
                            Bid = blog.Id,
                            Cid = categoryId
                        };
                        _context.BlogsCategories.Add(blogsCategory);
                    }
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(CreateBlog));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
