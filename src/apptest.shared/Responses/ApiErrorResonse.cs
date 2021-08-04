namespace apptest.shared.Responses
{
    public class ApiErrorResonse
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public bool IsSuccess { get; set; }
    }

}
