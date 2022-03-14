namespace PersonManagement.Services.Abstractions
{
    public interface IJWTService
    {
        string GenerateSecurityToken(string userName);
    }
}
