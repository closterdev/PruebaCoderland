using Domain.Entities;

namespace Domain.Ports;

public interface IUserRepository
{
    Task<User?> GetUserByKeyAsync(User userCredentials);
}