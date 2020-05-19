namespace WindowsFormsApp1
{
    public class Movie
    {
        protected string name;
        protected int durning;
        protected int year;
        protected string genre;
        protected int real_index = 0;

        public Movie(string Name, int Durning, int Year, string Genre)
        {
            this.name = Name;
            this.durning = Durning;
            this.year = Year;
            this.genre = Genre;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        public int Durning
        {
            get { return durning; }
            set { this.durning = value; }
        }
        public int Year
        {
            get { return year; }
            set { this.year = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { this.genre = value; }
        }
         
        protected string GetDurning()
        {
            return this.durning / 60 + ":" + (this.durning % 60).ToString("00");
        }

        public override string ToString()
        {
            string d = GetDurning();
            return $"Movie;{name};{d};{year};{genre}";

        }
        public virtual string ToFileString()
        {
            return $"M;{name};{durning};{year};{genre}";
        }

        public virtual string OwnType()
        {
            return "Movie";
        }

        public int Real_index
        {
            get { return real_index;  }
        }

        public Movie SetIndex(int i)
        {
            real_index = i;
            return this;
        }
    }
}
