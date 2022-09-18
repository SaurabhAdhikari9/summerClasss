using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ResourceManagementSystem.Application.DTOs;
using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResourceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // Declaring the field for the identity user for the registration purposes
        private readonly UserManager<Staff> _userManager;

        // Declaring the field for the identity user for the login purposes
        private readonly SignInManager<Staff> _signInManager;

        // Declaring the field for the logger to account the authentication history
        private readonly ILogger<AuthenticationController> _logger;

        // Declaring a field of IUnitOfWork in order to access all of its properties, methods and attributes
        private readonly IUnitOfWork _unitOfWork;

        // Declaring a field of Mapper in order to map the model with its particular view model
        private readonly IMapper _mapper;

        // Injecting all the required instances to the constructor of this controller
        public AuthenticationController(UserManager<Staff> userManager, SignInManager<Staff> signInManager, ILogger<AuthenticationController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region API Calls

        /// <summary>
        /// Defining a Get method to retrieve all of the staffs
        /// Use of the field to extract one of its repository, staff
        /// Implementing the GetAll() function to retrieve all of its data in a listed form
        /// </summary>
        /// <returns>List of all available staffs with required properties for an non empty list</returns>
        /// <returns>All the returned items in the list will be mapped with the DTO created</returns>
        [HttpGet("GetAllStaffs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Staff>> GetAllStaffs()
        {
            var staffs = _unitOfWork.Staff.GetAll();

            if (staffs.Count() == 0)
            {
                return BadRequest("No any staffs have been added yet.");
            }

            return Ok(staffs.Select(staff => _mapper.Map<StaffDTO>(staff)));
        }

        /// <summary>
        /// A controller method defined to register staffs to their particular system by providing their individual details
        /// Processes by examining if a unique email is provided on input or not
        /// Further proceed on filling up all the required attributes provided by Identity user
        /// Finalized by registering the system user into the database of the program filling all the required fields
        /// </summary>
        /// <param name="user">Enter of all the required properties necessary for registration purposes</param>
        /// <returns>A successful notice about registration on the system when valid data are entered</returns>
        [HttpPost("RegisterStaff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterStaff(RegisterDTO user)
        {
            var userExists = await _userManager.FindByEmailAsync(user.Email);

            if(userExists != null)
            {
                return BadRequest("Staff has already been registered to the system");
            }

            Staff staff = new Staff()
            {
                Name = user.Name,
                UserName = user.Name,
                EmailConfirmed = true,
                Email = user.Email,
                NormalizedEmail = user.Email.ToUpper(),
                NormalizedUserName = user.Name.ToUpper(),
                PhoneNumber = user.PhoneNumber,
                HiredDate = user.HiredDate,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(staff, user.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.ToString());
            }

            _logger.LogInformation("User created a new account with password.");

            return Ok("Staff registered successfully");
        }

        //[HttpPost("LoginStaff")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> LoginStaff(LoginDTO user)
        //{
            //var userExists = await _userManager.FindByEmailAsync(user.Email);

            //if (userExists != null && await _userManager.CheckPasswordAsync(userExists, user.Password))
            //{
            //    var userRoles = await _userManager.GetRolesAsync(userExists);

            //    var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, userExists.Name),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //    };

            //    foreach(var userRole in userRoles)
            //    {
            //        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            //    }

            //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            //    var token = new JwtSecurityToken(
            //        issuer: _configuration["JWT:ValidIssuer"],
            //        audience: _configuration["JWT:ValidAudience"],
            //        expires: DateTime.Now.AddHours(5),
            //        claims: authClaims,
            //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            //        );

            //    return Ok(new
            //    {
            //        token = new JwtSecurityTokenHandler().WriteToken(token),
            //        expiration = token.ValidTo,
            //        User = userExists.Name
            //    });
            //}

            //return Unauthorized("Login failed");

        //    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: true);

        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User logged in.");
        //        return Ok("User successfully logged in.");
        //    }

        //    return Unauthorized("Login failed");
        //}

        #endregion
    }
}
