namespace CQRSMediaTR.API.Response
{
    public class GenericResponse<T> where T : class
    {
        /// <summary>
        /// Accepts and returns the output.
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Accepts and returns either Validation, Suceess or Error message
        /// </summary>
        public string? Message { get; set; } // translated message
        /// <summary>
        /// Accepts and returns either Validation, Suceess or Error message type
        /// </summary>
        public string? MessageType { get; set; }

        /// <summary>
        /// Accepts and returns the response status code (derived from ResponseStatus class)
        /// </summary>
        public string? StatusCode { get; set; } // OK or not OK code

        /// <summary>
        /// Accepts and returns the boolean tag for successful API call (including NO DATA FOUND)
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Accepts and returns the boolean tag indicating errorneous response
        /// </summary>
        public bool HasError { get; set; } // true if there any error
    }
}
