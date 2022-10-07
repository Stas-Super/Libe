using Libe.AccountMicroservice.Api.AppSetup;
using Libe.AccountMicroservice.Business;
using Libe.AccountMicroservice.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfiugreDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAutoMapper();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
