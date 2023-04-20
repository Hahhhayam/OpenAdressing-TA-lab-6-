using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ТА6.Data;
using ТА6.Exeptions;
using ТА6.Classes;

namespace ТА6.Controller
{
    public class HTController
    {
        private DoubleHashtable hashtable;

        public HTController(bool lever) 
            :this(lever, 25) {}
        public HTController(bool lever, int length)
        {
            LengthData data = new LengthData() { length = length };
            var log = new List<ValidationResult>();
            if (!Validator.TryValidateObject(data, new ValidationContext(data), log, true))
            { throw new ValidatorExeption(log); }
            hashtable = !lever ? new DoubleHashtable(data.length) : new CuckooHashtable(data.length) ;
        }

        private SurnameBirthData ValidateSBData(string surname, DateTime dateOfBirth)
        {
            SurnameBirthData data = new SurnameBirthData() { surname = surname, dateOfBirth = dateOfBirth };
            var log = new List<ValidationResult>();
            if (!Validator.TryValidateObject(data, new ValidationContext(data), log, true))
            { throw new ValidatorExeption(log); }
            return data;
        }
        private SurnameData ValidateSData(string surname)
        {
            SurnameData data = new SurnameData() { surname = surname };
            var log = new List<ValidationResult>();
            if (!Validator.TryValidateObject(data, new ValidationContext(data), log, true))
            { throw new ValidatorExeption(log); }
            return data;
        }

        public void Set(string surname, DateTime dateOfBirth) 
        {
            var data = ValidateSBData(surname, dateOfBirth);
            hashtable.Set(data);
        }

        public SurnameBirthData Get(string surname)
        {
            var data = ValidateSData(surname);
            return hashtable.Get(data, out _);
        }

        public void Delete(string surname)
        {
            var data = ValidateSData(surname);
            hashtable.Delete(data);
        }

        public void Update(string surname, DateTime dateOfBirth) 
        {
            var data = ValidateSBData(surname, dateOfBirth);
            hashtable.Update(data);
        }

        public string GetTableLog() 
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in hashtable.table) 
            {
                if (item == null) 
                {
                    stringBuilder.Append("null\n");
                }
                else { stringBuilder.Append($"Surname: {item.surname}; Date: {item.dateOfBirth}\n"); }
            }
            return stringBuilder.ToString();
        }
    }
}
