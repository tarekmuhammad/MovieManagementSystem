using MovieSystem.Domain.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSystem.Domain.Entities.Commen
{
    public class Subscriptions
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public Users User { get; set; }

        public int packageId { get; set; }
        public Package package { get; set; }
 
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public PackgeType packgeType { get; set; }
        public double Cost { get; set; }
        [NotMapped]
        public Users user { get; set; }
        //public int PaymentId { get; set; }


    }
}
