﻿
namespace ReportCard.Api.Client.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Api.Client.Model.SecondProcess;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Service;

    [TestClass]
    public class ScoreDeleteSecondProcessTests
    {
        [TestMethod]
        public void 移除分數測試()
        {
            var sujectSvc = new Mock<ISujectService>();
            var scoreSvc = new Mock<IScoreService>();
            var console = new Mock<IConcoleWrapper>();

            sujectSvc.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            scoreSvc.Setup(p => p.Query(null))
                .Returns((null, Enumerable.Range(1, 10).Select(index => new Score()
                {
                    f_id = index + 1,
                    f_sujectId = (index % 3) + 1,
                    f_point = index * 5 + 1
                })));

            scoreSvc.Setup(p => p.Delete(9))
                .Returns((null, new Score()
                {
                    f_id = 9,
                    f_sujectId = 1,
                    f_point = 46
                }));

            console.Setup(p => p.ReadLine())
                .Returns("9");

            var process = new ScoreDeleteSecondProcess(sujectSvc.Object, scoreSvc.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
