﻿
namespace ReportCard.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Model.SecondProcess;

    [TestClass]
    public class SujectUpdateSecondProcessTests
    {
        [TestMethod]
        public void 更新科目測試()
        {
            var repo = new Mock<ISujectRepository>();
            var console = new Mock<IConcoleWrapper>();

            repo.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            repo.Setup(p => p.Update(It.IsAny<Suject>()))
                .Returns((null, new Suject()
                {
                    f_id = 2,
                    f_name = "update-2"
                }));

            console.SetupSequence(p => p.ReadLine())
                .Returns("2")
                .Returns("update-2");

            var proecess = new SujectUpdateSecondProcess(repo.Object, console.Object);
            var result = proecess.Execute();

            Assert.IsTrue(result);
        }
    }
}
