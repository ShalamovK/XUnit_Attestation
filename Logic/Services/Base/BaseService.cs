using Common.Contracts;
using Common.Contracts.Services;
using System;

namespace Logic.Services.Base {
    public class BaseService {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IServiceHost _serviceHost;

        public BaseService(IServiceHost serviceHost, IUnitOfWork unitOfWork) {
            _serviceHost = serviceHost ?? throw new ArgumentNullException("serviceHost");
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        }
    }
}
