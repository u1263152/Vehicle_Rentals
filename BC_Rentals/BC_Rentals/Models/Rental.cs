using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BC_Rentals.Models
{
    public class Rental
    {
        [Key]
        public int Rental_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Vehicle_ID { get; set; }
        public DateTime Rental_Start { get; set; }
        public DateTime Rental_End { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}