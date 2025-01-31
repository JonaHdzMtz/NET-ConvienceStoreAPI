
using ConvinenceStore.Business.Interface;
using ConvinenceStore.Models;
using ConvinenceStore.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ConvinenceStore.Business.Provider;

public class LoginProvider : ILogin
{


    private ConvinenceStoreContext _connection;
    public LoginProvider(ConvinenceStoreContext connection)
    {
        _connection = connection;

    }

    public async Task<UserDTO> ValidateUser(string userName, string password)
    {

        UserDTO userDTO = new UserDTO();
        User result;
        try
        {
            result = await _connection.Users.FirstAsync(item => item.UserName.Equals(userName) && item.Password.Equals(password));
            if (result != null)
            {
                userDTO = new UserDTO()
                {
                    IdUser = result.IdUser,
                    Password = result.Password,
                    UserName = result.UserName
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return userDTO;
    }
}