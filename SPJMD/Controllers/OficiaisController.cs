using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPJMD.Models;
using SPJMD.Models.Enums;

namespace SPJMD.Controllers
{
    public class OficiaisController : Controller
    {
        public IActionResult Index()
        {

            List<Oficial> lista = new List<Oficial>();
            lista.Add(new Oficial { Re = 123436, 
                Digito = "6", 
                Nome = "Eduardo Henrique Buzzo Lopes", 
                Posto = 0, 
                Email = "buzzo@gmail.com",});
            return View(lista);
        }
    }
}
