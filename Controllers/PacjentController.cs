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
                Id = 1,
                Name = "Jan",
                Surname = "Kowalski",
                Age = "75",
                Pesel = "48021478962",
                Gender = "Mężczyzna",
                Room = "WIT 1",
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
                    Id = 1,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Age = "75",
                    Pesel = "48021478962",
                    Gender = "Mężczyzna",
                    Room = "WIT 4",
                    Diagnosis = "duszący ból w klatce piersiowej, w EKG od ZRM STEMI",
                    Color = "orange",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 2,
                    Name= "Beata",
                    Surname = "Nowak",
                    Age = "59",
                    Pesel = "64033045612",
                    Gender ="Kobieta",
                    Room = "witus 2",
                    Diagnosis = "kołatanie serca, migotanie przedsionków w wywiadzie",
                    Color ="yellow",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 3,
                    Name = "Janina",
                    Surname = "Spychalska",
                    Age = "88",
                    Pesel = "35091112846",
                    Gender = "Kobieta",
                    Room = "OBS 5",
                    Diagnosis = "złamanie kości szyjki udowej, bolesność, noga zrotowana",
                    Color = "green",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 4,
                    Name = "Kazimierz",
                    Surname = "Waligóra",
                    Age = "67",
                    Pesel = "56110121547",
                    Gender = "Mężczyzna",
                    Room = "witus 1",
                    Diagnosis = "Trudności w oddychaniu od wczoraj, POCHP w wywiadzie",
                    Color = "yellow",
                    Doctor = "Yes",
                    Active = "No"
                },
                new Pacjent
                {
                    Id = 5,
                    Name = "Grażyna",
                    Surname = "Czarnecka",
                    Age = "53",
                    Pesel = "70071946579",
                    Gender = "Kobieta",
                    Room = "OBS 9",
                    Diagnosis = "Silny ból brzucha, wymioty, zawroty głowy, słaba",
                    Color = "yellow",
                    Doctor = "No",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 6,
                    Name = "Zbigniew",
                    Surname = "Domagała",
                    Age = "77",
                    Pesel = "46102858964",
                    Gender = "Mężczyzna",
                    Room = "WIT 1",
                    Diagnosis = "NZK w trakcie RKO przez ZRM, na Lucasie",
                    Color = "red",
                    Doctor = "Yes",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 7,
                    Name = "Agnieszka",
                    Surname = "Nowakowska",
                    Age = "43",
                    Pesel = "80102858964",
                    Gender = "Kobieta",
                    Room = "korytarz",
                    Diagnosis = "uraz PKD w okolicy stawu skokowego, poczuła jak coś chrupnęło w stopie",
                    Color = "green",
                    Doctor = "No",
                    Active = "Yes"
                },
                new Pacjent
                {
                    Id = 8,
                    Name = "Justyna",
                    Surname = "Kalinowska",
                    Age = "21",
                    Pesel = "03172858964",
                    Gender = "Kobieta",
                    Room = "poczekalnia",
                    Diagnosis = "rana do szycia palca III LKG, przecięła się nożem podczas krojenia cebuli",
                    Color = "green",
                    Doctor = "No",
                    Active = "Yes"
                }
            };

            return View(pacjentList);
        }

        public IActionResult Data()
        {
            ViewBag.Name = "Zbigniew";
            ViewData["Surname"] = "Stonoga";
            TempData["Age"] = "65";
            return View();
        }
    }
}

