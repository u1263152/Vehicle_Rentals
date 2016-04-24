using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BC_Rentals.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace BC_Rentals.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleContext")
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }


}