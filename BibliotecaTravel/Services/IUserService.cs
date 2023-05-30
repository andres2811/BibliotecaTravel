using BibliotecaTravel.Dtos;

namespace BibliotecaTravel.Services
{
    public interface IUserService 
    {
        bool isValidUserInformation(UserDto user);
    }
}
