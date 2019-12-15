using System;
using Business;

namespace TripPlanner
{
    public class Customer
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
        public DateTime FirstAccomodation { get; set; }

        public Customer() { }

        public Customer(string line)
        {
            var values = line.Split(',');


            Id = Int32.Parse(values[0]);
            FirstName = values[1];
            LastName = values[2];
            Email = values[3];
            Gender = values[4];
            City = values[5];
            Country = values[6];
            Phone = values[7];
            FirstAccomodation = DateTime.Parse(values[8], System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

        }


        public static Customer Parse(string line){
           
            var values = line.Split(',');

            Customer customer = new Customer(line);
            customer.Id = Int32.Parse(values[0]);
            customer.FirstName = values[1];
            customer.LastName = values[2];
            customer.Email = values[3];
            customer.Gender = values[4];
            customer.City = values[5];
            customer.Country = values[6];
            customer.Phone = values[7];
            customer.FirstAccomodation = DateTime.Parse(values[8], System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

            return customer;
        }

      
    }
}
