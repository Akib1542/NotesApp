namespace NotesApp.Models
{
    public class ApiResponse
    {
        #region Fields
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        #endregion

        #region CTOR
        public ApiResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message; 
            Data = data;
        }
        #endregion
    }
}
