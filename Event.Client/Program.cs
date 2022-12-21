using Event.Business.Interface;
using Event.Data.MainContext;
using Event.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
);


builder.Services.AddTransient<DBContext, DBContext>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<ICitiesRepository, CitiesRepository>();
builder.Services.AddTransient<ISpeakerRepository, SpeakerRepository>();
builder.Services.AddTransient<ITalkDetailsRepository, TalkDetailsRepository>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
