using CQRSMediaTR.API.Data.Command.Authors;
using CQRSMediaTR.API.Data.Query.Authors;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CQRSMediaTR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IStringLocalizer<SharedResource> _localizationResource;
        private readonly IMediator _mediator;

        public AuthorController(
            ILogger<AuthorController> logger,
            IStringLocalizer<SharedResource> localizationResource, IMediator mediator)
        {
            _logger = logger;
            _localizationResource = localizationResource;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("AllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            _logger.LogInformation("AuthorMaster: GetAll Started.");

            var result = await _mediator.Send(new GetAuthorListQuery());

            if (result != null && result.Count > 0)
            {
                var responseAuthorList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FOUND").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_SUCCESS,
                    IsSuccess = true,
                    Result = result,
                    Count = result.Count,
                };
                return Ok(responseAuthorList);
            }
            else
            {
                var responseAuthorList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FAIL").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_BadRequest,
                    IsSuccess = false,
                    Result = result,
                    Count = result.Count,
                };
                return Ok(responseAuthorList);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("AuthorMaster: GetById Started.");

            var result = await _mediator.Send(new GetAuthorByIdQuery() { AuthorId = id });

            if (result != null)
            {
                var responseAuthorList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FOUND").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_SUCCESS,
                    IsSuccess = true,
                    Result = result,
                };
                return Ok(responseAuthorList);
            }
            else
            {
                var responseAuthorList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FAIL").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_BadRequest,
                    IsSuccess = false,
                    Result = result
                };
                return Ok(responseAuthorList);
            }
        }

        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            _logger.LogInformation("AuthorMaster: CreateAuthor Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            var result = await _mediator.Send(
                new CreateAuthorCommand(author.FirstName, author.LastName, author.CreatedBy));

            if (result is not null)
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_SUCCESS;
                dataResponse.Message = _localizationResource.GetString("RECORD_ADDED_SUCESSFULLY").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_SUCCESS").Value;
            }
            else
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_BadRequest;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_ADD_FAIL").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_INFO").Value;
            }
            return Ok(dataResponse);
        }

        [HttpPut]
        [Route("PUT")]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            _logger.LogInformation("AuthorMaster: UpdateAuthor Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            var result = await _mediator.Send(
                new UpdateAuthorCommand(
                    author.AuthorId,
                    author.FirstName,
                    author.LastName,
                    DateTime.UtcNow, 1)
                );        

            if (result == 1)
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_SUCCESS;
                dataResponse.Message = _localizationResource.GetString("RECORD_UPDATED_SUCESSFULLY").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_SUCCESS").Value;
            }
            else
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_BadRequest;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_UPDATE_FAIL").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_INFO").Value;
            }
            return Ok(dataResponse);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            _logger.LogInformation("AuthorMaster: DeleteAuthor Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            var result = await _mediator.Send(
                new DeleteAuthorCommand() { AuthorId = id });
      
            if (result > 0)
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_SUCCESS;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_DELETED").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_SUCCESS").Value;
            }
            else
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_BadRequest;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_DELETE_FAIL").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_INFO").Value;
            }
            return Ok(dataResponse);
        }
    }
}
