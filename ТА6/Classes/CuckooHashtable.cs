using System;
using ТА6.Data;
using ТА6.Exeptions;

namespace ТА6.Classes
{
    internal class CuckooHashtable : DoubleHashtable
    {
        internal CuckooHashtable(int length) : base(length) { }

        internal override void Set(SurnameBirthData data)
        {
            int h1;
            int h2;
            var holder = data;
            int indexerHolder = DividingHF1(Translate(holder.surname)); ;
            for (int i = 0; i < table.Length; i++) 
            {
                h1 = DividingHF1(Translate(holder.surname));
                if (table[h1] == null)
                    { table[h1] = data; return; }
                
                h2 = DividingHF2(Translate(holder.surname));
                if (table[h2] == null)
                    { table[h2] = data; return; }

                indexerHolder = indexerHolder != h1 ? h1 : h2;
                var memory = holder;
                holder = table[h1];
                table[h1] = memory;
            }
            throw new HTFullExeption();
        }
        internal override SurnameBirthData Get(SurnameData data, out int index)
        {
            int h1 = DividingHF1(Translate(data.surname));
            int h2 = DividingHF2(Translate(data.surname));
            if (table[h1].surname == data.surname)
            { index = h1; return table[index]; }
            if (table[h2].surname == data.surname)
            { index = h2; return table[index]; }
            throw new HTNotFoundExeption();
        }
    }
}
