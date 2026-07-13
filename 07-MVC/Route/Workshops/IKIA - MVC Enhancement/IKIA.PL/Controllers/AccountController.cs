using IKIA.DAL.Models.Identity;
using IKIA.PL.Emails;
using IKIA.PL.SMS;
using IKIA.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKIA.PL.Controllers
{
    public class AccountController : Controller
    {
        #region Services

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // private readonly IEmailService _emailService;        // use the new one
        private readonly INewEmailService _newEmailService;
        private readonly IConfiguration _configuration;
        private readonly ISmsService _smsService;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            INewEmailService newEmailService,
            ISmsService smsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _newEmailService = newEmailService;
            _smsService = smsService;
        }

        #endregion

        #region Sign Up

        [HttpGet]      // GET :    /Account/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel userVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var userfind = await _userManager.FindByNameAsync(userVM.UserName);

            if (userfind is { })
            {
                ModelState.AddModelError(string.Empty, "This username is already in use for another account");
                return View(userVM);
            }
            else if (userfind == null)
            {
                // now map from SignUpViewModel to an ApplicationUser
                var user = new ApplicationUser()
                {
                    FName = userVM.FirstName,
                    LName = userVM.LastName,
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    IsAgree = userVM.IsAgree,
                };

                // now interact with the service that we will use to create the user
                // ask the CLR in the ctor for providing an object from "UserManager<ApplicationUser>" and "SignInManager<ApplicationUser>" 
                // and RoleManager<IdentityRole> (Discussed later in APIs) and also the minor services (ex: service for hashing the password )
                // Don't miss allowing the dependency injection for these 3 service in the "Program" class (Important)

                var result = await _userManager.CreateAsync(user, userVM.Password);
                // This creates the user in the backing store (Repository)

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(SignIn));
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userVM);
        }

        #endregion

        #region Sign In

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel userVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(userVM.Email);
            if (user is { })
            {
                var flag = await _userManager.CheckPasswordAsync(user, userVM.Password);
                if (flag)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userVM.Password, userVM.RememberMe, true);
                    // In Program class : options.Lockout.MaxFailedAccessAttempts = 3;   --> Last parameter = true 

                    if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your account is not confirmed Yet !!");

                    if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your Account is Locked");

                    // if (result.RequiresTwoFactor) { }         // implemented in Workshop 


                    // Then now check if succeeded : it must be the last checking 
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else if (!result.Succeeded)
                        ModelState.AddModelError(string.Empty, "Email or Password is Wrong");

                    // if we want to see the token , then in the browser : 
                    // inspect -> Application -> AspNetCore.Identity.Application

                    // Note : We generate the token by the default configurations of the dot net , in APIs we will use the JWT package

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found");
            }
            return View(userVM);
        }




        // Google Login

        public IActionResult GoogleLogin()
        {
            var prop = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            };
            return Challenge(prop, GoogleDefaults.AuthenticationScheme);
        }


        // Google Response

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(
                claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                }
                );
            return RedirectToAction("Index", "Home");
        }




        #endregion

        #region Sign Out

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }

        #endregion

        #region Forget Password and Send Reset Password Email

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is { })
                {
                    var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);  // unique 

                    var resetPasswordURL = Url.Action("ResetPassword", "Account", new { email = model.Email, token = resetPasswordToken }, "https", "localhost:7049");
                    // will be : https://localhost:7049/Account/ResetPassword?email=1m.shoura1@gmail.com&token=lkdjsfj54jkn


                    _newEmailService.SendEmail(model.Email, "Reset your password", resetPasswordURL);

                    return RedirectToAction(nameof(CheckYourInbox));
                }
                ModelState.AddModelError(string.Empty, "No user with this email !!");
                return View(model);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SendResetPasswordSms(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is { })
                {
                    var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);  // unique 

                    var resetPasswordURL = Url.Action("ResetPassword", "Account", new { email = model.Email, token = resetPasswordToken }, "https", "localhost:7049");
                    // will be : https://localhost:7049/Account/ResetPassword?email=1m.shoura1@gmail.com&token=lkdjsfj54jkn


                    //_newEmailService.SendEmail(model.Email, "Reset your password", resetPasswordURL);
                    _smsService.Send(user.PhoneNumber, resetPasswordURL);

                    return RedirectToAction(nameof(CheckYourPhone));
                }
                ModelState.AddModelError(string.Empty, "No user with this email !!");
                return View(model);
            }
            return View(model);
        }


        public IActionResult CheckYourInbox()
        {
            return View();
        }
        public IActionResult CheckYourPhone()
        {
            return View();
        }


        #endregion

        #region Reset Password

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            TempData["Email"] = email;
            TempData["Token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = TempData["email"] as string;
                var token = TempData["Token"] as string;

                var user = await _userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }

                    return RedirectToAction(nameof(SignIn));
                }
                ModelState.AddModelError("", "URL is not valid !!!! ");
            }
            return View(model);
        }

        #endregion
    }
}
