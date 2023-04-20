using System;
using ТА6.Data;
using ТА6.Exeptions;


namespace ТА6.Classes
{
    internal class DoubleHashtable
    {
        internal SurnameBirthData[] table { get; }

        internal DoubleHashtable(int length) { table = new SurnameBirthData[length]; }

        internal virtual void Set(SurnameBirthData data)
        {
            int h1 = DividingHF1(Translate(data.surname));
            int h2 = DividingHF2(Translate(data.surname));
            for (int i = 0; i < table.Length; i++)  
            {
                int index = (h1 + i * h2) % table.Length;
                Console.WriteLine($"Trying to fit {data.surname} in {index} bucket");
                if (table[index] == null) 
                { 
                    table[index] = data;
                    return;
                }
            }
            throw new HTFullExeption();
        }
        internal virtual SurnameBirthData Get(SurnameData data, out int index)
        {
            int h1 = DividingHF1(Translate(data.surname));
            int h2 = DividingHF2(Translate(data.surname));
            for (int i = 0; i < table.Length; i++)
            {
                index = (h1 + i * h2) % table.Length;
                Console.WriteLine($"Trying to get {data.surname} from {index} bucket");
                if (table[index] == null) 
                {
                    throw new HTNotFoundExeption();
                }
                if (table[index].surname == data.surname)
                {
                    return table[index];
                }
            }
            throw new HTNotFoundExeption();
        }

        internal void Delete(SurnameData data) 
        {
            _ = Get(data, out int index);
            Console.WriteLine($"Trying to delete {data.surname} from {index} bucket");
            table[index] = null;
        }

        internal void Update(SurnameBirthData data)
        {
            SurnameData surname = new SurnameData() { surname = data.surname };
            _ = Get(surname, out int index);
            Console.WriteLine($"Trying to update {data.surname} from {index} bucket");
            table[index].dateOfBirth = data.dateOfBirth;
        }

        protected int Translate(string data) 
        {
            int res = 0;
            foreach (char letter in data) 
            {
                res += letter;
            }
            return res;
        }

        protected int DividingHF1(int key) 
        {
            return key % table.Length;
        }

        protected int DividingHF2(int key)
        {
            return key % (table.Length - 1) + 1;
        }
    }
}
