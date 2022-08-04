using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task4_userAPI.Filters;
using Task4_userAPI.Models;
using Task4_userAPI.Roles;

namespace Task4_userAPI.Controllers
{
    [Route("api/[controller]")]
  
    [ApiController]
    public class postController : ControllerBase
    {
        private IpostRepo _postRepo;

        public postController(IpostRepo postRepo)
        {
            _postRepo = postRepo;

        }
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<List<post>> getAll()
        {
            return _postRepo.getAll();
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult<post> get(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            return _post;
        }

        [HttpDelete]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Delete(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            _postRepo.delete(id);
            return Ok();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult update(post _post)
        {
            var post = _postRepo.get(_post.Id);
            if (post == null) return NotFound();
            _postRepo.update(_post);
            return Ok();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult create(post _post)
        {
            _postRepo.add(_post);
            return Ok();

        }

    }
}
