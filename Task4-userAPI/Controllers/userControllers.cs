using AutoMapper;
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
        public userControllers(IUserRepo userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;

        }
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<List<user>> getAll()
        {
            return _userRepo.getAll();
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<user> get(int id)
        {
            var _user = _userRepo.get(id);
            // if (_user == null)
            //    return NotFound();
            var userVM = _mapper.Map<UserVM>(_user);
            return userVM;
        }

        [HttpDelete]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Delete(int id)
        {
            var _user = _userRepo.get(id);
            if (_user == null)
                return NotFound();
            _userRepo.delete(id);
            return Ok();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult update(user _user)
        {
            var user = _userRepo.get(_user.Id);
            if (user == null) return NotFound();
            _userRepo.update(_user);
            return Ok();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult create(user _user)
        {
            _userRepo.add(_user);
            return Ok();

        }
    }
}
