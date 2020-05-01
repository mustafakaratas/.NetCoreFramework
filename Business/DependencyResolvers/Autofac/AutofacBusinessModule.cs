using Autofac;
using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
        }
    }
}
