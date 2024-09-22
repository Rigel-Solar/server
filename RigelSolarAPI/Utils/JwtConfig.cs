namespace RigelSolarAPI.Utils;

public class JwtConfig
{
    public IConfiguration _config;
    public string SecretKey { get; private set; }
    public int ExpirationTimeInMinutes { get; private set; }
    public string Issuer { get; private set; }
    public string Audience { get; private set; }

    public JwtConfig(IConfiguration config)
    {
        _config = config;
        SecretKey = _config.GetSection("JwtSettings").GetValue<string>("SecretKey")!;
        ExpirationTimeInMinutes = int.Parse(_config.GetSection("JwtSettings").GetValue<string>("ExpirationTimeInMinutes")!);
        Issuer = _config.GetSection("JwtSettings").GetValue<string>("Issuer")!;
        Audience = _config.GetSection("JwtSettings").GetValue<string>("Audience")!;
    }
}