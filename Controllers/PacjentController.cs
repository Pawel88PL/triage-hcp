using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class PacjentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Triage()
        {
            var pacjent = new Pacjent
            {
                Id = "1",
                Name = "Jan",
                Surname = "Kowalski",
                Age = "75",
                Gender = "Mężczyzna",
                Room = "WIT",
                Place_number = "1",
                Diagnosis = "duszący ból w klatce piersiowej, w EKG od ZRM STEMI",
                Color = "orange",
                Doctor = "Yes",
                Active = "Yes"
            };

            return View(pacjent);
        }

        public IActionResult List()
        {
            var pacjentList = new List<Pacjent>
            {
                new Pacjent
                {
                    Id = "1",
                    Name = "Jan",
                    Surname = "Kowalski",
                    Age = "75",
                    Gender = "Mężczyzna",
                    Room = "WIT",
                    Place_number = "1",
                    Diagnosis = "duszący ból w klatce piersiowej, w EKG od ZRM STEMI",
                    Color = "orange",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = "2",
                    Name= "Beata",
                    Surname = "Nowak",
                    Age = "59",
                    Gender ="Kobieta",
                    Room = "WITuś",
                    Place_number ="1",
                    Diagnosis = "kołatanie serca, migotanie przedsionków w wywiadzie",
                    Color ="yellow",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = "3",
                    Name = "Janina",
                    Surname = "Spychalska",
                    Age = "88",
                    Gender = "Kobieta",
                    Room = "OBS",
                    Place_number = "5",
                    Diagnosis = "złamanie kości szyjki udowej, bolesność, noga zrotowana",
                    Color = "green",
                    Doctor = "No",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = "4",
                    Name = "Kazimierz",
                    Surname = "Waligóra",
                    Age = "67",
                    Gender = "Mężczyzna",
                    Room = "Wituś",
                    Place_number = "3",
                    Diagnosis = "Trudności w oddychaniu od wczoraj, POCHP w wywiadzie",
                    Color = "yellow",
                    Doctor = "Yes",
                    Active = "No"
                }
            };

            return View(pacjentList);
        }   
    }
}

