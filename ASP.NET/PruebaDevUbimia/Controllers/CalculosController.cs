using Microsoft.AspNetCore.Mvc;

namespace PruebaUbimia.Controllers
{
    public class CalculosController : Controller
    {
        // Vista principal
        public IActionResult Index()
        {
            return View();
        }

        // calcular factorial al enviar formulario
        [HttpPost]
        public IActionResult Calcular(int numero)
        {
            try
            {
                long resultado = CalcularFactorial(numero);
                ViewBag.Resultado = resultado;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Index");
        }

        // validaciones y lógica de cálculo factorial
        private long CalcularFactorial(int numero)
        {
            if (numero < 0)     
                throw new Exception("El número no puede ser negativo");

            if (numero > 25)   
                throw new Exception("El valor es demasiado grande para calcular el factorial");

            long factorial = 1;

            for (int i = 1; i <= numero; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        // ordenar 5 nùmeros
        [HttpPost]
        public IActionResult Ordenar(int n1, int n2, int n3, int n4, int n5)
        {
            int[] numeros = { n1, n2, n3, n4, n5 };

            OrdenarNumeros(numeros);

            ViewBag.NumerosOrdenados = numeros;

            return View("Index");
        }

        // lógica de orden
        private void OrdenarNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                for (int j = 0; j < numeros.Length - 1; j++)
                {
                    if (numeros[j] > numeros[j + 1])
                    {
                        int temp = numeros[j];
                        numeros[j] = numeros[j + 1];
                        numeros[j + 1] = temp;
                    }
                }
            }
        }

        // web service
        [HttpGet("api/factorial/{numero}")]
        public IActionResult ObtenerFactorial(int numero)
        {
            try
            {
                long resultado = CalcularFactorial(numero);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}