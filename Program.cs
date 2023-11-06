var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString =
app.Configuration.GetConnectionString("DefaltuConnection");

var secrets = new Secrets();
app.Configuration.GetSection("Secrets").Bind(secrets);


app.MapGet("/", () => new
{
    ConnectionString = connectionString,
    Secrets = secrets
});
app.Run();
public class Secrets
{
    public string JwtTokenSecret { get; set; }
    public string ApiKey { get; set; }
    public string PrivateKey { get; set; }
}


