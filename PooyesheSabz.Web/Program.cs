using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using PooyesheSabz.Web.Components;
using PooyesheSabz.Web.Exceptions;
using PooyesheSabz.Web.Interfaces.Providers;
using PooyesheSabz.Web.Interfaces.Repositories;
using PooyesheSabz.Web.Middlewares;
using PooyesheSabz.Web.Prividers;
using PooyesheSabz.Web.Providers;
using PooyesheSabz.Web.Repositories;

namespace PooyesheSabz.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<HttpResponseExceptionHander>();
            builder.Services.AddScoped<IHttpServiceProvider, HttpServiceProvider>();
            builder.Services.AddScoped<HttpClient>();

            //Repository
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ISupportRepository, SupportRepository>();


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, BlazorAuthorizationMiddlewareResultHandler>();

            builder.Services.AddScoped<JWTAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());


            // Add MudBlazor services
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopEnd;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddCircuitOptions(option =>
                {
                    //only add details when debugging
                    option.DetailedErrors = builder.Environment.IsDevelopment();
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
