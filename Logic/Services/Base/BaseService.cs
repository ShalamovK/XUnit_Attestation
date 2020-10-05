using AutoMapper;
using Common.Contracts;
using Common.Contracts.Services;
using System;

namespace Logic.Services.Base {
    public class BaseService {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IServiceProvider _serviceHost;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IServiceProvider serviceHost, IUnitOfWork unitOfWork) {
            _serviceHost = serviceHost ?? throw new ArgumentNullException("serviceHost");
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            _mapper = mapper ?? throw new ArgumentNullException("automapper");
        }
    }
}
