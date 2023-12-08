namespace WalidMohmmedOdev1;

public partial class VicutKitleIndeksiPage : ContentPage
{
	public VicutKitleIndeksiPage()
	{
		InitializeComponent();
	}

    private void CalculateBMI_Clicked(object sender, EventArgs e)
    {
        
        try
        {
            
            double height = Convert.ToDouble(HeightEntry.Text);
            double weight = Convert.ToDouble(WeightEntry.Text);

            
            height = height / 100.0;

      
            double bmi = weight / (height * height);

            BmiResultLabel.Text = $"BMI: {bmi:F2}";

       
            string classification = GetBMIClassification(bmi);
            BmiResultLabel.Text += $"\n{classification}";
        }
        catch (Exception ex)
        {
            
            BmiResultLabel.Text = "Invalid input. Please enter numeric values for height and weight.";
        }
    }

    private string GetBMIClassification(double bmi)
    {
        if (bmi < 16)
        {
            return "Ýleri Düzeyde Zayýf.";
        }
        else if (bmi >= 16 && bmi <= 16.99)
        {
            return "Orta Düzeyde Zayýf.";
        }
        else if (bmi >= 17 && bmi <= 18.49)
        {
            return "Hafýf Düzeyde Zayýf.";
        }
        else if (bmi >= 18.50 && bmi <= 24.9)
        {
            return "Normal.";
        }
        else if (bmi >= 25 && bmi <= 29.99)
        {
            return "Fazla Kilolu.";
        }
        else if (bmi >= 30 && bmi <= 34.99)
        {
            return "1.Derece Obesity.";
        }
        else if (bmi >= 35 && bmi <= 39.99)
        {
            return "2.Derece Obesity.";
        }
        else
        {
            return "3.Derece Obesity.";
        }
    }
}