using System.ComponentModel.DataAnnotations;

namespace calculator.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Первое число обязательно для заполнения")]
        public short FirstNumber { get; set; }
        
        [Compare("FirstNumber", ErrorMessage = "Подтверждение должно совпадать с первым числом")]
        public short ConfirmFirstNumber { get; set; }

        [Required(ErrorMessage = "Второе число обязательно для заполнения")]
        public double SecondNumber { get; set; }

        public string Operation { get; set; }

        public double Result { get; set; }
    }
} 