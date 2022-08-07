using Task4_userAPI.Contex;
using Task4_userAPI.Models;

namespace Task4_userAPI.Repo
{
    public interface IpostRepo : IGenRepo<post>
    {
        public List<post> Search(int pageN, int pagesize, string phrase);
    }
    public class postRepo :GenRepo<post>, IpostRepo
    {
        private MVCContext _context;
        public postRepo(MVCContext context): base(context)
        {
            _context = context;

        }
      /*  public void add(post _post)
        {
            _context.Add<post>(_post);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            post _temp = get(id);
            if (_temp != null)
            {
                _context.Remove<post>(_temp);
                _context.SaveChanges();

            }
        }

        public post get(int id)
        {
            post p;
            p = _context.Find<post>(id);
            return p;
            _context.SaveChanges();
        }

        public List<post> getAll()
        {
            List<post> postList;

            postList = _context.Set<post>().ToList();
            return postList;
            _context.SaveChanges();
        }

        public void update(post _post)
        {
            post _temp = get(_post.Id);
            if (_temp != null)
            {
                _temp.Title = _post.Title;
                
                _context.Update<post>(_temp);
                _context.SaveChanges();
            }
        }*/
      //where-->skip-->take`
        public List<post> Search(int pageN, int pagesize, string phrase)
        {
         var pagedData = _context.posts.Where(s => s.Title.Contains(phrase))
                .Skip((pageN - 1) * pagesize)
         .Take(pageN)
         .ToList();
            return pagedData;
        }
    }
}
