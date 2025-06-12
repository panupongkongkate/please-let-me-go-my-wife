using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models;

public class RequestModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "กรุณาใส่ชื่อ")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "กรุณาเลือกวันที่")]
    public string Date { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "กรุณาใส่เวลา")]
    public string Time { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "กรุณาใส่สถานที่")]
    public string Place { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "กรุณาใส่เหตุผล")]
    public string Reason { get; set; } = string.Empty;
    
    public string Status { get; set; } = "รอ";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public class RequestDataModel
{
    public List<RequestModel> Requests { get; set; } = new();
    public int NextId { get; set; } = 1;
}