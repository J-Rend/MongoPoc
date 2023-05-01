using BookStoreApi.CrossCutting;
using BookStoreApi.domain.Arguments.Settings.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

// Project implementation
// --IT'S NOT DEFAULT--
builder.Configuration
    .GetSection(nameof(BookStoreDatabaseSettings))
    .Get<BookStoreDatabaseSettings>();

builder.Services.RegisterDependencies();
// --IT'S NOT DEFAULT--

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
