namespace Risk_Business_Layer.Services.Authentication
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }

    public class CreatedUser : AuthModel
    {
        public string ID_Created { get; set; }
    }
}
 