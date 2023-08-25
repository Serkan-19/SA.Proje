using Microsoft.Extensions.DependencyInjection;
using SA.Business.Implemantation;
using SA.Business.Interface;
using SA.Business.Profiles;
using SA.DataAccess.EF.Repositories;
using SA.DataAccess.Interfaces;

namespace SA.Business
{
    public static class ServicesColectionExtentions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderBs, OrderBs>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeBs, EmployeeBs>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerBs, CustomerBs>();


            services.AddAutoMapper(typeof(OrderMapperProfile).Assembly);//aynı zamanda DI yapmamızı sağlıyor
            services.AddAutoMapper(typeof(EmployeeMapperProfile).Assembly);//aynı zamanda DI yapmamızı sağlıyor
            services.AddAutoMapper(typeof(CustomerMapperProfile).Assembly);//aynı zamanda DI yapmamızı sağlıyor

        }
    }
}
