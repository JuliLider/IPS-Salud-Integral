 using IPS.Models;
using IPSentity.Entity;
using IPSlogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IPS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PersonaLogic personaLogic = new PersonaLogic();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index(string nombre="")
        {
            List<PersonaEntity> listPersonaEntities = new List<PersonaEntity>();
            if (string.IsNullOrEmpty(nombre))
            {
                listPersonaEntities = personaLogic.GetAllPersona();
            }
            else
            {
                listPersonaEntities = personaLogic.GetAllPersona().Where(x => x.Nombres.ToUpper().Contains(nombre.ToUpper())).ToList();
            }
            return View(listPersonaEntities);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonaEntity personaEntity)
        {
            var persona = personaLogic.AddPersona(personaEntity);

            ViewBag.Message = persona.Message;
            ViewBag.Type = persona.Type;

            return View(personaEntity);
        }
    }
}
