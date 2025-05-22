using Microsoft.AspNetCore.Mvc;
using тп_2_лаба_4_семак.Models;
using System;

namespace тп_2_лаба_4_семак.Controllers
{
    public class TechnologyProgrammingController : Controller
    {
        // Массив для хранения экземпляров модели
        private static TechnologyProgrammingModel[] _technologies = new TechnologyProgrammingModel[10];
        private static int _count = 0;
        private static int _currentIndex = 0;

        // Просмотр текущего экземпляра
        public IActionResult Index()
        {
            var model = _technologies[_currentIndex];
            return View(model);
        }

        // Просмотр всех экземпляров
        public IActionResult List()
        {
            // Для примера: если текущая секунда чётная — используем внутренний, иначе внешний
            ViewData["UseInternalHelper"] = DateTime.Now.Second % 2 == 0;
            return View(_technologies);
        }

        // Добавление
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TechnologyProgrammingModel model)
        {
            if (ModelState.IsValid && _count < _technologies.Length)
            {
                _technologies[_count] = model;
                _currentIndex = _count;
                _count++;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Редактирование
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id < 0 || id >= _count)
                return NotFound();
            return View(_technologies[(int)id]);
        }

        [HttpPost]
        public IActionResult Edit(int id, TechnologyProgrammingModel model)
        {
            if (ModelState.IsValid && id >= 0 && id < _count)
            {
                _technologies[id] = model;
                _currentIndex = id;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Переключение между экземплярами
        public IActionResult Next()
        {
            if (_count == 0) return RedirectToAction("Index");
            _currentIndex = (_currentIndex + 1) % _count;
            return RedirectToAction("Index");
        }

        public IActionResult Previous()
        {
            if (_count == 0) return RedirectToAction("Index");
            _currentIndex = (_currentIndex - 1 + _count) % _count;
            return RedirectToAction("Index");
        }
    }
} 