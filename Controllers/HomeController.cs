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
        public IActionResult GetIdioma()
        {
            var idiomas = new List<Idioma>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaIdioma");

            // Mapea el DataTable a una lista de países
            foreach (DataRow row in dt.Rows)
            {
                idiomas.Add(new Idioma
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(idiomas);
        }

        public IActionResult GetIdiomaNivel()
        {
            var idiomniveles = new List<IdiomaNivel>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaIdiomaNivel");

            // Mapea el DataTable a una lista de países
            foreach (DataRow row in dt.Rows)
            {
                idiomniveles.Add(new IdiomaNivel
                {
                    Nivel = row["Nivel"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(idiomniveles);
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

        public IActionResult GetEstadoCivil()
        {
            var estadocivil = new List<EstadoCivil>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaEstadoCivil");

            // Mapea el DataTable a una lista de los EstadoCiviles
            foreach (DataRow row in dt.Rows)
            {
                estadocivil.Add(new EstadoCivil
                {
                    Descripción = row["Descripción"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(estadocivil);
        }
        public IActionResult GetCapacidadEspecial()
        {
            var capacidadespecial = new List<CapacidadEspecial>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaCapacidadEspecial");

            // Mapea el DataTable a una lista de las CapacidadEspeciales
            foreach (DataRow row in dt.Rows)
            {
                capacidadespecial.Add(new CapacidadEspecial
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(capacidadespecial);
        }

        public IActionResult GetFacultad()
        {
            var facultad = new List<Facultad>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaFacultad");

            // Mapea el DataTable a una lista de las Facultades
            foreach (DataRow row in dt.Rows)
            {
                facultad.Add(new Facultad
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(facultad);
        }

        public IActionResult GetCarrera()
        {
            var carrera = new List<Carrera>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaCarrera");

            // Mapea el DataTable a una lista de las carreras
            foreach (DataRow row in dt.Rows)
            {
                carrera.Add(new Carrera
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(carrera);
        }

        public IActionResult GetCampus()
        {
            var campus = new List<Campus>();

            // Llama al stored procedure
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_ConsultaCampus");

            // Mapea el DataTable a una lista de los campus
            foreach (DataRow row in dt.Rows)
            {
                campus.Add(new Campus
                {
                    Nombre = row["Nombre"].ToString()
                });
            }

            // Retorna la lista de países como JSON
            return Json(campus);
        }
    }
}
