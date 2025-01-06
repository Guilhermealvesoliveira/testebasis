using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;
using TesteBasisBook.PostgreSQL.EF;
using TesteBasisBook.PostgreSQL.Repositories;

namespace TesteBasisBook.PostgreSQL
{
    public static class PostgreSQLDependencyModule
    {
        public static IServiceCollection AddPostgreSQLDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                   options.UseNpgsql(configuration.GetConnectionString("DB_POSTGRESQL"))
                   .UseLowerCaseNamingConvention()
                   );
            services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(configuration.GetConnectionString("DB_POSTGRESQL")));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>(); services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISubjectBookRepository, SubjectBookRepository>(); services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>(); services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISaleTypeRepository, SaleTypeRepository>(); services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISaleTypeBookPriceRepository, SaleTypeBookPriceRepository>(); services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
