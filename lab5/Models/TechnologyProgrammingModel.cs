using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace тп_2_лаба_4_семак.Models
{
    public class TechnologyProgrammingModel
    {
        [DisplayName("Название технологии")]
        public string TechnologyName { get; set; }

        [DisplayName("Язык программирования")]
        public string Language { get; set; }

        [DisplayName("Версия")]
        public double Version { get; set; }

        [DisplayName("Дата релиза")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Разработчик")]
        public string Developer { get; set; }

        [DisplayName("Открытый исходный код")]
        public bool IsOpenSource { get; set; }
    }
} 