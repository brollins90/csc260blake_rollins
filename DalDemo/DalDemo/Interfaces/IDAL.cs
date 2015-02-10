using DalDemo.Enums;
using DalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDemo.Interfaces
{
    public interface IDAL
    {
        // save the cats collection
        bool SaveCats(IEnumerable<Cat> cats);

        // retrieve all the cats
        IEnumerable<Cat> GetCats();
        IEnumerable<Cat> GetCats(Func<Cat, bool> predicate);

        // retrieve cats by color
        IEnumerable<Cat> GetCats(Color color);
        
        // update a cat
        bool UpdateCat(Cat cat);

        // remove a cat
        bool DeleteCat(Cat cat);
        bool DeleteCat(int id);

        

    }
}
