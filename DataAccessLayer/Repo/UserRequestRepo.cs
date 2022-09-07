using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class UserRequestRepo : IRepository<UserRequest, int>
    {
        WebSeriesDBEntities db;
        public UserRequestRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }

        public bool Create(UserRequest obj)
        {
            if (obj == null) return false;
            db.UserRequests.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.UserRequests.Remove(db.UserRequests.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<UserRequest> Get()
        {
            return db.UserRequests.ToList();
        }

        public UserRequest Get(int id)
        {
            return db.UserRequests.FirstOrDefault(u => u.Id == id);
        }

        public bool Update(UserRequest obj)
        {
            var ur = db.UserRequests.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (ur == null) return false;
            db.Entry(ur).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
