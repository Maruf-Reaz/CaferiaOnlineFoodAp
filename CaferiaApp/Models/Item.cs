using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Descripton { get; set; }

       

        public string PhotoName1 { get; set; }

        public int Status { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsInStock { get; set; }

        public int ItemCatagoryId { get; set; }
        public ItemCatagory ItemCatagory { get; set; }

    }
}
