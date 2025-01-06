using AutoMapper;
using FluentValidation;
using TesteBasisBook.Api.Dtos.Authors.Request;
using TesteBasisBook.Api.Dtos.Books.Request;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Mappings;
using TesteBasisBook.Api.Validators.Author;
using TesteBasisBook.Api.Validators.Authors;
using TesteBasisBook.Api.Validators.Book;
using TesteBasisBook.Api.Validators.Books;
using TesteBasisBook.Api.Validators.SaleType;
using TesteBasisBook.Api.Validators.SaleTypeBookPrice;
using TesteBasisBook.Api.Validators.SaleTypeBookPrices;
using TesteBasisBook.Api.Validators.SaleTypes;
using TesteBasisBook.Api.Validators.Subjects;
using TesteBasisBook.Application;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Reports.Services;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.PostgreSQL;
using TesteBasisBook.ReportViewer.Services;


public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder
                    .WithOrigins("http://localhost:4200") // Substitua pelo domínio do front-end
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPostgreSQLDependencyModule(builder.Configuration);

        // Injection dependency
        builder.Services.AddScoped<IValidator<CreateSubjectRequest>, CreateSubjectValidator>();
        builder.Services.AddScoped<IValidator<UpdateSubjectRequest>, UpdateSubjectValidator>();
        builder.Services.AddScoped<IReportGenerateService, ReportGenerateService> ();
        builder.Services.AddScoped<IValidator<CreateAuthorRequest>, CreateAuthorValidator>();
        builder.Services.AddScoped<IValidator<UpdateAuthorRequest>, UpdateAuthorValidator>();
        builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookValidator>();
        builder.Services.AddScoped<IValidator<UpdateBookRequest>, UpdateBookValidator>();

        builder.Services.AddScoped<IValidator<CreateSaleTypeBookPriceRequest>, CreateSaleTypeBookPriceValidator>();
        builder.Services.AddScoped<IValidator<UpdateSaleTypeBookPriceRequest>, UpdateSaleTypeBookPriceValidator>();

        builder.Services.AddScoped<IValidator<CreateSaleTypeRequest>, CreateSaleTypeValidator>();
        builder.Services.AddScoped<IValidator<UpdateSaleTypeRequest>, UpdateSaleTypeValidator>();

        builder.Services.AddApplicationDependencyModule(builder.Configuration);
        // Auto Mapper Configurations
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddScoped<IMapperService, MapperService>();


        var app = builder.Build();
        app.UseCors("AllowSpecificOrigin"); // Ativa o middleware CORS

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}


