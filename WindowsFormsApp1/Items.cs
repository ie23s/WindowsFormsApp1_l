using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Items
    {
        public List<Movie> movies;

        public Items() {
            movies = new List<Movie>();
        }

        public void Add( Movie movie )
        {
            movies.Add(movie);
        }

        public void Add(String s)
        {
            String[] parms = s.Split(';');
            Movie m;
            if (parms[0].Equals("M"))
            {
                m = new Movie(parms[1], Int32.Parse(parms[2]), Int32.Parse(parms[3]), parms[4]);
            } else if(parms[0].Equals("C"))
            {
                m = new Cartoon(parms[1], Int32.Parse(parms[2]), Int32.Parse(parms[3]), parms[4], Int32.Parse(parms[5]));
            }
            else if (parms[0].Equals("S"))
            {
                m = new Series(parms[1], Int32.Parse(parms[2]), Int32.Parse(parms[3]), parms[4], Int32.Parse(parms[5]));
            } else
            {
                return;
            }
            movies.Add(m);
            
        }

        public void Remove(int index)
        {
            movies.RemoveAt(index);
        }

        public void Clear()
        {
            movies.Clear();
        }
    }
}
