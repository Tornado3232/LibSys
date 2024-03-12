namespace LibSys.Data
{
    public interface IAuthRepository
    {
        ServiceResponse<int> Register(User user, string password);
        ServiceResponse<string> Login(string userName, string password);
        bool UserExists(string userName);
    }
}
