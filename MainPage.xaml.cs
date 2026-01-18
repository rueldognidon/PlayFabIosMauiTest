using PlayFab;

namespace PlayFabIosMauiTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		PlayFab.PlayFabSettings.staticSettings.TitleId = "[TitleID]"; // Please change this to your own title ID from PlayFab Game Manager
	}

	private async void LoginBtn_Clicked(object sender, EventArgs e)
	{
		try
		{
				var result = await PlayFabClientAPI.LoginWithCustomIDAsync(new PlayFab.ClientModels.LoginWithCustomIDRequest
				{
					CustomId = "GettingStartedGuide",
					CreateAccount = true
				});

				if (result.Error != null)
				{
					await DisplayAlertAsync("Error", result.Error.GenerateErrorReport(), "OK");
				}
				else
				{
					await DisplayAlertAsync("Success", "Logged in as " + result.Result.PlayFabId, "OK");
				}
		}

		catch (Exception ex)
		{
			await DisplayAlertAsync("Error", ex.Message, "OK");
		}
	}
}
