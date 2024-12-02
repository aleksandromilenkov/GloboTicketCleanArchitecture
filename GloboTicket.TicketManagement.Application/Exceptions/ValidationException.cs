using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(FluentValidation.Results.ValidationResult validationResult) { 
            ValidationErrors = new List<string>();
            foreach(var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
