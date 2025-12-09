using CRM2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using System.Net;

namespace CRM2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Crm1Context context;

        public HomeController(Crm1Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Edit(string id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Dashboard");
            }
            var productDto = new ProductDto()
            {
                Name = product.Name,
                Email = product.Email,
                Phone = product.Phone,
                Address = product.Address,
                CreatedDate = product.CreatedDate,
                Status = product.Status,
            };
            ViewData["CustomerId"] = product.CustomerId;
            ViewData["CreatedDate"] = product.CreatedDate;
            return View(productDto);
        }
        [HttpPost]
        public IActionResult Edit(string id,ProductDto productDto)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Dashboard");
            }
            if(!ModelState.IsValid)
            {
                ViewData["CustomerId"] = product.CustomerId;
                ViewData["CreatedDate"] = product.CreatedDate;
                return View(productDto);
            }
            product.Name = productDto.Name;
            product.Email = productDto.Email;
            product.Phone = productDto.Phone;
            product.Address = productDto.Address;
            product.Status = productDto.Status;
            context.SaveChanges(true);
            return RedirectToAction("Dashboard");
        }
        public ActionResult Details(string? id)
        {
            var product = context.Products.Find(id);
            if (id == null)
                return RedirectToAction("Details");
            else
            {
                ViewData["Name"] = product.Name;
                ViewData["Email"] = product.Email;
                ViewData["Phone"] = product.Phone;
                ViewData["Address"] = product.Address;
                ViewData["CreatedDate"] = product.CreatedDate;
                ViewData["Status"] = product.Status;
            }
            
            return View();
        }
        public IActionResult Delete(string id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Dashboard");
            }
            context.Products.Remove(product);
            context.SaveChanges(true);
            return RedirectToAction("Dashboard");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Customer user)
        {
                await context.Customers.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Dashboard");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
