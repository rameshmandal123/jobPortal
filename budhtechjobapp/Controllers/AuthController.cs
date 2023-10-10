using budhtechjobapp.Data;
using budhtechjobapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace budhtechjobapp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDL _authDL;

        public AuthController(IAuthDL authDL) 
        { 
            _authDL = authDL;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            SignupResponse response = new SignupResponse();
            try
            {
              response = await _authDL.SignupAsync(request);

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return  Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            try
            {
                await _authDL.SignInAsync(request);
               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            response.IsSuccess = true;
            response.Message = "Successfull";
            return Ok(response);
        }

    }
}
