using Autofac;
using PostgreSql.Business.Abstract;
using PostgreSql.Business.Concrete;
using PostgreSql.DataAccess.Abstract;
using PostgreSql.DataAccess.Concrete.EntityFramework;

namespace PostgreSql.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfExampleRepository>().As<IExampleRepository>().SingleInstance();
            builder.RegisterType<ExampleManager>().As<IExampleService>().SingleInstance();
        }
    }
}
