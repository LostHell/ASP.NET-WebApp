using Data;
using Microsoft.EntityFrameworkCore;

namespace Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Data.Models.User>> GetAllUserAsync()
    {
        return await this._dbContext.Users.ToListAsync();
    }

    public async Task<string> CreateNewUserAsync(Data.Models.User input)
    {
        var found = await this._dbContext.Users.AnyAsync(x => x.Username == input.Username);

        if (found)
        {
            return $"You cannot create user with username:{input.Username}, because is already in use!";
        }

        var user = new Data.Models.User()
        {
            Username = input.Username,
            Email = input.Email,
            Age = input.Age
        };

        await this._dbContext.Users.AddAsync(user);
        await this._dbContext.SaveChangesAsync();

        return "User was created!";
    }
}