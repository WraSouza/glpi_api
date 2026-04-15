namespace Domain.Entities
{
    public class GLPILogin
    {
        public GLPILogin()
        {
            
        }

        public GLPILogin(string appToken, string authorization)
        {
            AppToken = appToken;
            Authorization = authorization;
        }

        public string AppToken { get; set; } 
        public string Authorization { get; set; } 
    }
}
