using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyApplication.Attributes;

public class TimeFormatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var timeString = value.ToString()!;
        
        // Check format pattern (HH:mm or H:mm)
        var pattern = @"^(\d{1,2}):(\d{2})$";
        var match = Regex.Match(timeString, pattern);
        
        if (!match.Success)
        {
            return new ValidationResult("รูปแบบเวลาไม่ถูกต้อง กรุณาใส่ในรูปแบบ HH:mm (เช่น 18:30)");
        }

        var hour = int.Parse(match.Groups[1].Value);
        var minute = int.Parse(match.Groups[2].Value);

        // Validate time values
        if (hour < 0 || hour > 23)
        {
            return new ValidationResult("ชั่วโมงต้องอยู่ระหว่าง 00-23");
        }

        if (minute < 0 || minute > 59)
        {
            return new ValidationResult("นาทีต้องอยู่ระหว่าง 00-59");
        }

        return ValidationResult.Success;
    }
}