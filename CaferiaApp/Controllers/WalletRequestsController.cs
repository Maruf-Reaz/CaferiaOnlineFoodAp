using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaferiaApp.Data;
using CaferiaApp.Models;
using Microsoft.AspNetCore.Identity;
using CaferiaApp.Models.Common.Authentication;

namespace CaferiaApp.Controllers
{
    public class WalletRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WalletRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

      
        // GET: WalletRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WalletRequests.Include(w => w.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        

        public async Task<JsonResult> SaveRequest(string phoneNo, double requestAmount, string transactionId, string remarks)
        {
            WalletRequest walletRequest = new WalletRequest();
            walletRequest.Phone = phoneNo;
            walletRequest.RequestAmount = requestAmount;
            walletRequest.TransactionId = transactionId;
            walletRequest.Remarks = remarks;

            if (HttpContext.User.Identity.Name != null)
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                walletRequest.ApplicationUserId = loggedInUser.Id;
                
            }
            walletRequest.Status = 0;
            _context.Add(walletRequest);
            int result = await _context.SaveChangesAsync();


            if (result == 1)
            {

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> SaveContactUs(string name, string email, string subject, string phone,string message)
        {
            ContactUs contactUs = new ContactUs();
            contactUs.Name = name;
            contactUs.Email = email;
            contactUs.Phone = phone;
            contactUs.Subject = subject;
            contactUs.Message = message;

           
            _context.Add(contactUs);
            int result = await _context.SaveChangesAsync();


            if (result == 1)
            {

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> SaveReservasion(DateTime reservasionDate, DateTime reservasionTime, string name, string phone,string message)
        {
            Reservasion reservasion = new Reservasion();
            
            reservasion.Name = name;
            reservasion.Date = reservasionDate;
            reservasion.Phone = phone;
            reservasion.Time = reservasionTime;
            reservasion.Message = message;
            _context.Add(reservasion);
            int result = await _context.SaveChangesAsync();


            if (result == 1)
            {

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }





        // GET: WalletRequests
        public async Task<IActionResult> ContactUsIndex()
        {
            var applicationDbContext = _context.ContactUss;
            return View(await applicationDbContext.ToListAsync());
        }


           // GET: WalletRequests
        public async Task<IActionResult> ReservasionIndex()
        {
            var applicationDbContext = _context.Reservasions;
            return View(await applicationDbContext.ToListAsync());
        }





    }
}
