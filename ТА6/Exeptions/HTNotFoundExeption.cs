using System;


namespace ТА6.Exeptions
{
    internal class HTNotFoundExeption : Exception
    {
        public override string Message
            => "Entity not found";
    }
}
