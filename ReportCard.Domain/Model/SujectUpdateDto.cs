
namespace ReportCard.Domain.Model
{
    using Newtonsoft.Json;

    public class SujectUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
