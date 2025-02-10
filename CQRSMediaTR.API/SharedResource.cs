namespace CQRSMediaTR.API
{
    public class SharedResource
    {
        private SharedResource()
        {
        }
        public const string StatusUnauthorizedAccess = "STATUS_UNAUTHORIZED_ACCESS";
        public const string StatusUnauthorizedUser = "STATUS_UNAUTHORIZED_USER";
        public const string StatusXssDetected = "STATUS_XSS_DETECTED";
        public const string StatusDataFound = "STATUS_DATA_FOUND";
        public const string StatusDataFail = "STATUS_DATA_FAIL";
        public const string StatusSuccess = "STATUS_SUCCESS";
        public const string StatusDataUpdateFail = "STATUS_DATA_UPDATE_FAIL";
        public const string StatusCodeExist = "STATUS_CODE_EXIST";
        public const string StatusDescriptionExist = "STATUS_DESCRIPTION_EXIST";
        public const string StatusDisplayExist = "STATUS_DISPLAY_EXIST";

        public const string StatusOtherLanguageDisplayExist = "STATUS_OTHERLANGUAGEDISPLAY_EXIST";
        public const string StatusCodeDescriptionExist = "STATUS_CODE_DESCRIPTION_EXIST";
    }
}
