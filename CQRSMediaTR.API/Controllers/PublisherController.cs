using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Data.Command.Publishers;
using CQRSMediaTR.API.Data.Query.Publishers;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CQRSMediaTR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly IStringLocalizer<SharedResource> _localizationResource;
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public PublisherController(
            ILogger<PublisherController> logger,
            IStringLocalizer<SharedResource> localizationResource, 
            IMediator mediator,
            ApplicationDbContext context)
        {
            _logger = logger;
            _localizationResource = localizationResource;
            _mediator = mediator;
            _context = context;
        }
        [HttpGet]
        [Route("AllPublisher")]
        public async Task<IActionResult> GetAllPublisher()
        {
            _logger.LogInformation("PublisherMaster: GetAll Started.");

            var result = await _mediator.Send(new GetPublishersListQuery());

            if (result != null && result.Count > 0)
            {
                var responsePublisherList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FOUND").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_SUCCESS,
                    IsSuccess = true,
                    Result = result,
                    Count = result.Count,
                };
                return Ok(responsePublisherList);
            }
            else
            {
                var responsePublisherList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FAIL").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_BadRequest,
                    IsSuccess = false,
                    Result = result,
                    Count = result.Count,
                };
                return Ok(responsePublisherList);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("PublisherMaster: GetById Started.");

            var result = await _mediator.Send(new GetPublishersByIdQuery() { PublisherID = id });

            if (result != null)
            {
                var responsePublisherList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FOUND").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_SUCCESS,
                    IsSuccess = true,
                    Result = result,
                };
                return Ok(responsePublisherList);
            }
            else
            {
                var responsePublisherList = new DataResponse
                {
                    Message = _localizationResource.GetString("STATUS_DATA_FAIL").Value ?? "",
                    StatusCode = ErrorStatusCode.STATUS_BadRequest,
                    IsSuccess = false,
                    Result = result
                };
                return Ok(responsePublisherList);
            }
        }

        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> AddPublisher(Publisher publisher)
        {
            _logger.LogInformation("PublisherMaster: CreatePublisher Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            bool isDuplicate = _context.Publishers.Where(x => x.Name == publisher.Name).Any();

            if (isDuplicate)
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_BadRequest;
                dataResponse.HasError = true;
                dataResponse.IsSuccess = false;
                dataResponse.Message = _localizationResource.GetString("STATUS_DUPLICATE_RECORD").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_VALIDATION").Value;
            }
            else
            {
                var result = await _mediator.Send(
                    new CreatePublisherCommand(publisher.Name, publisher.Address, publisher.Phone, publisher.Email, publisher.CreatedBy));

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
            return Ok(dataResponse);
        }

        [HttpPut]
        [Route("PUT")]
        public async Task<IActionResult> UpdatePublisher(Publisher publisher)
        {
            _logger.LogInformation("PublisherMaster: UpdatePublisher Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            var result = await _mediator.Send(
                new UpdatePublisherCommand(
                    publisher.PublisherID,
                    publisher.Name,
                    publisher.Address,
                    publisher.Email,
                    publisher.Phone,
                    1,
                    DateTime.UtcNow                    
                    )
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
        public async Task<IActionResult> DeletePublisher(int id)
        {
            _logger.LogInformation("PublisherMaster: DeletePublisher Started.");

            GenericResponse<string> dataResponse = new() { IsSuccess = true };

            var result = await _mediator.Send(
                new DeletePublisherCommand() { PublisherId = id });

            if (result > 0)
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_SUCCESS;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_DELETED").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_SUCCESS").Value;
            }
            else
            {
                dataResponse.StatusCode = ErrorStatusCode.STATUS_BadRequest;
                dataResponse.HasError = true;
                dataResponse.IsSuccess = false;
                dataResponse.Message = _localizationResource.GetString("STATUS_DATA_DELETE_FAIL").Value;
                dataResponse.MessageType = _localizationResource.GetString("MESSAGETYPE_INFO").Value;
            }
            return Ok(dataResponse);
        }
    }
}
