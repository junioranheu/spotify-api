using Microsoft.Extensions.FileProviders;
using Spotify.API;
using Spotify.API.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDependencyInjection(builder);

    // Habilitar API por IP em vez de apenas localhost: https://stackoverflow.com/questions/69532898/asp-net-core-6-0-kestrel-server-is-not-working;
    if (builder.Environment.IsDevelopment())
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            // Exemplo: https://192.168.8.211:7225/api/Musicas/todos, https://192.168.8.214:7225/api/Musicas/todos 
            options.ListenAnyIP(7225, c => c.UseHttps());
            options.ListenAnyIP(7226);
        });
    }
}

var app = builder.Build();
{
    // Iniciar banco;
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<Context>();

            // Iniciar o banco de dados, indo para o DbInitializer.cs;
            await DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            string erroBD = ex.Message.ToString();
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify v1");
            c.DocExpansion(DocExpansion.None); // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/279
        });

        app.UseDeveloperExceptionPage();
    }

    // Redirecionar sempre para HTTPS;
    if (app.Environment.IsProduction())
    {
        app.UseHttpsRedirection();
    }

    // Cors;
    app.UseCors(builder.Configuration["CORSSettings:Cors"] ?? string.Empty);

    // Comprimir resposta;
    app.UseResponseCompression();

    // Outros;
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    // Habilitar static files para exibir as imagens da API: https://youtu.be/jSO5KJLd5Qk?t=86;
    IWebHostEnvironment env = app.Environment;
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Upload")),
        RequestPath = "/Upload",

        // CORS: https://stackoverflow.com/questions/61152499/dotnet-core-3-1-cors-issue-when-serving-static-image-files;
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
        }
    });

    app.Run();
}

// Deixar o Program.cs public para o xUnit;
public partial class Program { }