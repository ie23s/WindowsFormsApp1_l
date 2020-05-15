namespace WindowsFormsApp1
{
    class Movie
    {
        protected string name;
        protected int durning;
        protected int year;
        protected string genre;

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
            return $"Movie {name} {d} {year} {genre}  ";

        }
    }
}
