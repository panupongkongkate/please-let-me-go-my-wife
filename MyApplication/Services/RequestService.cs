using MyApplication.Models;
using System.Text.Json;

namespace MyApplication.Services;

public class RequestService
{
    private readonly string _dataFilePath = "Data/requests.json";
    private List<RequestModel> _requests = new();
    private int _nextId = 51;

    public RequestService()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        // สร้างโฟลเดอร์ Data ถ้าไม่มี
        var dataDir = Path.GetDirectoryName(_dataFilePath);
        if (!string.IsNullOrEmpty(dataDir) && !Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // โหลดข้อมูลจากไฟล์ หรือสร้างข้อมูลเริ่มต้น
        if (File.Exists(_dataFilePath))
        {
            LoadFromFile();
        }
        else
        {
            CreateInitialData();
            SaveToFile();
        }
    }

    private void LoadFromFile()
    {
        try
        {
            var jsonContent = File.ReadAllText(_dataFilePath);
            var data = JsonSerializer.Deserialize<RequestDataModel>(jsonContent);
            if (data != null)
            {
                _requests = data.Requests ?? new List<RequestModel>();
                _nextId = data.NextId;
            }
        }
        catch
        {
            // ถ้าอ่านไฟล์ไม่ได้ ให้สร้างข้อมูลเริ่มต้น
            CreateInitialData();
            SaveToFile();
        }
    }

