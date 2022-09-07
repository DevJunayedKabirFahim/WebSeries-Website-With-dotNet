using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class ReviewRepo : IRepository<Review, int>
    {
        WebSeriesDBEntities db;
        public ReviewRepo(WebSeriesDBEntities db)
        {
            this.db = db;
        }
        public bool Create(Review obj)
        {
            if (obj == null) return false;
            db.Reviews.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var delete = db.Reviews.Remove(db.Reviews.FirstOrDefault(del => del.Id.Equals(id)));
            if (delete == null) return false;
            return db.SaveChanges() != 0;
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return db.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public bool Update(Review obj)
        {
            var r = db.Reviews.FirstOrDefault(u => u.Id.Equals((obj.Id)));
            if (r == null) return false;
            db.Entry(r).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
