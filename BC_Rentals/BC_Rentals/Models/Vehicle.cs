﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BC_Rentals.Models
{
    public class Vehicle
    {
        [Key]
        public int Vehicle_ID { get; set; }

        [Display(Name = "Manufacturer")]
        public string Vehicle_Manuf { get; set; }

        [Display(Name = "Model")]
        public string Vehicle_Model { get; set; }

        [Display(Name = "Colour")]
        public string Vehicle_Colour { get; set; }

        [Display(Name = "Plate Number")]
        public string Vehicle_Licence { get; set; }

        [Display(Name = "Cost Per Day")]
        public int Vehicle_Rate { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }



}