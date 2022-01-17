
namespace ReportCard.Api.Server.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Newtonsoft.Json;
    using NLog;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;

    public class SujectController : ApiController
    {
        private ILogger logger = LogManager.GetLogger("ReportCard.Api.Server");

        private ISujectRepository repo;

        public SujectController(ISujectRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var queryResult = this.repo.Query();

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.sujects));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Get Exception");
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] SujectAddDto input)
        {
            try
            {
                var addResult = this.repo.Add(input.Name);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.suject));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] SujectUpdateDto input)
        {
            try
            {
                var updateResult = this.repo.Update(new Suject()
                {
                    f_id = input.Id,
                    f_name = input.Name
                });

                if (updateResult.exception != null)
                {
                    throw updateResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(updateResult.suject));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Put Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var delResult = this.repo.Delete(id);

                if (delResult.exception != null)
                {
                    throw delResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(delResult.suject));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Delete Exception id:{id}");
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
