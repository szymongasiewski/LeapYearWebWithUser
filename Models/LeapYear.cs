﻿using System.ComponentModel.DataAnnotations;

namespace LeapYearWebWithUser.Models
{
    public class LeapYear
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "{0} może zawierać jedynie liczby całkowite")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Year { get; set; }

        [Display(Name = "Imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} nie może przekraczać {1} znaków")]
        [RegularExpression("^[a-zA-ZąĄćĆęĘłŁńŃóÓśŚżŻźŹ]+$", ErrorMessage = "{0} może zawierać jedynie litery")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string? Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} nie może przekraczać {1} znaków")]
        [RegularExpression("^[a-zA-ZąĄćĆęĘłŁńŃóÓśŚżŻźŹ]+$", ErrorMessage = "{0} może zawierać jedynie litery")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string Surname { get; set; }

        public string? User { get; set; }

        public string IsLeapYear(int? year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return "";
            }

            return "nie";
        }
    }
}