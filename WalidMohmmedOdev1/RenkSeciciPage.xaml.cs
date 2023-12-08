namespace WalidMohmmedOdev1;

public partial class RenkSeciciPage : ContentPage
{
	public RenkSeciciPage()
	{
		InitializeComponent();
       
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColorDisplay();
    }

    private void RandomButton_Clicked(object sender, EventArgs e)
    {
       
        Random rand = new Random();
        RedSlider.Value = rand.Next(256);
        GreenSlider.Value = rand.Next(256);
        BlueSlider.Value = rand.Next(256);

        
        UpdateColorDisplay();
    }

    private void UpdateColorDisplay()
    {
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

     
        ColorCodeLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";

      
        ColorDisplayFrame.BackgroundColor = Color.FromRgb(red, green, blue);
    }

}
