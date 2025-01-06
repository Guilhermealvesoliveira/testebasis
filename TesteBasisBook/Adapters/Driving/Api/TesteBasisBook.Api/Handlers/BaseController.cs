
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Handlers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMapperService _mapperService;

        protected BaseController(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        // HandleRequest: Validação, mapeamento e execução do caso de uso
        protected async Task<ActionResult> Handle<TRequest, TInputModel, TOutputModel, TResponse, TDataResponse>(
            TRequest request,
            IValidator<TRequest> validator,
            Func<TInputModel, Task<TOutputModel>> useCaseFunc,
            CancellationToken cancellationToken = default)
        {
            // Validação
            try
            {


                var validationResult = ValidateRequest(request, validator);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                // Mapeamento
                var inputModel = MapRequestToInputModel<TRequest, TInputModel>(request);


                SetQueryParamsIfPresent(inputModel);

                // Execução do caso de uso
                var output = await useCaseFunc(inputModel);

                // Mapeamento
                var response = MapOutputToResponse<TDataResponse, TOutputModel>(output);

                // Retorno usando o HandleResponse
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        protected async Task<ActionResult> Handle<TInputModel, TOutputModel, TResponse, TDataResponse>(
           Func<TInputModel, Task<TOutputModel>> useCaseFunc,
           CancellationToken cancellationToken = default) where TInputModel : new()
        {
            // Validação
            try
            {




                // Mapeamento
                var inputModel = new TInputModel();


                SetQueryParamsIfPresent(inputModel);

                // Execução do caso de uso
                var output = await useCaseFunc(inputModel);

                // Mapeamento
                var response = MapOutputToResponse<TDataResponse, TOutputModel>(output);

                // Retorno usando o HandleResponse
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        // ValidateRequest: Validação da requisição
        private ValidationResult ValidateRequest<TRequest>(TRequest request, IValidator<TRequest> validator)
        {
            return validator.Validate(request);
        }

        // MapRequestToInputModel: Mapeamento da requisição
        private TInputModel MapRequestToInputModel<TRequest, TInputModel>(TRequest request)
        {
            return _mapperService.Map<TRequest, TInputModel>(request);
        }

        private BaseResponse<TDataResponse> MapOutputToResponse<TDataResponse, TOutputModel>(TOutputModel output)
        {
            return _mapperService.Map<TOutputModel, BaseResponse<TDataResponse>>(output);
        }

        // HandleResponse: Lida com a resposta do caso de uso
        protected ActionResult HandleResponse<T>(BaseResponse<T> response)
        {
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return HandleErrorResponse(response);
        }

        // HandleErrorResponse: Tratamento de respostas de erro
        private ActionResult HandleErrorResponse<T>(BaseResponse<T> response)
        {
            if (response.GetNotFount)
            {
                return NotFound(response.Message);
            }

            if (response.BusinessRuleViolation)
            {
                return UnprocessableEntity(response);
            }

            // Erro Interno do Servidor
            return StatusCode(500, response.Message);
        }

        private void SetQueryParamsIfPresent<TInputModel>(TInputModel inputModel)
        {
            var inputModelType = typeof(TInputModel);

            foreach (var queryKey in HttpContext.Request.Query.Keys)
            {
                var queryValue = HttpContext.Request.Query[queryKey].ToString();
                var camelCaseKey = ToCamelCase(queryKey);

                var property = inputModelType.GetProperties()
                    .FirstOrDefault(p => ToCamelCase(p.Name) == camelCaseKey);

                if (property != null && !string.IsNullOrEmpty(queryValue))
                {
                    try
                    {
                        var convertedValue = ConvertToPropertyType(queryValue, property.PropertyType);
                        property.SetValue(inputModel, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        // Log or handle conversion errors if necessary
                        // Logger.LogError($"Failed to set query param {camelCaseKey} on {inputModelType.Name}: {ex.Message}");
                    }
                }
            }
        }
        private object ConvertToPropertyType(string value, Type propertyType)
        {
            if (propertyType == typeof(string))
            {
                return value;
            }
            if (propertyType == typeof(int) || propertyType == typeof(int?))
            {
                return int.TryParse(value, out var intValue) ? intValue : default(int?);
            }
            if (propertyType == typeof(bool) || propertyType == typeof(bool?))
            {
                return bool.TryParse(value, out var boolValue) ? boolValue : default(bool?);
            }
            if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
            {
                return Guid.TryParse(value, out var guidValue) ? guidValue : default(Guid?);
            }
            if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                return DateTime.TryParse(value, out var dateTimeValue) ? dateTimeValue : default(DateTime?);
            }
            if (propertyType.IsEnum)
            {
                return Enum.TryParse(propertyType, value, true, out var enumValue) ? enumValue : null;
            }

            // Handle nullable types (like int?, bool?, etc.)
            if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                var underlyingType = Nullable.GetUnderlyingType(propertyType);
                return ConvertToPropertyType(value, underlyingType);
            }

            // If no specific conversion is available, return the value as-is (or throw an exception if preferred)
            return Convert.ChangeType(value, propertyType);
        }
        private string ToCamelCase(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 2)
                return str;

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }


}
