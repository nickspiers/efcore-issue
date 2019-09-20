using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BaseController(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        public virtual IQueryable<TModel> Get()
        {
            return _context.Set<TEntity>().ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }
    }
}