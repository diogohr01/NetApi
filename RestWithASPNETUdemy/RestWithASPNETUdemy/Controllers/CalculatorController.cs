﻿using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
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
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtration/{firstNumber}/{secondNumber}")]
        public IActionResult Subtration(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                  var subtration = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                  return Ok(subtration.ToString());
            }
            return BadRequest("Invalid Input");
        }    
        [HttpGet("division/{firstNumber}/{secondNumber}")]

        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                  var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                  return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }    
         [HttpGet("multiplication/{firstNumber}/{secondNumber}")]

        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                  var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                  return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }    
        [HttpGet("raiz/{strNumber}")]

        public IActionResult Raiz(string strNumber)
        {
            if(IsNumeric(strNumber)){
                  var raiz = Math.Sqrt((double)ConvertToDecimal(strNumber));
                  return Ok(raiz.ToString());
            }
            return BadRequest("Invalid input");
        }
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}