using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("test/{parametro}/id/{idGenerico}")]
        public IEnumerable<WeatherForecast> Get([FromRoute(Name = "parametro")] string nombre, int idGenerico = 1000)
        {
            
            var rng = new Random();
            return Enumerable.Range(1, 2).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("example01/{enabled}")]
        public IEnumerable<WeatherForecast> testExample01(
                [FromRoute] bool enabled,
                [FromQuery] int ci, 
                [FromQuery] string nombreCompleto)
        {
            var rng = new Random();
            int init = 1; int fin;
            if (enabled)
            {
                fin = 100;
            } else
            {
                fin = 3;
            }
            return Enumerable.Range(init, fin).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                nombreCompleto = nombreCompleto.Substring(1, 3),
                numeroCi = ci * 1000
            })
            .ToArray();
        }

        [HttpPost]
        [Route("example02")]
        public IEnumerable<Producto> testExample02([FromBody] Cliente cliente)
        {
            var rng = new Random();
            return Enumerable.Range(1, 6).Select(index => new Producto
            {
                codProducto = rng.Next(1000, 10000),
                nombre = $"Producto-{(index + 1) * 1000}",
                vigente = Convert.ToBoolean(1 - rng.Next(2)),
                clienteAsociado = cliente.nombre
            })
            .ToArray();
        }
    }
}
