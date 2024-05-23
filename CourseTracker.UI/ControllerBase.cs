using AutoMapper;
using CourseTracker.UI.Services.DAL;
using CourseTracker.UI.Services.State;
using Microsoft.AspNetCore.Mvc;

namespace CourseTracker.UI
{
    
    public class ControllerBase : Controller
    {

        protected readonly IApiDal _dal;
        protected readonly IMapper _mapper;
        protected readonly IState _state;

        public ControllerBase(IApiDal dal, IMapper mapper, IState state)
        {
            _dal = dal;
            _mapper = mapper;
            _state = state;
        }

    }

}
