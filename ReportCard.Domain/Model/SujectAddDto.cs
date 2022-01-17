
namespace ReportCard.Domain.Model
{
    using Newtonsoft.Json;

    public class SujectAddDto
    {
        public string Name { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
