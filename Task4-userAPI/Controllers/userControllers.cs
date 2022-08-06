using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var userVM = _mapper.Map<UserVM>(_user);
            if (_user == null)
               return NotFound();
           // userVM.delete(id);
            return Ok();
        }

        [HttpPut, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult update(user _user)
        {
            var user = _userRepo.get(_user.Id);
            var userVM = _mapper.Map<UserVM>(_user);
             if (user == null) return NotFound();
            //userVM.update(_user);
            return Ok();
        }

        [HttpPost, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult create(user _user)
        {
            _userRepo.add(_user);
            return Ok();

        }

       
    }
}
