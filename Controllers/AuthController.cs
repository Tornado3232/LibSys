using Microsoft.AspNetCore.Mvc;

namespace LibSys.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public ActionResult<ServiceResponse<int>> Register(UserRegisterDto request)
        {
            var response = _authRepository.Register(
                new User { FirstName = request.FirstName, LastName = request.LastName, UserName = request.UserName }, request.Password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public ActionResult<ServiceResponse<int>> Login(UserLoginDto request)
        {
            var response = _authRepository.Login(request.UserName, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