    private void SaveToFile()
    {
        try
        {
            var data = new RequestDataModel
            {
                Requests = _requests,
                NextId = _nextId
            };
            var jsonContent = JsonSerializer.Serialize(data, new JsonSerializerOptions 
            { 
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(_dataFilePath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    private void CreateInitialData()
    {
        _requests = new List<RequestModel>
        {
            // วัยวาย (สามีหลัก)
            new RequestModel { Id = 1, Name = "วัยวาย", Date = "2025-06-15", Time = "18:00", Place = "ร้านหมูกระทะ", Reason = "นัดเพื่อนเก่าสมัยมัธยม", Status = "รอ", CreatedDate = new DateTime(2025, 6, 14, 10, 0, 0) },
            new RequestModel { Id = 2, Name = "วัยวาย", Date = "2025-06-14", Time = "17:30", Place = "ร้านลาบแซ่บ", Reason = "เลี้ยงวันเกิดเพื่อน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 13, 15, 30, 0) },
            new RequestModel { Id = 3, Name = "วัยวาย", Date = "2025-06-13", Time = "19:00", Place = "ร้านเหล้า", Reason = "เจอเพื่อนสมัยประถม", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 12, 8, 20, 0) },
            new RequestModel { Id = 4, Name = "วัยวาย", Date = "2025-06-12", Time = "20:00", Place = "คาราโอเกะ", Reason = "ปาร์ตี้ของบริษัท", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 11, 12, 0, 0) },
            new RequestModel { Id = 5, Name = "วัยวาย", Date = "2025-06-11", Time = "18:30", Place = "ร้านกาแฟ", Reason = "ประชุมโปรเจกต์", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 10, 9, 15, 0) },
            new RequestModel { Id = 6, Name = "วัยวาย", Date = "2025-06-10", Time = "19:30", Place = "สนามฟุตบอล", Reason = "เล่นบอลกับเพื่อน", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 9, 14, 45, 0) },
            new RequestModel { Id = 7, Name = "วัยวาย", Date = "2025-06-09", Time = "17:00", Place = "ห้างสรรพสินค้า", Reason = "ซื้อของขวัญวันเกิดเมีย", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 8, 11, 30, 0) },
            new RequestModel { Id = 8, Name = "วัยวาย", Date = "2025-06-08", Time = "20:30", Place = "ร้านบาร์", Reason = "ดื่มเหล้ากับลูกค้า", Status = "รอ", CreatedDate = new DateTime(2025, 6, 7, 16, 20, 0) },
            new RequestModel { Id = 9, Name = "วัยวาย", Date = "2025-06-07", Time = "18:15", Place = "สปาเท้า", Reason = "ผ่อนคลายความเครียด", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 6, 13, 10, 0) },
            new RequestModel { Id = 10, Name = "วัยวาย", Date = "2025-06-06", Time = "19:45", Place = "โรงภาพยนตร์", Reason = "ดูหนังกับเพื่อนร่วมงาน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 5, 10, 50, 0) },
            
            // แขกบ้าน
            new RequestModel { Id = 11, Name = "แขกบ้าน", Date = "2025-06-16", Time = "20:00", Place = "ร้านบาร์บีคิว", Reason = "ปาร์ตี้วันเกิด", Status = "รอ", CreatedDate = new DateTime(2025, 6, 15, 12, 0, 0) },
            new RequestModel { Id = 12, Name = "แขกบ้าน", Date = "2025-06-15", Time = "18:30", Place = "ร้านอาหารญี่ปุ่น", Reason = "ทานข้าวกับคู่ธุรกิจ", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 14, 9, 20, 0) },
            new RequestModel { Id = 13, Name = "แขกบ้าน", Date = "2025-06-14", Time = "19:15", Place = "สนามกอล์ฟ", Reason = "เล่นกอล์ฟกับเจ้านาย", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 13, 14, 35, 0) },
            new RequestModel { Id = 14, Name = "แขกบ้าน", Date = "2025-06-13", Time = "17:45", Place = "ร้านชาบู", Reason = "ทานข้าวเลี้ยงลูกน้อง", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 12, 11, 25, 0) },
            new RequestModel { Id = 15, Name = "แขกบ้าน", Date = "2025-06-12", Time = "20:15", Place = "ผับ", Reason = "ดื่มกับเพื่อนเก่า", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 11, 15, 40, 0) },
            
            // เพิ่มชื่อใหม่: สมชาย
            new RequestModel { Id = 16, Name = "สมชาย", Date = "2025-06-17", Time = "18:00", Place = "ร้านส้มตำ", Reason = "กินข้าวกับเพื่อนที่มาจากต่างจังหวัด", Status = "รอ", CreatedDate = new DateTime(2025, 6, 16, 10, 15, 0) },
            new RequestModel { Id = 17, Name = "สมชาย", Date = "2025-06-16", Time = "19:30", Place = "ร้านเหล้าไทย", Reason = "งานเลี้ยงรุ่น", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 15, 8, 45, 0) },
            new RequestModel { Id = 18, Name = "สมชาย", Date = "2025-06-15", Time = "17:15", Place = "คาเฟ่", Reason = "ประชุมทีมงาน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 14, 13, 20, 0) },
            new RequestModel { Id = 19, Name = "สมชาย", Date = "2025-06-14", Time = "20:45", Place = "สระน้ำ", Reason = "ว่ายน้ำออกกำลังกาย", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 13, 16, 30, 0) },
            new RequestModel { Id = 20, Name = "สมชาย", Date = "2025-06-13", Time = "18:20", Place = "ร้านก่วยเตี๋ยว", Reason = "กินข้าวกับน้อง", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 12, 12, 10, 0) },
            
            // เพิ่มชื่อใหม่: สมศักดิ์
            new RequestModel { Id = 21, Name = "สมศักดิ์", Date = "2025-06-18", Time = "19:00", Place = "สนามเทนนิส", Reason = "เล่นเทนนิสกับเพื่อน", Status = "รอ", CreatedDate = new DateTime(2025, 6, 17, 9, 30, 0) },
            new RequestModel { Id = 22, Name = "สมศักดิ์", Date = "2025-06-17", Time = "18:45", Place = "ร้านสเต็ก", Reason = "ทานข้าวเซลเลเบรท", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 16, 14, 15, 0) },
            new RequestModel { Id = 23, Name = "สมศักดิ์", Date = "2025-06-16", Time = "17:30", Place = "โรงแรม", Reason = "ประชุมใหญ่บริษัท", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 15, 11, 50, 0) },
            new RequestModel { Id = 24, Name = "สมศักดิ์", Date = "2025-06-15", Time = "20:00", Place = "คลับ", Reason = "ปาร์ตี้ครอบครัวเพื่อน", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 14, 17, 25, 0) },
            new RequestModel { Id = 25, Name = "สมศักดิ์", Date = "2025-06-14", Time = "19:15", Place = "ร้านหมูย่าง", Reason = "กินข้าวกับญาติ", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 13, 15, 40, 0) },
            
            // เพิ่มชื่อใหม่: นายสุข
            new RequestModel { Id = 26, Name = "นายสุข", Date = "2025-06-19", Time = "18:30", Place = "ร้านปิ้งย่าง", Reason = "เลี้ยงลูกค้าใหญ่", Status = "รอ", CreatedDate = new DateTime(2025, 6, 18, 10, 20, 0) },
            new RequestModel { Id = 27, Name = "นายสุข", Date = "2025-06-18", Time = "17:45", Place = "ร้านกาแฟ", Reason = "มีตติ้งกับคลายเอ้น", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 17, 13, 35, 0) },
            new RequestModel { Id = 28, Name = "นายสุข", Date = "2025-06-17", Time = "20:30", Place = "บาร์เบียร์", Reason = "ดื่มเบียร์กับหัวหน้า", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 16, 16, 45, 0) },
            new RequestModel { Id = 29, Name = "นายสุข", Date = "2025-06-16", Time = "19:00", Place = "ห้องคาราโอเกะ", Reason = "สังสรรค์ทีมงาน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 15, 9, 15, 0) },
            new RequestModel { Id = 30, Name = "นายสุข", Date = "2025-06-15", Time = "18:15", Place = "ร้านข้าวมันไก่", Reason = "กินข้าวกับลูกค้า", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 14, 12, 50, 0) },
            
            // เพิ่มชื่อใหม่: ป๋อง
            new RequestModel { Id = 31, Name = "ป๋อง", Date = "2025-06-20", Time = "17:30", Place = "สวนสาธารณะ", Reason = "ออกกำลังกายกับกลุ่มเพื่อน", Status = "รอ", CreatedDate = new DateTime(2025, 6, 19, 8, 30, 0) },
            new RequestModel { Id = 32, Name = "ป๋อง", Date = "2025-06-19", Time = "19:45", Place = "ร้านไก่ย่าง", Reason = "กินข้าวกับเพื่อนร่วมชั้น", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 18, 14, 20, 0) },
            new RequestModel { Id = 33, Name = "ป๋อง", Date = "2025-06-18", Time = "18:00", Place = "โบว์ลิ่ง", Reason = "เล่นโบว์ลิ่งกับครอบครัวเพื่อน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 17, 11, 40, 0) },
            new RequestModel { Id = 34, Name = "ป๋อง", Date = "2025-06-17", Time = "20:15", Place = "ร้านเหล้าขาว", Reason = "ดื่มฉลองโปรโมชั่น", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 16, 15, 55, 0) },
            new RequestModel { Id = 35, Name = "ป๋อง", Date = "2025-06-16", Time = "17:00", Place = "ร้านชาเย็น", Reason = "นั่งคุยกับเพื่อนสมัยเด็ก", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 15, 10, 25, 0) },
            
            // คำขอเพิ่มเติมสำหรับ วัยวาย
            new RequestModel { Id = 36, Name = "วัยวาย", Date = "2025-06-21", Time = "18:45", Place = "ร้านปลาเผา", Reason = "เลี้ยงเพื่อนที่ได้งานใหม่", Status = "รอ", CreatedDate = new DateTime(2025, 6, 20, 9, 10, 0) },
            new RequestModel { Id = 37, Name = "วัยวาย", Date = "2025-06-20", Time = "19:30", Place = "ร้านลูกชิ้น", Reason = "กินข้าวกับเพื่อนที่เพิ่งแต่งงาน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 19, 13, 45, 0) },
            new RequestModel { Id = 38, Name = "วัยวาย", Date = "2025-06-19", Time = "17:15", Place = "สนามบิน", Reason = "ไปส่งเพื่อนที่กลับต่างประเทศ", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 18, 16, 30, 0) },
            new RequestModel { Id = 39, Name = "วัยวาย", Date = "2025-06-18", Time = "20:00", Place = "ผับ", Reason = "ปาร์ตี้วันลาออกของเพื่อน", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 17, 12, 15, 0) },
            new RequestModel { Id = 40, Name = "วัยวาย", Date = "2025-06-17", Time = "18:30", Place = "ตลาดนัด", Reason = "ไปซื้อของเก่าหายากกับเพื่อน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 16, 8, 50, 0) },
            
            // คำขอเพิ่มเติมหลากหลาย
            new RequestModel { Id = 41, Name = "แขกบ้าน", Date = "2025-06-22", Time = "19:00", Place = "ร้านข้าวซอย", Reason = "กินข้าวกับเพื่อนบ้าน", Status = "รอ", CreatedDate = new DateTime(2025, 6, 21, 14, 30, 0) },
            new RequestModel { Id = 42, Name = "สมชาย", Date = "2025-06-21", Time = "17:45", Place = "โรงยิม", Reason = "ออกกำลังกายกับเทรนเนอร์", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 20, 11, 20, 0) },
            new RequestModel { Id = 43, Name = "สมศักดิ์", Date = "2025-06-20", Time = "20:30", Place = "ร้านเหล้าแดง", Reason = "ฉลองปีใหม่กับเพื่อนร่วมงาน", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 19, 15, 40, 0) },
            new RequestModel { Id = 44, Name = "นายสุข", Date = "2025-06-19", Time = "18:15", Place = "สวนน้ำ", Reason = "เล่นน้ำกับลูกๆ และเพื่อน", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 18, 10, 5, 0) },
            new RequestModel { Id = 45, Name = "ป๋อง", Date = "2025-06-18", Time = "19:45", Place = "ร้านข้าวผัด", Reason = "กินข้าวกับเพื่อนสาวที่เป็นเพื่อนเก่า", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 17, 13, 25, 0) },
            new RequestModel { Id = 46, Name = "วัยวาย", Date = "2025-06-17", Time = "17:30", Place = "โรงพยาบาล", Reason = "ไปเยี่ยมเพื่อนที่ป่วย", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 16, 9, 45, 0) },
            new RequestModel { Id = 47, Name = "แขกบ้าน", Date = "2025-06-16", Time = "20:00", Place = "คาสิโน", Reason = "เล่นการพนันกับลูกค้า", Status = "ไม่อนุญาต", CreatedDate = new DateTime(2025, 6, 15, 16, 50, 0) },
            new RequestModel { Id = 48, Name = "สมชาย", Date = "2025-06-15", Time = "18:00", Place = "ร้านกะเพรา", Reason = "กินข้าวกับหัวหน้าแผนก", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 14, 12, 35, 0) },
            new RequestModel { Id = 49, Name = "สมศักดิ์", Date = "2025-06-14", Time = "19:15", Place = "ร้านเค้ก", Reason = "ซื้อเค้กวันเกิดให้เมีย", Status = "อนุมัติ", CreatedDate = new DateTime(2025, 6, 13, 8, 20, 0) },
            new RequestModel { Id = 50, Name = "นายสุข", Date = "2025-06-13", Time = "17:00", Place = "ร้านมาม่า", Reason = "กินก๋วยเตี๋ยวกับเพื่อนเก่า", Status = "รอ", CreatedDate = new DateTime(2025, 6, 12, 14, 10, 0) },
        };
        _nextId = 51;
    }

    public async Task<List<RequestModel>> GetAllRequestsAsync()
    {
        await Task.Delay(100);
        return [.. _requests.OrderByDescending(r => r.Id)];
    }

    public async Task<List<RequestModel>> GetUserRequestsAsync(string userName)
    {
        await Task.Delay(100);
        return _requests.Where(r => r.Name == userName)
                       .OrderByDescending(r => r.CreatedDate)
                       .ToList();
    }

    public async Task<bool> AddRequestAsync(RequestModel request)
    {
        await Task.Delay(100);
        
        request.Id = _nextId++;
        request.CreatedDate = DateTime.Now;
        request.Status = "รอ";
        
        _requests.Add(request);
        SaveToFile(); // บันทึกลงไฟล์
        return true;
    }

    public async Task<bool> UpdateRequestStatusAsync(int requestId, string status)
    {
        await Task.Delay(100);
        
        var request = _requests.FirstOrDefault(r => r.Id == requestId);
        if (request != null)
        {
            request.Status = status;
            SaveToFile(); // บันทึกลงไฟล์
            return true;
        }
        return false;
    }
}