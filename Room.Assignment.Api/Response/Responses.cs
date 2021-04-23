namespace Room.Assignment.Api.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class Responses<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] ValidationError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="validation"></param>
        public Responses(T data, string message, string[] validation)
        {
            Data = data;
            Message = message;
            ValidationError = validation;
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public static class ResponseExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="validationError"></param>
        /// <returns></returns>
        public static Responses<T> ToResponse<T>(this T data, string message = "", string[] validationError = default)
        {
            return new(data, message, validationError);
        }
    }
}
