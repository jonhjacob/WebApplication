using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class FootballController : Controller
    {
        public FootballController() {
		
		}

        private static List<Team> teams = new List<Team>();
		public void AddTeams (){
			teams.Add(new Team { id=1, coach = "Carlo Ancelotti", country = "Spain", teamname = "Real Madrid" });
			teams.Add(new Team { id=2,coach = "Jürgen Klopp", country = "Germany", teamname = "Liverpool FC" });
			teams.Add(new Team { id=3,coach = "Thomas Tuchel", country = "Germany", teamname = "Chelsea FC" });
            }	
        public IActionResult Welcome()
        {
          
            return View();
        }	

		public IActionResult Index()
        {

			return View(teams);
        }	
        
        public IActionResult MoreTeam(int ID)
        {
          Team theTeam = teams.Find(x =>x.id == ID);
            return View(theTeam);
        }
        public IActionResult AddNew()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(Team NewTeam)
        {
			//ModelState.IsValid ? 1 : 0;
			if (!ModelState.IsValid)
			{
				

				NewTeam.id = teams.Count() + 1;	
                teams.Add(NewTeam); 

				return RedirectToAction("Index");


			}
            return View();

		}

        public IActionResult EditTeam(int ID)
        {
            Team theTeam = teams.Find(x => x.id == ID);
            return View(theTeam);
        }
        [HttpPost]
        public IActionResult EditTeam(Team NewTeam)
        {
            //ModelState.IsValid ? 1 : 0;
            if (!ModelState.IsValid)
            {

                var oldTeam = teams.Find(x => x.id == NewTeam.id);
                oldTeam.teamname = NewTeam.teamname;
                oldTeam.country = NewTeam.country;  
                oldTeam.coach = NewTeam.coach;  

                return RedirectToAction("Index");


            }
            return View();

        }
        public IActionResult Delete(int ID) {
            Team theTeam = teams.Find(x => x.id == ID);

            return View(theTeam);


        }
        [HttpPost ,ActionName ("Delete")]
        public IActionResult aDelete(int ID) {
            Team theTeam = teams.Find(x => x.id == ID);

            teams.Remove(theTeam);
            return RedirectToAction("Index");
        }
    }
}
