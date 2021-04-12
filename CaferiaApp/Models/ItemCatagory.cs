using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models
{
    public class ItemCatagory
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Status { get; set; }
        public string PhotoName1 { get; set; }
        public List<Item> Items { get; set; }
    }
}
