using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Meditelligence.WebAPI.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;

        public UserController(IUserRepo repo, IMapper mapper, IPasswordHasher<User> hasher)
        {
            _repo = repo;
            _mapper = mapper;
            _hasher = hasher;
        }

        [HttpGet("{id}", Name = nameof(GetUserById))]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user is null)
            {
                return BadRequest(_mapper.Map<UserReadDto>(user));
            }

            return Ok(_mapper.Map<UserReadDto>(user));

        }

        [HttpPost("Register")]
        public ActionResult<UserReadDto> RegisterUser(UserCreateDto newAccount)
        {
            var user = _mapper.Map<User>(newAccount);
            try
            {
                user.Password = _hasher.HashPassword(user, user.Password);
                _repo.CreateUser(user);
                _repo.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var returnResult = _mapper.Map<UserReadDto>(user);

            return CreatedAtRoute(nameof(GetUserById), new { id = returnResult.UserID }, returnResult);
        }

        [HttpPost("Login")]
        public ActionResult<UserReadDto> LoginUser([FromBody]RegisterDTO registerInfo)
        {
            var search = _repo.GetUserByEmail(registerInfo.Email);
            if (search is null)
            {
                return BadRequest("Email or password incorrect.");
            }

            var result = _hasher.VerifyHashedPassword(search, search.Password, registerInfo.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return BadRequest("Email or password incorrect.");
            }

            return Ok(_mapper.Map<UserReadDto>(search));
        }

        [HttpPut("UpdatePassword")]
        public ActionResult<string> ChangeUserPassword(ChangePasswordDto newPasswordRequest)
        {
            if (newPasswordRequest is null)
            {
                return BadRequest("No new password supplied.");
            }

            newPasswordRequest.NewPassword = _hasher.HashPassword(null, newPasswordRequest.NewPassword);
            try
            {
                _repo.ChangePassword(newPasswordRequest.UserID, newPasswordRequest.NewPassword);
                return Ok("Password successfully changed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("DeleteAccount")]
        public ActionResult<string> DeleteUser(UserReadDto user)
        {
            var recordToDelete = _repo.GetUserById(user.UserID);
            _repo.DeleteUser(recordToDelete);
            _repo.SaveChanges();
            return Ok("Account deleted");
        }
    }
}
