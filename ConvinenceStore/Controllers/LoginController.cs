

using ConvinenceStore.Business.Interface;
using ConvinenceStore.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ConvinenceStore.Controllers;

[ApiController]
[Route("[Controller]")]
public class LoginController : ControllerBase
{
    private ILogin _login;
    public LoginController(ILogin login)
    {
        _login = login;
    }

    [HttpPost("login")]
    public IActionResult login([FromBody]Credential credential){
        var result = _login.ValidateUser(credential.Username,credential.Password);
        if(result.Result.UserName != null)
            return Ok(result.Result);
        return StatusCode(404);
    }

}