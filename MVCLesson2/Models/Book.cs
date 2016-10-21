using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MVCLesson2.Models;

[NotAllowedAttribute(ErrorMessage = "Недопустимая книга")]
public class Book : IValidatableObject
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле должно быть установлено")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
    [Display(Name = "Название")]
    [Remote("CheckName", "Home", ErrorMessage = "Name is not valid.")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Автор")]
    [MyAuthors(new string[] { "Л. Толстой", "А. Пушкин", "Ф. Достоевский", "И. Тургенев" }, ErrorMessage = "Недопустимый автор")]
    public string Author { get; set; }

    [Display(Name = "Год")]
    [Range(1700, 2000, ErrorMessage = "Недопустимый год")]
    public int Year { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(this.Name))
        {
            errors.Add(new ValidationResult("Введите название книги"));
        }
        if (string.IsNullOrWhiteSpace(this.Author))
        {
            errors.Add(new ValidationResult("Введите автора книги"));
        }
        if (this.Year == null || this.Year < 1700 || this.Year > 2000)
        {
            errors.Add(new ValidationResult("Недопустимый год"));
        }

        return errors;
    }

}