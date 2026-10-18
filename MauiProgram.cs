using duNotes.Services;
using duNotes.ViewModels;
using duNotes.Views;
using Microsoft.Extensions.Logging;

namespace duNotes;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Services
		builder.Services.AddSingleton<AuthService>();
		builder.Services.AddSingleton<DocumentService>();
		builder.Services.AddSingleton<OfflineService>();

		// ViewModels
		builder.Services.AddTransient<AccueilViewModel>();
		builder.Services.AddTransient<ExplorerViewModel>();
		builder.Services.AddTransient<RechercheViewModel>();
		builder.Services.AddTransient<DepotViewModel>();
		builder.Services.AddTransient<DetailDocumentViewModel>();
		builder.Services.AddTransient<ApercuViewModel>();
		builder.Services.AddTransient<HorsLigneViewModel>();
		builder.Services.AddTransient<ConnexionViewModel>();
		builder.Services.AddTransient<InscriptionViewModel>();
		builder.Services.AddTransient<NotationViewModel>();

		// Views
		builder.Services.AddTransient<AccueilPage>();
		builder.Services.AddTransient<ExplorerPage>();
		builder.Services.AddTransient<RecherchePage>();
		builder.Services.AddTransient<DepotPage>();
		builder.Services.AddTransient<DetailDocumentPage>();
		builder.Services.AddTransient<ApercuPage>();
		builder.Services.AddTransient<HorsLignePage>();
		builder.Services.AddTransient<ConnexionPage>();
		builder.Services.AddTransient<InscriptionPage>();
		builder.Services.AddTransient<NotationPage>();

		return builder.Build();
	}
}