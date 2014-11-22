using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace WebAPI.Handlers
{
    public abstract class BaseHandler<TRequest, TResponse>
    {
        protected TResponse Response;

        public TResponse Handle(TRequest request)
        {
            try
            {
                if (Validate(request))
                {
                    return HandleCore(request);
                }
            }
            catch (Exception exception)
            {
                // log error

                return Response;
            }

            return Response;
        }

        public abstract bool Validate(TRequest request);
        public abstract TResponse HandleCore(TRequest request);


    }
}