using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Handlers.TransactionsHandlers;
using WebAPI.Messages.TransactionMessages;

namespace WebAPI.Controllers
{
    public class TransactionsController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            GetTransactionsAverageRequest getTransactionsAverageRequest = new GetTransactionsAverageRequest { BankId = id };

            var handler = new GetTransactionsAverageHandler();

            var response = handler.Handle(getTransactionsAverageRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            GetAllTransactionsRequest getAllTransactionsRequest = new GetAllTransactionsRequest();

            var handler = new GetAllTransactionsHandler();

            var response = handler.Handle(getAllTransactionsRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]AddTransactionRequest addTransactionRequest)
        {
            var handler = new AddTransactionHandler();

            var response = handler.Handle(addTransactionRequest);

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/transactions/routes")]
        [HttpGet]
        public HttpResponseMessage GetBanksReceivers()
        {
            var handler = new GetBanksReceiversHandler();

            var response = handler.Handle(new GetBanksReceiversRequest());

            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
