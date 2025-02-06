using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases.Validaciones
{
    public class NumeroDecimalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string mensaje = "Debe ingresar un número válido";

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(mensaje);
            }
            else
            {
                decimal numero = 0;
                bool conversion = decimal.TryParse(value.ToString(), out numero);

                if (conversion)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(mensaje);
                }
            }
        }
    }
}
