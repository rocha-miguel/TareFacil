using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options => {
    options.AddPolicy("AngularApp", policy => {
        policy.WithOrigins(allowedOrigins!)
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.DeepSpace));

app.UseCors("AngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
