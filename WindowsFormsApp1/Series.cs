using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Series : Movie
    {
        private int seasons;
        public Series(string Name, int Durning, int Year, string Genre, int seasons) : base(Name, Durning, Year, Genre)
        {
            this.seasons = seasons;
        }

        public int Seasons
        {
            get { return seasons; }
            set { this.seasons = value; }
        }
        public override string ToString()
        {
            String d = GetDurning();
            return $"Series {name} {d} {year} {genre} {seasons}";

        }
    }
}
