namespace Domain.Entities
{
    public class GLPIResponse(string session_token)
    {
        public string session_token { get; set; } = session_token;
    }
}
