


using AutoMapper;
using BusinessLogic.IRepository;
using BusinessLogic.Repository;
using CarAgent;
using DataAccess.DBModels;
using DataAccess.IService;
using DataAccess.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();
builder.Services.AddTransient<IHistoryService, HistoryService>();
builder.Services.AddTransient<ISeminarParticipantsRepository, SeminarParticipantsRepository>();
builder.Services.AddTransient<ISeminarParticipantsService, SeminarParticipantsService>();
builder.Services.AddTransient<ISeminarRepository, SeminarRepository>();
builder.Services.AddTransient<ISeminarService,SeminarService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});



IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
      .AllowAnyHeader());
});
builder.Services.AddDbContext<DarceiAvotContext>(options =>
options.UseSqlServer("Server=srv2\\pupils;Database=DarceiAvot;Trusted_Connection=True;"), ServiceLifetime.Scoped);
var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
