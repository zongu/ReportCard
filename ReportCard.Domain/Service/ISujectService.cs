
namespace ReportCard.Domain.Service
{
    using System;
    using System.Collections.Generic;
    using ReportCard.Domain.Model;

    public interface ISujectService
    {
        (Exception exception, Suject suject) Add(string name);

        (Exception exception, Suject suject) Delete(int id);

        (Exception exception, IEnumerable<Suject> sujects) Query();

        (Exception exception, Suject suject) Update(SujectUpdateDto suject);
    }
}
