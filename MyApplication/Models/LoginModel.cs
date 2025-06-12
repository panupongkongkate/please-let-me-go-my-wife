using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models;

public class LoginModel
{
    [Required(ErrorMessage = "กรุณาใส่ชื่อผู้ใช้")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "กรุณาใส่รหัสผ่าน")]
    public string Password { get; set; } = string.Empty;
}