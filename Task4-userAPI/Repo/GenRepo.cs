using Task4_userAPI.Repo;
namespace Task4_userAPI.Repo
{

    public interface IGenRepo<T> where T:class , IbaseMode
    {
        public List<T>? getAll();
        public T get(int id);
        public void delete(int id);
        public T update(T _obj);
        public T add(T _obj);
    }
    public class GenRepo<T> : IGenRepo<T> where T : class, IbaseMode
    {
        readonly MVCContext _context;
        public T add(T _obj)
        { 
            _context.Add(_obj);
            return _obj;
            _context.SaveChanges(); 
        }

        public GenRepo(MVCContext context)
        {
            _context = context;
        }

        public void delete(int id)
        {
            var _temp = _context.Set<T>().FirstOrDefault(c => c.Id==id);
             _context.Set<T>().Remove(_temp);
            _context.SaveChanges();

        }

        public T get(int id)
        {
            return _context.Set<T>().Find(id);
            _context.SaveChanges();
        }

        public List<T>? getAll()
        {
            return _context.Set<T>().ToList();
            
            _context.SaveChanges();
        }

        public T update(T _obj)
        {
            _context.Set<T>().Update(_obj);
               // .Update<T>(_obj);
            return _obj;
            _context.SaveChanges();
        }
    }
}

