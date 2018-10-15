using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi2Book.Web.Common.ErrorHandling
{
   public class SimpleErrorResult:IHttpActionResult
   {
       private readonly string _errorMessage;
       private readonly HttpRequestMessage _requestMessage;
       private readonly HttpStatusCode _statusCode;
        private HttpRequestMessage request;
        private object httpSat;

        public SimpleErrorResult(HttpRequestMessage request, object httpSat)
        {
            this.request = request;
            this.httpSat = httpSat;
        }

        public SimpleErrorResult(HttpRequestMessage requestMessage, HttpStatusCode statusCode, string errormessage)
       {
           _requestMessage = requestMessage;
           _statusCode = statusCode;
           _errorMessage = errormessage;

       }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode, _errorMessage));
        }
    }
}
