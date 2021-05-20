using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    public class Room
    {
        public int index;
        public decimal Price { get; }
        public int bookingdays { get; set; } = 0;
        public int rentdays { get; set; } = 0;

        public Room(string category, int index)
        {
            this.index = index;
            switch (category)
            {
                case "Standart":
                    Price = 700;
                    break;
                case "Medium":
                    Price = 900;
                    break;
                case "Lux":
                    Price = 1200;
                    break;
                default:
                    throw new Exception("Sorry, i dont understand)");
            }
        }

        public bool Booking()
        {
            return bookingdays > 0;
        }

        public bool Renting()
        {
            return rentdays > 0;
        }

        public void ToBook(int days)
        {
            if (!Booking())
                bookingdays = days;
        }


        public void ToRent(int days)
        {
            if (!Renting())
                rentdays = days;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Room {index + 1}");
            if (Price == 1200)
                Console.WriteLine($"Lux \n Price: {Price}. ");
            else if (Price == 900)
                Console.WriteLine($"Medium \n Price: {Price}. ");
            else
                Console.WriteLine($"Standart \n Price: {Price}. ");
            if (Booking())
            {
                Console.WriteLine($"The room is booked by {Hotel.Booked[index].Name}");

            }
            else if (Renting())
            {
                Console.WriteLine($"The room is rented by {Hotel.Booked[index].Name}");
            }


        }
    }

}
