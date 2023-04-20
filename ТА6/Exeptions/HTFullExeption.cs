using System;


namespace ТА6.Exeptions
{
    internal class HTFullExeption : ApplicationException
    {
        public override string Message
            => "Entity can`t be set - hash fuction cant give unique index;";
    }
}
