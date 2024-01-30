using CleanArchitecture.Persistence.Data;
//using CleanArchitecture.Application.Services.CompanyService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
//using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Infrastructure.Implementation;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProduceService, ProduceService>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<IReportService, ReportService>();

//builder.Services.AddMediatR(typeof(StartupBase));

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
