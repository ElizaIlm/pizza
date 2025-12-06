using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eliza13pr.Classes
{
    public class Dish
    {
        public int id;
        public string name;
        public List<Sizes> sizes = new List<Sizes> { };
        public string img;
        public List<Ingredient> ingredients = new List<Ingredient> { };
        public int activeSize = 0;
        public string description;
        public class Sizes
        {
            public int id;
            public int id_size;
            public int price;
            public int size;
            public int wes;
            public int countOrder;
            public bool orders;
        }
        public class Ingredient
        {
            public int id;
            public string name;
            public int price;
            public int wes;
            public string img;
            public int count;

        }

    }
}
