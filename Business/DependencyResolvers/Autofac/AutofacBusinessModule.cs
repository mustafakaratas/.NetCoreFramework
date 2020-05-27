using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
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

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtTokenHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}
