using aspnetcore.Services;
using common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInMemoryFiltering, InMemoryFiltering>();
builder.Services.AddScoped<IZipFiles, ZipFiles>();
builder.Services.AddScoped<IFindText, FindText>();
builder.Services.AddScoped<IStudentSerializer, StudentSerializer>();
builder.Services.AddScoped<IReflectionReader, ReflectionReader>();


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
app.UseStaticFiles();

app.Run();
