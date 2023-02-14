namespace UzTexGroupV2.Infrastructure.Authentication;

public class JwtOptions
{
    public string Issure { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExprationInMinutes { get; set; }
}
