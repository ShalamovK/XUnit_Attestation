using Microsoft.AspNetCore.Http;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace XUnitTestWebApp.IoC {
    public class PerRequestOrTransientLifeTimeManager : LifetimeManager, ITypeLifetimeManager {
        private readonly PerRequestLifetimeManager m_PerRequestLifetimeManager = new PerRequestLifetimeManager();
        private readonly TransientLifetimeManager m_TransientLifetimeManager = new TransientLifetimeManager();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PerRequestOrTransientLifeTimeManager(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public override object GetValue(ILifetimeContainer container = null) {
            return GetAppropriateLifetimeManager().GetValue();
        }
        public override void SetValue(object newValue, ILifetimeContainer container = null) {
            GetAppropriateLifetimeManager().SetValue(newValue);
        }
        public override void RemoveValue(ILifetimeContainer container = null) {
            GetAppropriateLifetimeManager().RemoveValue();
        }

        private LifetimeManager GetAppropriateLifetimeManager() {
            //PerRequestLifetimeManager can only be used in the context of an HTTP request
            if (_httpContextAccessor.HttpContext == null)
                return m_TransientLifetimeManager;

            return m_PerRequestLifetimeManager;
        }

        protected override LifetimeManager OnCreateLifetimeManager() {
            return GetAppropriateLifetimeManager();
        }
    }
}
