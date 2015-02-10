using DalDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDemo.Models
{
    public class Cat
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public Color CatColor { get; set; }
        public int Age { get; set; }

        public Cat()
        {
            Id = nextId++;
        }
    }
}
