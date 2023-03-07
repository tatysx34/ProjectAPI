using System;
namespace LibraryClass.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message)
            : base(message)
        { }
    }
}
