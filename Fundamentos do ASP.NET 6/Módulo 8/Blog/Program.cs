using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);

builder.Services.AddMemoryCache();

builder.Services.AddResponseCompression(options =>
{
    // options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    // options.Providers.Add<CustomCompressionProvider>();
});
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Optimal;
});

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<EmailService>();

var app = builder.Build();

LoadConfiguration(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseResponseCompression();
app.UseAuthorization();

app.MapControllers();

app.Run();

void LoadConfiguration(WebApplication app)
{
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("Smtp").Bind(smtp);
    Configuration.Smtp = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, // Validar chave de assinatura? true
            IssuerSigningKey = new SymmetricSecurityKey(key), // Como validar? Nova chave simétrica
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}