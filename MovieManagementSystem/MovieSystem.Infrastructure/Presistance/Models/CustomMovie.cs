using MovieSystem.Domain.Entities.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class CustomMovie:Movie
    {
        public ICollection<Models.UserMovie> UserMovie { get; set; }
    }
}
