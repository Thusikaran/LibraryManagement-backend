using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class BookDto
    {
         public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Author { get; set; }
        public string? Description { get; set; }
    }
}