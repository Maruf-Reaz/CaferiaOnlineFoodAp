using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models
{
    public class Reservasion
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

    }
}
