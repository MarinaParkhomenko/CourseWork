using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    public class Hotel
    {
        public static readonly int Rooms = 12;
        public static readonly int[] Standart = { 0, 1, 2, 3 };
        public static readonly int[] Medium = { 4, 5, 6, 7 };
        public static readonly int[] Lux = { 8, 9, 10, 11 };

        public static Dictionary<int, Guest> Booked = new Dictionary<int, Guest>(Rooms);

        private Room[] HotelRooms = new Room[Rooms];

        public Hotel(int Rooms)
        {
            foreach (int i in Hotel.Standart)
            {
                HotelRooms[i] = new Room("Standart", i);
            }
            foreach (int i in Hotel.Medium)
            {
                HotelRooms[i] = new Room("Medium", i);
            }
            foreach (int i in Hotel.Lux)
            {
                HotelRooms[i] = new Room("Lux", i);
            }
        }

        public Room this[int index]
        {
            get
            {
                if (index < 0 || index > HotelRooms.GetUpperBound(0))
                    throw new IndexOutOfRangeException();
                return HotelRooms[index];
            }
        }
    }
}
