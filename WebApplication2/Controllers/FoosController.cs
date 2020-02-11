using AutoMapper;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    public class FoosController : BaseController<Foo, Models.Foo>
    {
        public FoosController(AppContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}