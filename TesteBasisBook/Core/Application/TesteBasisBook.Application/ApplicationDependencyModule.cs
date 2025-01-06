using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteBasisBook.Application.Services.SaleType;
using TesteBasisBook.Application.Services.SaleTypeBookPrice;
using TesteBasisBook.Application.Services.SaleTypeBookPrices;
using TesteBasisBook.Application.Services.SaleTypes;
using TesteBasisBook.Application.Services.Subjects;
using TesteBasisBook.Application.UseCases.Authors;
using TesteBasisBook.Application.UseCases.Books;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Application.UseCases.Reports;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.CreateSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.DeleteSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.GetSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.ListSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.UpdateSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.CreateSaleType;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.DeleteSaleType;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.GetSaleType;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.ListSaleType;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.UpdateSaleType;
using TesteBasisBook.Domain.Application.UseCases.Subjects.CreateSubject;
using TesteBasisBook.Domain.Application.UseCases.Subjects.DeleteSubject;
using TesteBasisBook.Domain.Application.UseCases.Subjects.GetSubject;
using TesteBasisBook.Domain.Application.UseCases.Subjects.ListSubject;
using TesteBasisBook.Domain.Application.UseCases.Subjects.UpdateSubject;

namespace TesteBasisBook.Application
{
    public static class ApplicationDependencyModule
    {
        public static IServiceCollection AddApplicationDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICreateSubjectUseCase, CreateSubjectUseCase>();
            services.AddScoped<IUpdateSubjectUseCase, UpdateSubjectUseCase>();
            services.AddScoped<IDeleteSubjectUseCase, DeleteSubjectUseCase>();
            services.AddScoped<IListSubjectUseCase, ListSubjectUseCase>();
            services.AddScoped<IGetSubjectUseCase, GetSubjectUseCase>();
            services.AddScoped<ICreateAuthorUseCase, CreateAuthorUseCase>();
            services.AddScoped<IUpdateAuthorUseCase, UpdateAuthorUseCase>();
            services.AddScoped<IDeleteAuthorUseCase, DeleteAuthorUseCase>();
            services.AddScoped<IListAuthorUseCase, ListAuthorUseCase>();
            services.AddScoped<IGetAuthorUseCase, GetAuthorUseCase>();
            services.AddScoped<ICreateBookUseCase, CreateBookUseCase>();
            services.AddScoped<IUpdateBookUseCase, UpdateBookUseCase>();
            services.AddScoped<IDeleteBookUseCase, DeleteBookUseCase>();
            services.AddScoped<IListBookUseCase, ListBookUseCase>();
            services.AddScoped<IGetBookUseCase, GetBookUseCase>();

            services.AddScoped<ICreateSaleTypeBookPriceUseCase, CreateSaleTypeBookPriceUseCase>();
            services.AddScoped<IUpdateSaleTypeBookPriceUseCase, UpdateSaleTypeBookPriceUseCase>();
            services.AddScoped<IDeleteSaleTypeBookPriceUseCase, DeleteSaleTypeBookPriceUseCase>();
            services.AddScoped<IListSaleTypeBookPriceUseCase, ListSaleTypeBookPriceUseCase>();
            services.AddScoped<IGetSaleTypeBookPriceUseCase, GetSaleTypeBookPriceUseCase>();


            services.AddScoped<ICreateSaleTypeUseCase, CreateSaleTypeUseCase>();
            services.AddScoped<IUpdateSaleTypeUseCase, UpdateSaleTypeUseCase>();
            services.AddScoped<IDeleteSaleTypeUseCase, DeleteSaleTypeUseCase>();
            services.AddScoped<IListSaleTypeUseCase, ListSaleTypeUseCase>();
            services.AddScoped<IGetSaleTypeUseCase, GetSaleTypeUseCase>();
            services.AddScoped<IGenerateReportUseCase, GenerateReportUseCase>();

            return services;
        }
    }
}
