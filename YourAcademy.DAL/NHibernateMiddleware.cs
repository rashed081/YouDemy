using Microsoft.AspNetCore.Http;
using NHibernate.Context;

namespace YourAcademy.DAL
{
    public class NHibernateMiddleware
    {
        private readonly RequestDelegate _next;

        public NHibernateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var session = NHibernateHelper.OpenSession())
                CurrentSessionContext.Bind(session);
                await _next(context);
                CurrentSessionContext.Unbind(NHibernateHelper.SessionFactory);
            }
    }
}
