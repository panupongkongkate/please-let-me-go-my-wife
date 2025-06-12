using MyApplication.Models;

namespace MyApplication.Services;

public class AuthService
{
    private readonly List<UserModel> _users = new()
    {
        new UserModel { Id = 1, Username = "สามี", Password = "123456", Role = "สามี", DisplayName = "วัยวาย" },
        new UserModel { Id = 2, Username = "เมีย", Password = "admin", Role = "เมีย", DisplayName = "คุณหญิง" },
        new UserModel { Id = 3, Username = "guest", Password = "guest", Role = "สามี", DisplayName = "แขกบ้าน" }
    };

    public UserModel? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;

    public async Task<bool> LoginAsync(string username, string password)
    {
        await Task.Delay(100);
        
        var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            CurrentUser = user;
            return true;
        }
        return false;
    }

    public async Task LogoutAsync()
    {
        await Task.Delay(100);
        CurrentUser = null;
    }

    public async Task<bool> QuickLoginAsync(string role)
    {
        await Task.Delay(100);
        
        var user = role.ToLower() switch
        {
            "admin" => _users.FirstOrDefault(u => u.Role == "เมีย"),
            "user" => _users.FirstOrDefault(u => u.Username == "สามี"),
            _ => null
        };

        if (user != null)
        {
            CurrentUser = user;
            return true;
        }
        return false;
    }
}