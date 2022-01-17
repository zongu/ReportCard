
namespace ReportCard.Domain.Service
{
    using System;
    using System.Collections.Generic;
    using ReportCard.Domain.Model;

    public interface IScoreService
    {
        (Exception exception, Score score) Add(ScoreAddDto request);

        (Exception exception, Score score) Delete(int id);

        (Exception exception, IEnumerable<Score> scores) Query(int? sujectId);
    }
}
