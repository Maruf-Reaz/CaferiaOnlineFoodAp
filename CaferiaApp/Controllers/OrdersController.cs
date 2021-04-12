using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaferiaApp.Data;
using CaferiaApp.Models;

namespace CaferiaApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders
               
                .Include(o => o.OrderItem)
                .ThenInclude(o => o.Item)
                .Include(o => o.ApplicationUser)
                .Include(o => o.Coupon)
                .Include(o => o.DeliveryBoy)
                .Where(j =>j.OrderStatus>=1);
            return View(await applicationDbContext.ToListAsync());
        }

       
    }
}
