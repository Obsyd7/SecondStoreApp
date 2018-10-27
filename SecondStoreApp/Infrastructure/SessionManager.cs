using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace SecondStoreApp.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState Session;

        public SessionManager()
        {
            Session = HttpContext.Current.Session;
        }

        public T Get<T>(string key)
        {
            return (T)Session[key];
        }

        public void Set<T>(string name, T value)
        {
            Session[name] = value;
        }

        public void Abandon()
        {
            Session.Abandon();
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T) Session[key];
            }
            catch (NullReferenceException)
            {
                return default(T);

            }
        }
    }
}