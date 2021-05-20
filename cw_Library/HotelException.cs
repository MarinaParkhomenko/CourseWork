using System;

namespace Hotel
{
    public class HotelException : Exception
    {
        public HotelException(string message) : base(message)
        { }
    }
}
