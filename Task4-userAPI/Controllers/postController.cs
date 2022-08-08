using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task4_userAPI.Filters;
using Task4_userAPI.Models;
using Task4_userAPI.Roles;

namespace Task4_userAPI.Controllers
{
    [Route("api/[controller]/[action]")]
  
    [ApiController]
    public class postController : ControllerBase
    {
        private IpostRepo _postRepo;

        public postController(IpostRepo postRepo)
        {
            _postRepo = postRepo;

        }
        [HttpGet, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<List<post>> getAll()
        {
            return _postRepo.getAll();
        }

        [HttpGet("{id}"), Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<post> get(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            return _post;
        }

        [HttpDelete, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Delete(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            _postRepo.delete(id);
            return Ok();
        }

        [HttpPut, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult update(post _post)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userId = claimsIdentity.FindFirst("Id").Value;
            var post = _postRepo.get(Convert.ToInt32(userId));
            if (post == null) return NotFound();
            _postRepo.update(_post, Convert.ToInt32(userId));
            return Ok();
        }

        [HttpPost, Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult create(post _post)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userId = claimsIdentity.FindFirst("Id").Value;
            if(_postRepo.get(Convert.ToInt32(userId))==null)
            return NotFound();
            _postRepo.add(_post, Convert.ToInt32(userId));
            return Ok();
        
        }

        [HttpGet, Authorize]
        public List<post> GetBySearch(int PageN, int pageSize, string phrase)
        {
            var response = _postRepo.Search(PageN, pageSize, phrase);
            return response;

        }

    }
}
