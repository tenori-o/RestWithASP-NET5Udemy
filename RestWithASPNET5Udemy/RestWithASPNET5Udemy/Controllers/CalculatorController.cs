using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal second = ConvertToDecimal(secondNumber);
                if (second == 0)
                {
                    return BadRequest("Can't divide by zero");
                }

                var value = ConvertToDecimal(firstNumber) / second;
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult Root(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var value = Math.Sqrt((double) ConvertToDecimal(firstNumber));
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string value)
        {
            double number;

            bool isNumber = double.TryParse(
                value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number
            );

            return isNumber;
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal number;

            if (decimal.TryParse(value, out number))
            {
                return number;
            }
            return 0;
        }

    }
}
