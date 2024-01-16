using Microsoft.AspNetCore.Http;
using NHibernate.Context;

namespace YourAcademy.DAL
{
    public class NHibernateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly INHibernateHelper _helper;

        public NHibernateMiddleware(RequestDelegate next)
        {
            _next = next;
            _helper = _helper ?? new NHibernateHelper();
        }

        public async Task Invoke(HttpContext context)
        {
            using (var session = _helper.OpenSession())
            {
                CurrentSessionContext.Bind(session);
                try
                {
                    await _next(context);
                }
                finally
                {
                    CurrentSessionContext.Unbind(_helper.SessionFactory);
                    session.Dispose();
                }
            }
                
        }
    }
}
