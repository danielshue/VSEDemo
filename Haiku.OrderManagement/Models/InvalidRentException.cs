namespace Models
{
    using System;

    public class InvalidOrderException : Exception
    {
        public InvalidOrderException() { }
        public InvalidOrderException(
            string message) : base(message) { }
    }
}
