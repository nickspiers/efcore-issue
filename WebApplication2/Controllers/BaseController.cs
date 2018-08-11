using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.OData;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BaseController<TEntity, TModel> : ODataController
        where TEntity: EntityBase
        where TModel : ModelBase
    {
        private readonly AppContext _context;

        public BaseController(AppContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public virtual IQueryable<TModel> Get()
        {
            return _context.Set<TEntity>().ProjectTo<TModel>();
        }
    }
}