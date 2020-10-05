using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace XUnitTestWebApp.Controllers.Base {
    public class BaseController : Controller {
        protected readonly IServiceProvider _serviceHost;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, IServiceProvider serviceHost) {
            _serviceHost = serviceHost ?? throw new NullReferenceException("serviceHost");
            _mapper = mapper ?? throw new NullReferenceException("mapper.. I can't feel it");
        }
    }
}
