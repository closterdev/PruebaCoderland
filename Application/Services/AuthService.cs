using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Ports;
using Shared.Common;
using System.Text;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository user, ITokenService tokenService)
    {
        _userRepository = user;
        _tokenService = tokenService;
    }

    public async Task<TokenOut> ValidateUser(TokenIn userCredentials)
    {
        TokenOut output = new();

        try
        {
            string? token = null;
            User CredentialsDto = MapUserToEntity(userCredentials);
            User? dataUser = await _userRepository.GetUserByKeyAsync(CredentialsDto);

            if (dataUser != null)
            {
                if (!dataUser.IsActive)
                {
                    output.Message = "El username esta inactivo.";
                    output.Result = Result.IsNotActive;
                    output.Token = token;
                }
                else
                {
                    bool isValid = PassCheck(dataUser, userCredentials);
                    token = isValid ? _tokenService.JwtToken() : null;

                    if (isValid)
                    {
                        output.Message = "El token se genero correctamente.";
                        output.Result = Result.Success;
                        output.Token = token;
                    }
                    else
                    {
                        output.Message = "La password es incorrecta.";
                        output.Result = Result.InvalidPassword;
                        output.Token = token;
                    }
                }
            }
            else
            {
                output.Message = "El username no existe.";
                output.Result = Result.NoRecords;
                output.Token = token;
            }
        }
        catch (Exception ex)
        {
            output.Message = $"Ha ocurrido un error. {ex.Message}";
            output.Result = Result.Error;
        }

        return output;
    }

    private static bool PassCheck(User data, TokenIn user)
    {
        bool output;

        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(user.Password);
            string encodedPassword = Convert.ToBase64String(bytes);

            output = string.Equals(encodedPassword, data.Password, StringComparison.Ordinal);
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    private static User MapUserToEntity(TokenIn user)
    {
        return new User()
        {
            Username = user.Username,
            Password = user.Password
        };
    }
}