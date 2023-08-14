using Microsoft.EntityFrameworkCore;
using VatLieuXayDung_3Layer_Api.Data;
using VatLieuXayDung_3Layer_Api.Repositories;
using VatLieuXayDung_3Layer_Api.Services;

var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add services to the container.
AddDI(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>();

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

void AddDI(IServiceCollection services)
{
    services.AddScoped<KhachHangRepository>();
    services.AddScoped<IKhachHangService, KhachHangService>();
    services.AddScoped<DonHangRepository>();
    services.AddScoped<IDonHangService, DonHangService>();
    services.AddScoped<SanPhamRepsitory>();
    services.AddScoped<ISanPhamService, SanPhamService>();
    services.AddScoped<ChiTietDonHangRepository>();
    services.AddScoped<IChiTietDonHangService, ChiTietDonHangService>();
}
