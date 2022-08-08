using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task4_userAPI.DataTransferObject;
using Task4_userAPI.Filters;
using Task4_userAPI.Models;

namespace Task4_userAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class userControllers : ControllerBase

    {
        private IUserRepo _userRepo;
        private IMapper _mapper;
        private IpostRepo _postRepo;
        public userControllers(IUserRepo userRepo, IpostRepo postRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _postRepo = postRepo;


        }
        [HttpGet, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<List<user>> getAll()
        {
            var userVM = _mapper.Map<UserVM>(_userRepo.getAll());
            return Ok(userVM);
        }

        [HttpGet("{id}"), Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<user> get(int id)
        {
            var _user = _userRepo.get(id);
            // if (_user == null)
            //    return NotFound();
            var userVM = _mapper.Map<UserVM>(_user);
            return Ok(userVM);
        }

        [HttpDelete, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Delete(int id)
        {
            var _user = _userRepo.get(id);
            if (_user == null)
               return NotFound();
            _userRepo.delete(id);
            return Ok();
        }

        [HttpPut, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult update(user _user)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userId = claimsIdentity.FindFirst("Id").Value;
            if (_postRepo.get(Convert.ToInt32(userId)) == null)
                return NotFound();
            ////////////////
           // var user = _userRepo.get(_user.Id);
           //  if (user == null) return NotFound();
            _userRepo.update(_user, Convert.ToInt32(userId));
            return Ok();
        }

        [HttpPost, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult create(user _user)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userId = claimsIdentity.FindFirst("Id").Value;
            if (_postRepo.get(Convert.ToInt32(userId)) == null)
                return NotFound();
            /////////////////
            _userRepo.add(_user, Convert.ToInt32(userId));
            return Ok();

        }

       
    }
}
