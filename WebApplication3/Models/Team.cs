namespace WebApplication3.Models
{ 
    public class Team :Player
    {
        public int id { get; set; }
        public string teamname { get; set; }
        public string country { get; set; }
        public string coach { get; set; }
        public List<Player> players { get; set; }

    }
}
