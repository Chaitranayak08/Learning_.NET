using Learning_DotNet.DataAccess.Data;
using Learning_DotNet.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Learning_DotNet.Models;
using Learning_DotNet.DataAccess.Repository.IRepository;

namespace Learning_DotNet.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
            
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
