using DalDemo.DAL;
using DalDemo.Interfaces;
using DalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDemo
{
    class Program
    {
        public List<Cat> Cats { get; set; }
        public IDAL DAL { get; set; }

        public Program(IDAL dal)
        {
            DAL = dal;
        }

        public void Run()
        {
            // Build some cats

            // Save the cats
            DAL.SaveCats(Cats);

            // get the cats

            // update cat and save the cat

            // remove a cat

            // get cats by color
        }

        static void Main(string[] args)
        {
            new Program(new FlatFileDAL()).Run();
        }
    }
}
