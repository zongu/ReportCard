
namespace ReportCard.Domain.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;

    public class SujectService : ISujectService
    {
        private HttpClient client;

        private string route = @"/api/Suject";

        public SujectService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {
                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, Suject suject) Add(string name)
        {
            try
            {
                var content = new StringContent(
                    new SujectAddDto()
                    {
                        Name = name
                    }.ToString(),
                    Encoding.UTF8,
                    "application/json");

                var response = this.client.PostAsync(this.route, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Suject>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Suject suject) Delete(int id)
        {
            try
            {
                var response = this.client.DeleteAsync($"{this.route}?id={id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Suject>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Suject> sujects) Query()
        {
            try
            {
                var response = this.client.GetAsync(this.route).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<IEnumerable<Suject>>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Suject suject) Update(SujectUpdateDto suject)
        {
            try
            {
                var content = new StringContent(
                    suject.ToString(),
                    Encoding.UTF8,
                    "application/json");

                var response = this.client.PutAsync(this.route, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Suject>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
