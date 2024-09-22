namespace RigelSolarAPI.Utils;

public class TokenResponse
{
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
    public UserAccessLevel UserAccess { get; set; }
}

public enum UserAccessLevel
{
    Tecnico, // 0
    Gestor, // 1
    Coordenador // 2
}

