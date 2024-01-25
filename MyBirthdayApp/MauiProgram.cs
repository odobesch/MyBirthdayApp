using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using MyBirthdayApp.ViewModel;
using MyBirthdayApp.Views;

namespace MyBirthdayApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                fonts.AddFont("fa-regular-400.ttf", "FaRegular");
                fonts.AddFont("fa-solid-900.ttf", "FaSolid");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<AddPage>();
        builder.Services.AddSingleton<AddViewModel>();

        builder.Services.AddSingleton<DeletePage>();
        builder.Services.AddSingleton<DeleteViewModel>();

        builder.Services.AddSingleton<EditPage>();
        builder.Services.AddSingleton<EditViewModel>();

        builder.Services.AddSingleton<DetailPage>();
        builder.Services.AddSingleton<DetailViewModel>();        

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
