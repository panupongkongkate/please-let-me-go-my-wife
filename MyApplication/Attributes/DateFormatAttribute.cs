using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MyApplication.Attributes;

public class DateFormatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var dateString = value.ToString()!;
        
        // Check format pattern (dd/MM/yyyy or dd/MM/yy)
        var pattern = @"^(\d{1,2})\/(\d{1,2})\/(\d{4}|\d{2})$";
        var match = Regex.Match(dateString, pattern);
        
        if (!match.Success)
        {
            return new ValidationResult("รูปแบบวันที่ไม่ถูกต้อง กรุณาใส่ในรูปแบบ dd/MM/yyyy (เช่น 25/12/2024)");
        }

        var day = int.Parse(match.Groups[1].Value);
        var month = int.Parse(match.Groups[2].Value);
        var year = int.Parse(match.Groups[3].Value);

        // Convert 2-digit year to 4-digit
        if (year < 100)
        {
            year += year < 50 ? 2000 : 1900;
        }

        // Validate date values
        if (month < 1 || month > 12)
        {
            return new ValidationResult("เดือนต้องอยู่ระหว่าง 1-12");
        }

        if (day < 1 || day > DateTime.DaysInMonth(year, month))
        {
            return new ValidationResult("วันที่ไม่ถูกต้องสำหรับเดือนนี้");
        }

        // Try to parse the date to ensure it's valid
        try
        {
            var date = new DateTime(year, month, day);
            return ValidationResult.Success;
        }
        catch
        {
            return new ValidationResult("วันที่ไม่ถูกต้อง");
        }
    }
}