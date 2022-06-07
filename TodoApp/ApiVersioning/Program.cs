using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// updating the middlewear to use versioning
builder.Services.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = ApiVersion.Default; //new ApiVersion(1,1);
    // this is going to return all available api versions
    opt.ReportApiVersions = true;

    // add media type versioning
    opt.ApiVersionReader = ApiVersionReader.Combine(
         new HeaderApiVersionReader("x-api-version"),
         new MediaTypeApiVersionReader("x-api-version") // Accept
        ); //
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.UseAuthorization();

app.MapControllers();

app.Run();
