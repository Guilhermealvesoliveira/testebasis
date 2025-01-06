using AutoMapper;
using TesteBasisBook.Api.Dtos.Authors.Request;
using TesteBasisBook.Api.Dtos.Authors.Response;
using TesteBasisBook.Api.Dtos.Books.Request;
using TesteBasisBook.Api.Dtos.Books.Response;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(BaseOutputModel<>), typeof(BaseResponse<>))
      .ForMember("IsSuccess", opt => opt.MapFrom("IsSuccess"))
      .ForMember("Data", opt => opt.MapFrom("Data"))
      .ForMember("Message", opt => opt.MapFrom("Message"))
      .ForMember("BusinessRuleViolation", opt => opt.MapFrom("BusinessRuleViolation"))
      .ForMember("GetNotFount", opt => opt.MapFrom("GetNotFount"));

            CreateMap<CreateSubjectRequest, CreateSubjectInput>();
            CreateMap<CreateSubjectOutput, CreateSubjectResponse>();
            CreateMap<UpdateSubjectRequest, UpdateSubjectInput>();
            CreateMap<UpdateSubjectOutput, UpdateSubjectResponse>();
            CreateMap<DeleteSubjectOutput, DeleteSubjectResponse>();
            CreateMap<GetSubjectOutput, GetSubjectResponse>();
            CreateMap<GetSubjectOutputData, GetSubjectResponseData>();
            CreateMap<ListSubjectOutput, ListSubjectResponse>();
            CreateMap<ListSubjectOutputData, ListSubjectResponseData>();

            CreateMap<CreateAuthorRequest, CreateAuthorInput>();
            CreateMap<CreateAuthorOutput, CreateAuthorResponse>();
            CreateMap<UpdateAuthorRequest, UpdateAuthorInput>();
            CreateMap<UpdateAuthorOutput, UpdateAuthorResponse>();
            CreateMap<DeleteAuthorOutput, DeleteAuthorResponse>();
            CreateMap<GetAuthorOutput, GetAuthorResponse>();
            CreateMap<GetAuthorOutputData, GetAuthorResponseData>();
            CreateMap<ListAuthorOutput, ListAuthorResponse>();
            CreateMap<ListAuthorOutputData, ListAuthorResponseData>();

            CreateMap<CreateBookRequest, CreateBookInput>();
            CreateMap<CreateBookOutput, CreateBookResponse>();
            CreateMap<UpdateBookRequest, UpdateBookInput>();
            CreateMap<UpdateBookOutput, UpdateBookResponse>();
            CreateMap<DeleteBookOutput, DeleteBookResponse>();
            CreateMap<GetBookOutput, GetBookResponse>();
            CreateMap<GetBookOutputData, GetBookResponseData>();
            CreateMap<ListBookOutput, ListBookResponse>();
            CreateMap<ListBookOutputData, ListBookResponseData>();

            CreateMap<CreateSaleTypeBookPriceRequest, CreateSaleTypeBookPriceInput>();
            CreateMap<CreateSaleTypeBookPriceOutput, CreateSaleTypeBookPriceResponse>();
            CreateMap<UpdateSaleTypeBookPriceRequest, UpdateSaleTypeBookPriceInput>();
            CreateMap<UpdateSaleTypeBookPriceOutput, UpdateSaleTypeBookPriceResponse>();
            CreateMap<DeleteSaleTypeBookPriceOutput, DeleteSaleTypeBookPriceResponse>();
            CreateMap<GetSaleTypeBookPriceOutput, GetSaleTypeBookPriceResponse>();
            CreateMap<GetSaleTypeBookPriceOutputData, GetSaleTypeBookPriceResponseData>();
            CreateMap<ListSaleTypeBookPriceOutput, ListSaleTypeBookPriceResponse>();
            CreateMap<ListSaleTypeBookPriceOutputData, ListSaleTypeBookPriceResponseData>();

            CreateMap<CreateSaleTypeRequest, CreateSaleTypeInput>();
            CreateMap<CreateSaleTypeOutput, CreateSaleTypeResponse>();
            CreateMap<UpdateSaleTypeRequest, UpdateSaleTypeInput>();
            CreateMap<UpdateSaleTypeOutput, UpdateSaleTypeResponse>();
            CreateMap<DeleteSaleTypeOutput, DeleteSaleTypeResponse>();
            CreateMap<GetSaleTypeOutput, GetSaleTypeResponse>();
            CreateMap<GetSaleTypeOutputData, GetSaleTypeResponseData>();
            CreateMap<ListSaleTypeOutput, ListSaleTypeResponse>();
            CreateMap<ListSaleTypeOutputData, ListSaleTypeResponseData>();
        }
    }
}
