

using ConvinenceStore.Models.DTO;

namespace ConvinenceStore.Business.Interface;

public interface ILogin{

    public  Task<UserDTO>  ValidateUser (string userName, string password);
}