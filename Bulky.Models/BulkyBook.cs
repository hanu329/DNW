using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class BulkyBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public int NoOfPages { get; set; }
        public string ImgUrl { get; set; }
        public int Rating { get; set; }
        public int Price { get; set; }

    }
}
