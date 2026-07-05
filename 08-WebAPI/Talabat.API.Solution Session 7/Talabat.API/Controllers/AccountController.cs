using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.API.Extensions;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services.Contract;

namespace Talabat.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthService authService , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]       // POST:  baseURL/api/Account/login
        public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized(new ApiResponse(401, "Invalid Login"));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
                return Unauthorized(new ApiResponse(401, "Invalid Login"));

            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }


        [HttpPost("register")]   // POST:   baseURL/api/Account/register
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO model)
        {

            if(EmailUsed(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse()
                {
                    Errors = new string[] { "Email is used by other user !!!!" }
                });

            var user = new ApplicationUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.Phone,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Unauthorized(new ApiValidationErrorResponse()
                {
                    Errors = result.Errors.Select(e => e.Description),
                });

            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }


        [Authorize]
        [HttpGet]               // GET :    baseURL/api/Account
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager) 
            }) ;
        }


        [Authorize]
        [HttpGet("address")]   // GET :    baseURL/api/Account/address
        public async Task<ActionResult<AddressDTO>> GetUserAddress()
        {
            var user = await _userManager.FindUserWithAddressAsync(User);
            
            return Ok(_mapper.Map<AddressDTO>(user.Address));
        }

        [Authorize]
        [HttpPut("address")]  // PUT :    baseURL/api/Account/Address
        public async Task<ActionResult<Address>> UpdateUserAddress(AddressDTO address)
        {
            var user = await _userManager.FindUserWithAddressAsync(User);
            var updated_address = _mapper.Map<Address>(address);

            updated_address.Id = user.Address.Id;

            user.Address = updated_address;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(new ApiValidationErrorResponse() { Errors = result.Errors.Select(e=>e.Description)});
            

            return Ok(address);
        }

        [Authorize]
        [HttpGet("usedemail")]             // GET :    baseURL/api/Account/usedemail?email=mahmoud@gmail.com
        public async Task<ActionResult<bool>> EmailUsed(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
