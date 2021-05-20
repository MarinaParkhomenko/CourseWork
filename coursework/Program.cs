using System;
using System.Collections.Generic;

namespace Hotel
{

    class Program
    {
        public static void ToBookARoom(Hotel hotel, Guest guest)
        {
            int[] rooms = null;
            string category = "";
            Console.WriteLine("What type of room would you like to book?");
            Console.WriteLine("1 Standart");
            Console.WriteLine("2 Medium");
            Console.WriteLine("3 Lux");
            category = Console.ReadLine();
            switch(category)
            {
                case null:
                    Console.WriteLine("Sorry you did something wrong.");
                    break;
                case "1":
                    rooms = Hotel.Standart;
                    break;
                case "2":
                    rooms = Hotel.Medium;
                    break;
                case "3":
                    rooms = Hotel.Lux;
                    break;
                default:
                    throw new Exception();
            }
            Console.WriteLine("How many days are you planning to stay?");
            int day = Convert.ToInt32(Console.ReadLine());
            if (day <= 0)
                throw new Exception();
            decimal topay = day * hotel[rooms[0]].Price;
            Console.WriteLine($"To pay: {topay}.");
            Console.ReadKey();
            Console.WriteLine("*money*");
            Console.ReadKey();
            foreach (int r in rooms)
            if (guest.ToBook(day, hotel[r]))
            {
                Hotel.Booked.Add(r, guest);
                break;
            }
        }

        public static void ToRentARoom(Hotel hotel, Guest guest)
        {

            int[] rooms = null;
            foreach (KeyValuePair<int, Guest> Pair in Hotel.Booked)
            {

                if (Pair.Value.Name == guest.Name)
                {
                    DateTime time = DateTime.Now;
                    Console.WriteLine($"You have rented a room #{Pair.Key + 1}.");
                    guest = Pair.Value;
                    Console.WriteLine("How many days would you like to rent a room for?");
                    int days2 = Convert.ToInt32(Console.ReadLine());
                    DateTime date1 = time.AddDays(days2);
                    decimal topay1 = days2 * hotel[Pair.Key].Price;
                    Console.WriteLine($"To pay: {topay1}.");
                    Console.ReadKey();
                    Console.WriteLine("*money*");
                    Console.ReadKey();
                    //int paid1;
                    guest.ToRent(days2, hotel[Pair.Key]);
                    Hotel.Booked.Remove(Pair.Key);
                    break;
                }
            }
            if (guest != null)
            {
                //Console.WriteLine("Your age:");
                //int age = Convert.ToInt32(Console.ReadLine());
                //guest = new Guest(guest.Name, age);
                //tourist.Notify += DisplayMessage;
                string category;
                while (true)
                {
                    Console.WriteLine("What type of room would you like to book?");
                    Console.WriteLine("1 Standart");
                    Console.WriteLine("2 Medium");
                    Console.WriteLine("3 Lux");
                    category = Console.ReadLine();
                    switch (category)
                    {
                        case null:
                            Console.WriteLine("Sorry you did something wrong.");
                            break;
                        case "1":
                            rooms = Hotel.Standart;
                            break;
                        case "2":
                            rooms = Hotel.Medium;
                            break;
                        case "3":
                            rooms = Hotel.Lux;
                            break;
                        default:
                            throw new Exception();
                    }

                DateTime time = DateTime.Now;
                Console.WriteLine("How many days?");

                int days1 = Convert.ToInt32(Console.ReadLine());
                 if (days1 <= 0)
                      throw new Exception();
                DateTime date = time.AddDays(days1);
                decimal topay = days1 * hotel[rooms[0]].Price;
                Console.WriteLine($"To pay: {topay}.");
                Console.ReadKey();
                Console.WriteLine("*money*");
                Console.ReadKey();
                foreach (int r in rooms)
                    if (guest.ToRent(days1, hotel[r]))
                    {
                        Hotel.Booked.Add(r, guest);
                        break;
                    }
                }
            }
        }

        public static void RoomInfo(Hotel hotel)
        {
            Console.WriteLine("What room do you want to get information about? (from 1 to 12)");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n - 1 < 0 || n - 1 > 11)
                throw new IndexOutOfRangeException();
            hotel[n - 1].ShowInfo();
        }

        public static void GetCard()
        {
            Console.WriteLine("Please, enter guest's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please, enter guest's age");
            int age = Convert.ToInt32(Console.ReadLine());
            Guest guest = new Guest(name, age);



            foreach (KeyValuePair<int, Guest> Pair in Hotel.Booked)
            {

                if (Pair.Value.Name == guest.Name)
                {
                    guest.GetCard();
                    break;
                }
                else
                    throw new HotelException("Guest wasn't found");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Hotel hotel = new Hotel(Hotel.Rooms);

                string choice = "";

                Console.WriteLine("Please, enter guest's name: ");
                string name = Console.ReadLine();
                if (name == null )
                    throw new Exception("The name input is not correct.");
                Console.WriteLine("Please, enter guest's age");
                int age = Convert.ToInt32(Console.ReadLine());
                if (name == null)
                    throw new Exception("The age input is not correct.");
                Guest guest = new Guest(name, age);


                while (true)
                {
                    Console.WriteLine("Please, choose a number according to your purpose:");
                    Console.WriteLine("1. To book a room.");
                    Console.WriteLine("2. To rent a room now.");
                    Console.WriteLine("3. To display the information about hotel room.");
                    Console.WriteLine("4. To display guest's card");
                    Console.WriteLine("0. Exit");



                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ToBookARoom(hotel, guest);
                            break;
                        case "2":
                            ToRentARoom(hotel, guest);
                            break;
                        case "3":
                            RoomInfo(hotel);
                            break;
                        case "4":
                            GetCard();
                            break;
                        case "0":
                            return;
                        default:
                        throw new Exception();
                            
                    }

                }
            }
            catch(Exception)
            {
                throw new Exception("Error");
            }

        }

    }

}
