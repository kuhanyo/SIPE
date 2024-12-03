using Microsoft.AspNetCore.Mvc;
using SIPE.Models;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace SIPE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SQLHelper _sqlHelper;

        public HomeController(ILogger<HomeController> logger, SQLHelper sqlHelper)
        {
            _logger = logger;
            _sqlHelper = sqlHelper;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Index()
        {
            // Ejemplo de datos obtenidos desde la base de datos
            ViewData["PeriodoIngreso"] = "2021-1";
            ViewData["PeriodoEgreso"] = "2025-2";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetCountries()
        {
            var countries = new List<Country>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaPais");

            // Mapea el DataTable a una lista de países
            foreach (DataRow row in dt.Rows)
            {
                countries.Add(new Country
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(countries);
        }

        public IActionResult GetSexo()
        {
            var sexo = new List<Sexo>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaSexo");

            // Mapea el DataTable a una lista de países
            foreach (DataRow row in dt.Rows)
            {
                sexo.Add(new Sexo
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(sexo);
        }

    }
}
