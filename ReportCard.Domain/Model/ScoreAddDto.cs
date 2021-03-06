
namespace ReportCard.Domain.Model
{
    using Newtonsoft.Json;

    public class ScoreAddDto
    {
        public int SujectId { get; set; }

        public int Point { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
