using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaferiaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CaferiaApp.Data;
using CaferiaApp.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaferiaApp.Models.Common.Authentication;

namespace CaferiaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        //[Authorize(Roles = "GateAdmin, HarbourAndMarine, Mechanical, Admin, TMOffice")]
        public async Task<IActionResult> Index()
        {
            var user = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)); //same thing
            if (await _userManager.IsInRoleAsync(user, "DataOperator"))
            {

                ViewData["IsAdmin"] = true;


            }
            else if (await _userManager.IsInRoleAsync(user, "Manager"))
            {

                ViewData["IsAdmin"] = false;
            }
            else
            {
                ViewData["IsAdmin"] = true;
            }
            return View();
        }
        public async Task<IActionResult> Public()
        {
            var itemCatagories =await _context.ItemCatagories.Where(m => m.Status == 1).ToListAsync();
            var items =await _context.Items
                .Include(m=> m.ItemCatagory)
                .Where(m => m.Status == 1).ToListAsync();

            if (HttpContext.User.Identity.Name != null)
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                var orderItems = await _context.OrderItem.Include(m=>m.Item).Include(m=>m.Order).Where(m=>m.Order.OrderStatus==1).ToListAsync();
                ViewData["User"] = loggedInUser;
                ViewData["OrderItems"] = orderItems;
            }
            else
            {
                ViewData["User"] = null;
            }
           
            ViewData["ItemCatagories"] = itemCatagories;
            ViewData["Items"] = items;




            return View();
        }

         public async Task<IActionResult> OrderConfirmed(int orderId)
        {
            var order = await _context.Orders.Where(m => m.Id == orderId).FirstOrDefaultAsync();

            if (HttpContext.User.Identity.Name != null)
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

                if (order.ApplicationUserId == loggedInUser.Id)
                {
                    ViewData["Order"] = order;
                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

           
        }





        public IActionResult AssignmentData(DateTime getDate, DateTime fromDate)
        {
            if (fromDate == default(DateTime))
            {
                fromDate = DateTime.Now.Date;
            }

            ViewData["Date"] = fromDate.Date;
            return View();
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
