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
using Microsoft.AspNetCore.Hosting;
using CaferiaApp.Models.ViewModels;
using CaferiaApp.Models.Common.File;

namespace CaferiaApp.Controllers
{
    public class ItemCatagoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemCatagoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: ItemCatagories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemCatagories.ToListAsync());
        }


        // GET: ItemCatagories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemCatagoryViewModel itemCatagoryViewModel)
        {

            var itmeCatagory = new ItemCatagory();
            itmeCatagory.Id = itemCatagoryViewModel.Id;
            itmeCatagory.Name = itemCatagoryViewModel.Name;
            itmeCatagory.Status = 0;

            string photo1 = "No File";
            if (itemCatagoryViewModel.Photo != null)
            {
                string uniqueFileName = null;
                string stringCutted = itemCatagoryViewModel.Photo.FileName.Split('.').Last();
                uniqueFileName = Guid.NewGuid().ToString() + "." + stringCutted;
                photo1 = uniqueFileName;
                InputFile fileUpload = new InputFile(_hostingEnvironment);
                fileUpload.Uploadfile("files/item_catagories", itemCatagoryViewModel.Photo, photo1);
            }
            itmeCatagory.PhotoName1 = photo1;

            _context.Add(itmeCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: ItemCatagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCatagory = await _context.ItemCatagories.FindAsync(id);

            var itemCatagoryViewModel = new ItemCatagoryViewModel();
            itemCatagoryViewModel.Id = itemCatagory.Id;
            itemCatagoryViewModel.Name = itemCatagory.Name;
            itemCatagoryViewModel.OldPhotoName = itemCatagory.PhotoName1;


            itemCatagoryViewModel.Status = itemCatagory.Status;


            if (itemCatagory == null)
            {
                return NotFound();
            }
            return View(itemCatagoryViewModel);
        }

        // POST: ItemCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemCatagoryViewModel itemCatagoryViewModel)
        {
            if (id != itemCatagoryViewModel.Id)
            {
                return NotFound();
            }
            var itemCatagory = new ItemCatagory();
            itemCatagory.Id = itemCatagoryViewModel.Id;
            itemCatagory.Name = itemCatagoryViewModel.Name;
            itemCatagory.Status = 0;
            
            InputFile fileUpload = new InputFile(_hostingEnvironment);
            itemCatagory.PhotoName1 = itemCatagoryViewModel.OldPhotoName;
            if (itemCatagoryViewModel.Photo != null)
            {
                string uniqueFileName = null;
                string stringCutted = itemCatagoryViewModel.Photo.FileName.Split('.').Last();
                uniqueFileName = Guid.NewGuid().ToString() + "." + stringCutted;
                itemCatagory.PhotoName1 = uniqueFileName;
                if (itemCatagoryViewModel.OldPhotoName.ToLower() == "no file")
                {
                    fileUpload.Uploadfile("files/item_catagories", itemCatagoryViewModel.Photo, uniqueFileName);
                }
                else
                {
                    fileUpload.Updatefile("files/item_catagories", itemCatagoryViewModel.Photo, itemCatagoryViewModel.OldPhotoName, uniqueFileName);
                }
            }

            try
            {
                _context.Update(itemCatagory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCatagoryExists(itemCatagory.Id))
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

        // GET: ItemCatagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCatagory = await _context.ItemCatagories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCatagory == null)
            {
                return NotFound();
            }

            return View(itemCatagory);
        }

        // POST: ItemCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCatagory = await _context.ItemCatagories.
                Include(m=>m.Items)
                .Where(m=> m.Id == id).FirstOrDefaultAsync();
            _context.ItemCatagories.Remove(itemCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCatagoryExists(int id)
        {
            return _context.ItemCatagories.Any(e => e.Id == id);
        }
        public async Task<IActionResult> ActivateItemCatagory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCatagory = await _context.ItemCatagories
                .FirstOrDefaultAsync(m => m.Id == id);


            if (itemCatagory == null)
            {
                return NotFound();
            }
            itemCatagory.Status = 1;
            _context.Update(itemCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeActivateItemCatagory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCatagory = await _context.ItemCatagories
                .FirstOrDefaultAsync(m => m.Id == id);


            if (itemCatagory == null)
            {
                return NotFound();
            }
            itemCatagory.Status = 0;
            _context.Update(itemCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
