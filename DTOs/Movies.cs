using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Movies: BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string Genre { get; set; }

        public string Director {  get; set; }

    }
}
