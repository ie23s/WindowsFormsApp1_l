using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cartoon : Movie
    {
        private int age;
        public Cartoon(string Name, int Durning, int Year, string Genre, int age) : base(Name, Durning, Year, Genre)
        {
            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set { this.age = value; }
        }


        public override string ToString()
        {
            String d = GetDurning();
            return $"Cartoon;{name};{d};{year};{genre};{age}";

        }
        public override string ToFileString()
        {
            return $"C;{name};{durning};{year};{genre};{age}";
        }
        public override string OwnType()
        {
            return "Cartoon";
        }
    }
}
