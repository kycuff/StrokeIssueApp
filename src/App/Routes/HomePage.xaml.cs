using App.Resources.Styles;

namespace App.Routes;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	void Switch_Toggled(object sender, ToggledEventArgs e)
	{
		Application.Current!.Resources = themeSwitch.IsToggled ? new DarkTheme() : new LightTheme();
	}
}