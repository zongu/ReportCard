
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

    public class ScoreController : ApiController
    {
        private ILogger logger = LogManager.GetLogger("ReportCard.Api.Server");

        private IScoreRepository repo;

        public ScoreController(IScoreRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public HttpResponseMessage Get(int? sujectId)
        {
            try
            {
                var queryResult = this.repo.Query(sujectId);

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.scores));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Get Exception sujectId:{sujectId}");
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ScoreAddDto input)
        {
            try
            {
                var addResult = this.repo.Add(input.SujectId, input.point);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.score));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var delResult = this.repo.Delete(id);

                if(delResult.exception != null)
                {
                    throw delResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(delResult.score));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Delete Exception id:{id}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
