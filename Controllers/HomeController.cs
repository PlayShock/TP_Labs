using Microsoft.AspNetCore.Mvc;
using calculator.Models;
using System.Diagnostics;

namespace calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model, string button)
        {
            if (button == "clear")
            {
                // Очистка полей калькулятора
                ModelState.Clear();
                return View(new CalculatorModel());
            }

            if (ModelState.IsValid)
            {
                switch (model.Operation)
                {
                    case "+":
                        model.Result = Convert.ToDouble(model.FirstNumber) + model.SecondNumber;
                        break;
                    case "-":
                        model.Result = Convert.ToDouble(model.FirstNumber) - model.SecondNumber;
                        break;
                    case "*":
                        model.Result = Convert.ToDouble(model.FirstNumber) * model.SecondNumber;
                        break;
                    case "/":
                        if (model.SecondNumber != 0)
                        {
                            model.Result = Convert.ToDouble(model.FirstNumber) / model.SecondNumber;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Деление на ноль невозможно!");
                            return View(model);
                        }
                        break;
                }

                // Для части II
                ViewBag.ExpectedResult = model.Result;

                // Сохраняем результат в сессии для части IV
                string resultString = $"{model.FirstNumber} {model.Operation} {model.SecondNumber} = {model.Result}";
                HttpContext.Session.SetString("CalculationResult", resultString);
            }

            return View(model);
        }

        public IActionResult Result()
        {
            string resultString = HttpContext.Session.GetString("CalculationResult");
            
            if (!string.IsNullOrEmpty(resultString))
            {
                // Обработка строки для части IV
                int lastIndexOfEquals = resultString.LastIndexOf('=');
                if (lastIndexOfEquals > 0)
                {
                    string operation = resultString.Substring(0, lastIndexOfEquals);
                    string result = resultString.Substring(lastIndexOfEquals + 1);
                    ViewBag.FormattedOperation = operation;
                    ViewBag.FormattedResult = result;
                }
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
