using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models.ViewModels
{
    public class ItemCatagoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public IFormFile Photo { get; set; }

        public string OldPhotoName { get; set; }
    }
}
