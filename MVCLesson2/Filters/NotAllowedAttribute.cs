using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLesson2.Models
{
    public class NotAllowedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Book b = value as Book;
            if (b.Name == "Преступление и наказание" && b.Author == "Ф. Достоевский" && b.Year == 1866)
            {
                return false;
            }
            return true;
        }
    }
}