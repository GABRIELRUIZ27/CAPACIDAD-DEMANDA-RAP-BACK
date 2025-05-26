using ClosedXML.Excel;
using GESTION_PAGOS;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PRUEBA_OPERATI.Entities;

namespace PRUEBA_OPERATI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenaceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CenaceController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("descargar-y-guardar")]
        public async Task<IActionResult> DescargarYGuardarDatos()
        {
            string filePath = await DescargarExcelConSelenium();
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                return BadRequest("No se pudo descargar el archivo o el archivo no existe.");

            var datos = LeerExcel(filePath);
            if (!datos.Any())
                return BadRequest("No se pudieron leer datos del archivo Excel.");

            _context.PotenciasParticipantes.AddRange(datos);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Datos guardados exitosamente", total = datos.Count });
        }

        private async Task<string> DescargarExcelConSelenium()
        {
            var options = new ChromeOptions();
            var downloadPath = Path.Combine(_env.ContentRootPath, "Downloads");

            if (!Directory.Exists(downloadPath))
                Directory.CreateDirectory(downloadPath);

            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");

            using var driver = new ChromeDriver(options);

            string url = "https://www.cenace.gob.mx/Docs/02_MBP/CapacidadDemandada/2024/Capacidad%20Demandada%20y%20RAP%20en%202024%20SIN%20(v2025%2001%2031).xlsx";
            driver.Navigate().GoToUrl(url);

            await Task.Delay(10000); 

            var archivoDescargado = Directory.GetFiles(downloadPath, "*.xlsx")
                .OrderByDescending(f => System.IO.File.GetCreationTime(f))
                .FirstOrDefault();

            return archivoDescargado;
        }

        private List<PotenciaParticipante> LeerExcel(string path)
        {
            var lista = new List<PotenciaParticipante>();

            using var workbook = new XLWorkbook(path);
            var worksheet = workbook.Worksheets.First();
            var rows = worksheet.RowsUsed().Skip(1); 

            foreach (var row in rows)
            {
                try
                {
                    var entidad = new PotenciaParticipante
                    {
                        ZonaPotencia = row.Cell(1).GetValue<string>(),
                        Participante = row.Cell(2).GetValue<string>(),
                        Subcuenta = row.Cell(3).GetValue<string>(),
                        CapacidadDemandadaMW = row.Cell(4).GetDouble(),
                        RequisitoAnualMWAnio = row.Cell(5).GetDouble(),
                        ValorRequisitoEficienteMWAnio = row.Cell(6).GetDouble()
                    };
                    lista.Add(entidad);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return lista;
        }
    }
}
