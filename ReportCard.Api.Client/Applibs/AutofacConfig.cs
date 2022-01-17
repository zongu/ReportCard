
namespace ReportCard.Api.Client.Applibs
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Domain.Model.SecondProcess;

    internal static class AutofacConfig
    {
        private static IContainer container;

        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    Register();
                }

                return container;
            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            // firstProcess
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IFirstProcess>())
                .Keyed<IFirstProcess>(p => (FistProcessType)Enum.Parse(typeof(FistProcessType), p.Name.Replace("FirstProcess", string.Empty), true))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // secondProcess
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<ISecondProcess>())
                .Keyed<ISecondProcess>(p => (SecondProcessType)Enum.Parse(typeof(SecondProcessType), p.Name.Replace("SecondProcess", string.Empty), true))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // console wrapper
            builder.RegisterType<ConcoleWrapper>()
                .As<IConcoleWrapper>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // service
            builder.RegisterAssemblyTypes(Assembly.Load("ReportCard.Domain"))
                .WithParameter("serviceUri", ConfigHelper.ServiceUrl)
                .WithParameter("timeout", 5)
                .Where(t => t.Namespace == "ReportCard.Domain.Service")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"))
                .SingleInstance();

            container = builder.Build();
        }
    }
}
