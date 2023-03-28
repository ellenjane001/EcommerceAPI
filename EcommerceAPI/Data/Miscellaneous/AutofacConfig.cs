using Autofac;
using EcommerceAPI.CQRS.Commands.CartItemCommands;
using EcommerceAPI.CQRS.Commands.OrderCommands;
using EcommerceAPI.CQRS.Commands.UserCommands;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Domain.Interfaces;
using EcommerceAPI.Domain.Repositories;
using EcommerceAPI.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data.Miscellaneous
{
    public class AutofacConfig : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public AutofacConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CheckoutRepository>().As<ICheckoutRepository>().InstancePerLifetimeScope();

            //Validation
            builder.RegisterType<AddCartItemValidator>().As<IValidator<AddCartItemCommand>>().InstancePerDependency();
            builder.RegisterType<UpdateCartItemValidator>().As<IValidator<PutCartItemCommand>>().InstancePerDependency();
            builder.RegisterType<CreateUserValidator>().As<IValidator<AddUserCommand>>().InstancePerDependency();
            builder.RegisterType<OrderValidator>().As<IValidator<PutOrderCommand>>().InstancePerDependency();

            //Dapper
            builder.RegisterType<AppDapperContext>().SingleInstance();

            //Database EF core
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));
                return new AppDBContext(optionsBuilder.Options);
            }).As<AppDBContext>().InstancePerLifetimeScope();
        }
    }
}
