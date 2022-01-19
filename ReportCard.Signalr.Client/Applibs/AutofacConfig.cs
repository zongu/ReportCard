
namespace ReportCard.Signalr.Client.Applibs
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Signalr.Client.Model;
    using ReportCard.Signalr.Client.Signalr;

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

            // 指定處理client指令的handler
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IActionHandler>())
                .Named<IActionHandler>(t => t.Name.Replace("ActionHandler", string.Empty).ToLower())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

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

            // hubclient
            builder.RegisterType<HubClient>()
                .WithParameter("url", ConfigHelper.SignalrUrl)
                .WithParameter("hubName", "ReportCardHub")
                .As<IHubClient>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            container = builder.Build();
        }
    }
}
