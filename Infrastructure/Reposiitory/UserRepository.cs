using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reposiitory;

public class UserRepository : IUserRepository
{
    private readonly ApiContext _context;

    public UserRepository(ApiContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByKeyAsync(User userCredentials)
    {
        return await _context.Users.Where(u => u.Username == userCredentials.Username).FirstOrDefaultAsync();
    }
}