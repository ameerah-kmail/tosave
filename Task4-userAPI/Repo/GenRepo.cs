using System.Security.Claims;
using Task4_userAPI.Repo;
namespace Task4_userAPI.Repo
{

    public interface IGenRepo<T> where T:class , IbaseMode
    {
        public List<T>? getAll();
        public T get(int id);
        public void delete(int id);
        public T update(T _obj,int id);
        public T add(T _obj,int id);
    }
    public class GenRepo<T> : IGenRepo<T> where T : class, IbaseMode
    {
        readonly MVCContext _context;
        public T add(T _obj,int id)
        {
            Type myType = _obj.GetType();
            var prop1 = myType.GetProperties().FirstOrDefault(p => p.Name == "creatDate");
            prop1.SetValue(_obj, DateTime.Now);
            /////////////////////
            var prop2 = myType.GetProperties().FirstOrDefault(p => p.Name == "creatBY");
            prop2.SetValue(_obj, id);
            ////////////////////////

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

        public T update(T _obj,int id)
        {
            Type myType = _obj.GetType();
            var prop1 = myType.GetProperties().FirstOrDefault(p => p.Name == "updatetDate");
            prop1.SetValue(_obj, DateTime.Now);
            /////////////////////

            
            var prop2 = myType.GetProperties().FirstOrDefault(p => p.Name == "updateBY");
            prop2.SetValue(_obj, id);
            ////////////////////////

            _context.Set<T>().Update(_obj);
               // .Update<T>(_obj);
            return _obj;
            _context.SaveChanges();
        }


    }
}

