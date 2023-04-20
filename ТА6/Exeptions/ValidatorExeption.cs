using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ТА6.Exeptions
{
    internal class ValidatorExeption : ApplicationException
    {
        public readonly string message;
        public ValidatorExeption(List<ValidationResult> log)
        {
            this.message = string.Join("; ", log);
        }
        public override string Message
            => message;
    }
}
