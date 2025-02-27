using System.Data.SqlTypes;
using ConvinenceStore.Business.Interface;
using ConvinenceStore.Business.Provider;
using Microsoft.EntityFrameworkCore;
using ConvinenceStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//SQL CONFIGURATION
builder.Services.AddDbContext<ConvinenceStoreContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlString"))
);

//CORS CONFIGURATION
builder.Services.AddCors(opt =>
    opt.AddPolicy(name: "MyCors", builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host=="localhost")
        .AllowAnyHeader().AllowAnyMethod();
    })
);

//DEPENDENCIES INJECTION;
builder.Services.AddScoped<ILogin,LoginProvider>();
builder.Services.AddScoped<IProduct,ProductProvider>();
builder.Services.AddScoped<ISale,SaleProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("MyCors");
app.MapControllers();

app.Run();
