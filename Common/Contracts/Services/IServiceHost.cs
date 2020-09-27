using Common.Contracts.Services.Base;

namespace Common.Contracts.Services {
    public interface IServiceHost {
        void Register<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}
