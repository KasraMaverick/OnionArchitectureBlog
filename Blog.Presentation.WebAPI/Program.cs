using B.Application;
using B.Application.Contracts.ArticleCategory;
using B.Domain.ArticleCategoryAgg;
using B.Infrastructure.Core;
using B.Infrastructure.EfCore;
using B.Infrastructure.EfCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("BlogDb"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
