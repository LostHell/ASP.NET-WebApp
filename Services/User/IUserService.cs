namespace Services.User;

public interface IUserService
{
    Task<List<Data.Models.User>> GetAllUserAsync();
    Task<string> CreateNewUserAsync(Data.Models.User user);
}