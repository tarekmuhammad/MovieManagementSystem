using MovieSystem.Domain.Entities.Commen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Users= MovieSystem.Domain.Entities.Commen ;

namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class UserMovie : Users.UserMovie
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
      
    }

    
}
