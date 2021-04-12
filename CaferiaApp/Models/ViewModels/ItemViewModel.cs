using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Descripton { get; set; }

     

        public IFormFile Photo { get; set; }

        public string OldPhotoName { get; set; }

        public int Status { get; set; }

        public int ItemCatagoryId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsInStock { get; set; }
    }
}
