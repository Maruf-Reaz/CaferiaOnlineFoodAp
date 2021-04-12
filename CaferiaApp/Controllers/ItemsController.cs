using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaferiaApp.Data;
using CaferiaApp.Models;
using CaferiaApp.Models.ViewModels;
using CaferiaApp.Models.Common.File;
using Microsoft.AspNetCore.Identity;
using CaferiaApp.Models.Common.Authentication;
using Microsoft.AspNetCore.Hosting;

namespace CaferiaApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }


        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ItemCatagoryId"] = new SelectList(_context.ItemCatagories.Where(m => m.Status == 1), "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel itemViewModel)
        {
            var item = new Item();
            item.Id = itemViewModel.Id;
            item.Name = itemViewModel.Name;
            item.Price = itemViewModel.Price;
            item.Descripton = itemViewModel.Descripton;

            item.IsFeatured = itemViewModel.IsFeatured;
            item.IsInStock = itemViewModel.IsInStock;
            item.ItemCatagoryId = itemViewModel.ItemCatagoryId;
            item.Status = 0;

            string photo1 = "No File";
            if (itemViewModel.Photo != null)
            {
                string uniqueFileName = null;
                string stringCutted = itemViewModel.Photo.FileName.Split('.').Last();
                uniqueFileName = Guid.NewGuid().ToString() + "." + stringCutted;
                photo1 = uniqueFileName;
                InputFile fileUpload = new InputFile(_hostingEnvironment);
                fileUpload.Uploadfile("files/items", itemViewModel.Photo, photo1);
            }
            item.PhotoName1 = photo1;


            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripton,HasOption1,HasOption2,HasOption3,Option1Name,Option2Name,Option3Name,Option1Price,Option2Price,Option3Price,PhotoName1,Status,IsFeatured")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ActivateItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);


            if (item == null)
            {
                return NotFound();
            }
            item.Status = 1;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeActivateItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);


            if (item == null)
            {
                return NotFound();
            }
            item.Status = 0;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<JsonResult> AddToCart(int itemId, int quantity, string uniqueToken)
        {
            CartItem cartItem = new CartItem();
            cartItem.ItemId = itemId;
            cartItem.Quantity = quantity;
            cartItem.UniqueToken = uniqueToken;

            var tempCartItem = await _context.CartItems.Where(m => m.UniqueToken == uniqueToken && m.ItemId == itemId).FirstOrDefaultAsync();
            if (tempCartItem == null)
            {
                _context.Add(cartItem);
            }
            else
            {
                tempCartItem.Quantity += 1;
                _context.Update(tempCartItem);

            }

            int result = await _context.SaveChangesAsync();
            if (result == 1)
            {
                CartViewModel cartViewModel = new CartViewModel();
                cartViewModel.CartItems = await _context.CartItems.Include(m => m.Item).Where(m => m.UniqueToken == uniqueToken).ToListAsync();
                cartViewModel.Result = true;

                return Json(cartViewModel);
            }
            else
            {
                CartViewModel cartViewModel = new CartViewModel();
                cartViewModel.CartItems = await _context.CartItems.Include(m => m.Item).Where(m => m.UniqueToken == uniqueToken).ToListAsync();
                return Json(cartViewModel);
            }

        }
        [HttpPost]
        public async Task<JsonResult> GetCartData(string uniqueToken)
        {
            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.CartItems = await _context.CartItems.Include(m => m.Item).Where(m => m.UniqueToken == uniqueToken).ToListAsync();
            return Json(cartViewModel);

        }

        [HttpPost]
        public async Task<JsonResult> PlusToCart(int cartItemId)
        {
            var cartItem = await _context.CartItems.Where(m => m.Id == cartItemId).FirstOrDefaultAsync();

            cartItem.Quantity += 1;
            _context.Update(cartItem);
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

        [HttpPost]
        public async Task<JsonResult> MinusToCart(int cartItemId)
        {
            var cartItem = await _context.CartItems.Where(m => m.Id == cartItemId).FirstOrDefaultAsync();

            cartItem.Quantity -= 1;
            _context.Update(cartItem);
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

        [HttpPost]
        public async Task<JsonResult> RemoveFromCart(int cartItemId)
        {
            var cartItem = await _context.CartItems.Where(m => m.Id == cartItemId).FirstOrDefaultAsync();

            _context.Remove(cartItem);
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




        public async Task<JsonResult> GetCartTotalItem(string uniqueToken)
        {
            CartViewModel cartViewModel = new CartViewModel();
            var cartItems = await _context.CartItems.Include(m => m.Item).Where(m => m.UniqueToken == uniqueToken).ToListAsync();

            double totalAmount = 0;
            foreach (var cartItem in cartItems)
            {
                totalAmount += (cartItem.Item.Price * cartItem.Quantity);
            }

            cartViewModel.CartTotalItem = cartItems.Count;
            cartViewModel.CartTotalAmount = totalAmount;

            if (HttpContext.User.Identity.Name != null)
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                cartViewModel.WalletBalance = loggedInUser.Balance;
            }

            return Json(cartViewModel);

        }
        public async Task<JsonResult> CheckBalance(int orderId)
        {
            var order = await _context.Orders.Where(m => m.Id == orderId).FirstOrDefaultAsync();
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (loggedInUser.Balance > order.TotalAmount)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> ConfirmOrder(int orderId, int payType, string special_intruction)
        {
            var order = await _context.Orders.Include(m => m.ApplicationUser).Where(m => m.Id == orderId).FirstOrDefaultAsync();
            //order.OrderStatus = 1;
            //order.PaymentStatus = 1;
            order.OrderType = payType;
            order.Remarks = special_intruction;
            _context.Update(order);
            int result = await _context.SaveChangesAsync();



            if (result == 1)
            {
                CartViewModel cartViewModel = new CartViewModel();
                cartViewModel.Order = order;
                return Json(cartViewModel);
            }
            else
            {
                return Json(null);
            }
        }

        public async Task<JsonResult> FinalizeOrder(int orderId)
        {
            var order = await _context.Orders.Include(m => m.ApplicationUser).Where(m => m.Id == orderId).FirstOrDefaultAsync();
            order.OrderStatus = 1;
            order.PaymentStatus = 1;
            _context.Update(order);
            int result = await _context.SaveChangesAsync();
            

            if (result == 1)
            {
               
                return Json(order);
            }
            else
            {
                return Json(null);
            }
        }



        public async Task<JsonResult> SaveOrder(string uniqueToken,string contact, int orderId,string latitude,string longitude,DateTime pickupDate ,string pickupTime , int deliveryType)
        {
            Order order = new Order();

            
            order.ContactNo = contact;
            order.Latitiude = latitude;
            order.Longitude = longitude;
            order.OrderDate = DateTime.Now.Date;
            order.DelivaryType = deliveryType;
            order.PickUpDate = pickupDate;
            order.PickUpTime = pickupTime;
            
            order.OrderStatus = 0;
            order.PaymentStatus = 0;
            if (HttpContext.User.Identity.Name != null)
            {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

                order.ApplicationUser = loggedInUser;
                var cartItems = await _context.CartItems.Include(m => m.Item).Where(m => m.UniqueToken == uniqueToken).ToListAsync();

                if (cartItems.Count != 0)
                {


                    _context.Add(order);
                    int result = await _context.SaveChangesAsync();
                    if (result == 1)
                    {
                        double totalAmount = 0;
                        foreach (var cartItem in cartItems)
                        {
                            OrderItem orderItem = new OrderItem();
                            orderItem.ItemId = cartItem.ItemId;
                            orderItem.Item = cartItem.Item;
                            orderItem.OrderId = order.Id;
                            orderItem.Order = order;
                            orderItem.Quantity = cartItem.Quantity;

                            _context.Add(orderItem);
                            int result1 = await _context.SaveChangesAsync();
                            totalAmount += (cartItem.Item.Price * cartItem.Quantity);
                        }

                        order.TotalAmount = totalAmount;
                        order.NetPayable = totalAmount;
                        order.OrderNumber = "Order0000" + order.Id;
                        _context.Update(order);
                        await _context.SaveChangesAsync();
                        CartViewModel cartViewModel = new CartViewModel();
                        cartViewModel.OrderId = order.Id;
                        cartViewModel.WalletBalance = loggedInUser.Balance;

                        return Json(cartViewModel);

                    }
                    else
                    {
                        return Json(null);
                    }

                }
                else
                {
                    return Json(false);
                }

            }
            else
            {
                return Json(false);
            }

        }

    }
}
