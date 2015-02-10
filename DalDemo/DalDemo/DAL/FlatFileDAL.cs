using DalDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDemo.DAL
{
    public class FlatFileDAL : IDAL
    {
        public bool SaveCats(IEnumerable<Models.Cat> cats)
        {
            Console.WriteLine("I am saving all the cats");
            return true;
        }

        public IEnumerable<Models.Cat> GetCats()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Cat> GetCats(Func<Models.Cat, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Cat> GetCats(Enums.Color color)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCat(Models.Cat cat)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCat(Models.Cat cat)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCat(int id)
        {
            throw new NotImplementedException();
        }
    }
}
