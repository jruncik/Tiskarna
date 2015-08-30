using NHibernate;
using TV.Core.Log;

namespace TV.Core.Context
{
    public class AppliactionContext : ContextSingleton<AppliactionContext>
    {
        public static ISessionFactory SessionFactory
        {
            get { return Instance._sessionFactory; }
        }

        public static ILog Log
        {
            get { return Instance._log; }
        }

        public AppliactionContext(ILog log, ISessionFactory sessionFactory)
        {
            _log = log;
            _sessionFactory = sessionFactory;
        }

        private readonly ILog _log;
        private ISessionFactory _sessionFactory;
    }
}