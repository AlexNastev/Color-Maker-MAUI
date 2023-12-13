
using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMakerApp;

public partial class AppSingleMainPage : ContentPage
{
	bool isRandom = false;
	public AppSingleMainPage()
	{
		InitializeComponent();
	}

    private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if (!isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
		Debug.WriteLine(color.ToString());
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		lblHex.Text = color.ToHex();
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
		isRandom = true;
		var random = new Random();

		var red = random.Next(0, 256);
		var green = random.Next(0, 256);
		var blue = random.Next(0, 256);

        var color = Color.FromRgb(red, green, blue);

		SetColor(color);
		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (lblHex.Text == "#000000")
		{
            var toast = Toast.Make("Make color to copy", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
		else
		{
            await Clipboard.SetTextAsync(lblHex.Text);
			var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
			await toast.Show();
        }
    }
}