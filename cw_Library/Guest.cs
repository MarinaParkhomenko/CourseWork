using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    public class Guest : Person
    {

        public Guest(string name, int age) : base(name, age)
        { }



        public int RoomNum { get; set; }

        public bool ToBook(int days, Room room)
        {
            try
            {
                room.ToBook(days);
                RoomNum = room.index;
                Console.WriteLine($"Room #{RoomNum + 1} has been booked by {Name}");
                //Notify?.Invoke($"Room #{RoomNum} has been booked by {Name}");
                return true;
            }
            catch (HotelException)
            {
                return false;
            }
        }

        public bool ToRent(int days, Room room)
        {
            try
            {
                room.ToRent(days);
                RoomNum = room.index;
                Console.WriteLine($"Room #{RoomNum + 1} has been booked by {Name}");
                return true;
            }
            catch (HotelException)
            {
                return false;
            }
        }

        public void GetCard()
        {
            Console.WriteLine($"Guest {Name} is staying in the room #{RoomNum + 1}");
        }
    }
}
