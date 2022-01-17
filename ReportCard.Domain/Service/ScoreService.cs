
namespace ReportCard.Domain.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;

    public class ScoreService : IScoreService
    {
        private HttpClient client;

        private string route = @"/api/Score";

        public ScoreService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {
                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, Score score) Add(ScoreAddDto request)
        {
            try
            {
                var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Score>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Score score) Delete(int id)
        {
            try
            {
                var response = this.client.DeleteAsync($"{this.route}?id={id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return (null, JsonConvert.DeserializeObject<Score>(result));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Score> scores) Query(int? sujectId)
        {
            try
            {
                var response = this.client.GetAsync($"{this.route}?sujectId={sujectId}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return (null, JsonConvert.DeserializeObject<IEnumerable<Score>>(result));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
