using CQRSMediaTR.API;
using CQRSMediaTR.API.Controllers;
using CQRSMediaTR.API.Data.Command.Authors;
using CQRSMediaTR.API.Models.Dto;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;

namespace CQRSMediaTR.APIUnitTest.ControllerUnitTest
{
    public class AuthorControllerUnitTest
    {
        private Mock<ILogger<AuthorController>> _logger;
        private Mock<IStringLocalizer<SharedResource>> _localizationResource;
        private Mock<IMediator> _mediator;
        private AuthorController _controller;

        string key_STATUS_DATA_FOUND = "STATUS_DATA_FOUND";
        string value_STATUS_DATA_FOUND = "Data found";
        string key_STATUS_DATA_FAIL = "STATUS_DATA_FAIL";
        string value_STATUS_DATA_FAIL = "Record Not Found";
        string key_MESSAGE_DATA_NOT_FOUND = "MESSAGE_DATA_NOT_FOUND";
        string key_MESSAGE_DATA_FOUND = "MESSAGE_DATA_FOUND";
        string value_MESSAGE_DATA_NOT_FOUND = "Record not found";
        string value_MESSAGE_DATA_FOUND = "Record found";
        string key_MESSAGETYPE_INFO = "MESSAGETYPE_INFO";
        string key_MESSAGETYPE_SUCCESS = "MESSAGETYPE_SUCCESS";
        string value_MESSAGETYPE_INFO = "INFO";
        string value_MESSAGETYPE_SUCCESS = "SUCCESS";
        string key_STATUS_DATA_ADD_FAIL = "STATUS_DATA_ADD_FAIL";
        string value_STATUS_DATA_ADD_FAIL = "Record Not Added";
        string key_RECORD_ADDED_SUCESSFULLY = "RECORD_ADDED_SUCESSFULLY";
        string value_RECORD_ADDED_SUCESSFULLY = "Record Added Successfully";

        public AuthorControllerUnitTest()
        {
            _logger = new Mock<ILogger<AuthorController>>();
            _localizationResource = new Mock<IStringLocalizer<SharedResource>>();
            _mediator = new Mock<IMediator>();

            var localizedString_Record_Added_Successfully = new LocalizedString(key_RECORD_ADDED_SUCESSFULLY, value_RECORD_ADDED_SUCESSFULLY);
            _localizationResource.Setup(x => x[key_RECORD_ADDED_SUCESSFULLY]).Returns(localizedString_Record_Added_Successfully);

            var localizedString_Status_Data_Add_Fail = new LocalizedString(key_STATUS_DATA_ADD_FAIL, value_STATUS_DATA_ADD_FAIL);
            _localizationResource.Setup(x => x[key_STATUS_DATA_ADD_FAIL]).Returns(localizedString_Status_Data_Add_Fail);

            var localizedString_MessageType_Success = new LocalizedString(key_MESSAGETYPE_SUCCESS, value_MESSAGETYPE_SUCCESS);
            _localizationResource.Setup(x => x[key_MESSAGETYPE_SUCCESS]).Returns(localizedString_MessageType_Success);

            var localizedString_MessageType_Info = new LocalizedString(key_MESSAGETYPE_INFO, value_MESSAGETYPE_INFO);
            _localizationResource.Setup(x => x[key_MESSAGETYPE_INFO]).Returns(localizedString_MessageType_Info);

            var localizedString_Message_Data_Found = new LocalizedString(key_MESSAGE_DATA_FOUND, value_MESSAGE_DATA_FOUND);
            _localizationResource.Setup(x => x[key_MESSAGE_DATA_FOUND]).Returns(localizedString_Message_Data_Found);

            var localizedString_Message_Data_Not_Found = new LocalizedString(key_MESSAGE_DATA_NOT_FOUND, value_MESSAGE_DATA_NOT_FOUND);
            _localizationResource.Setup(x => x[key_MESSAGE_DATA_NOT_FOUND]).Returns(localizedString_Message_Data_Not_Found);


            _controller = new AuthorController(_logger.Object, _localizationResource.Object, _mediator.Object);
        }

        #region "Add Author"
        [Fact]
        public async Task AddAuthor_Success()
        {
            //Arrange   

            AddAuthorRequestDto result = new AddAuthorRequestDto
            {
                FirstName = "Test",
                LastName = "Test",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now
            };        
        }
        #endregion
    }
}
