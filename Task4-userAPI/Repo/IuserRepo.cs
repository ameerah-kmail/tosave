﻿using Task4_userAPI.Models;
namespace Task4_userAPI.Repo
{
    public interface IUserRepo : IGenRepo<user>
    {
    }
        /*public  List<user> getAll()
        {
            List<user> userList;
           
                userList = _context.Set<user>().ToList();
            return userList;
            _context.SaveChanges();
        }//end of getAll
        public  user get(int id)
        {
            user u;
                u = _context.Find<user>(id);
            return u;
            _context.SaveChanges();

        }//end of get by id
        public  void delete(int id)
        {

                user _temp = get(id);
                if (_temp != null)
                {
                    _context.Remove<user>(_temp);
                    _context.SaveChanges();
                   
                }
        }//end of delete

        public void update(user _user)
        {
            user _temp = get(_user.Id);
            if (_temp != null)
            {
                _temp.lname = _user.lname;
                _temp.fname = _user.fname;
                _context.Update<user>(_temp);
                _context.SaveChanges();
            }
        }
        public void add(user _user)
        {
            _context.Add<user>(_user);
            _context.SaveChanges();
        }//end of add
        */
    }//end of class userRepo
}//end of namespace Task4_userAPI.Repo
