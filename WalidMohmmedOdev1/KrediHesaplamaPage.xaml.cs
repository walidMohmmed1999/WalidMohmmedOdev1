namespace WalidMohmmedOdev1;

public partial class KrediHesaplamaPage : ContentPage
{
	public KrediHesaplamaPage()
	{
		InitializeComponent();
	}

    private void CalculateButton_Clicked(object sender, EventArgs e)
    {
        string loanType = LoanTypePicker.SelectedItem as string;
        double loanAmount = Convert.ToDouble(LoanAmountEntry.Text);
        double interestRate = Convert.ToDouble(InterestRateEntry.Text);
        int loanTerm = Convert.ToInt32(LoanTermEntry.Text);

        var result = CalculateLoan(loanType, loanAmount, interestRate, loanTerm);


        ResultLabel.Text = $"Aylık Taksit: {result.monthlyPayment:N2}₺\n" +
                   $"Toplam Ödeme: {result.totalPayment:N2}₺\n" +
                   $"Toplam Faiz: {result.totalInterest:N2}₺";

    }

    private (double monthlyPayment, double totalPayment, double totalInterest) CalculateLoan(string loanType, double loanAmount, double interestRate, int loanTerm)
    {
        double KKDF = 0; 
        double BSMV = 0; 

        
        if (loanType == "İhtiyaç Kredisi")
        {
            KKDF = 15;
            BSMV = 10;
        }
        else if (loanType == "Taşıt Kredisi")
        {
            KKDF = 15;
            BSMV = 5;
        }
        else if (loanType == "Konut Kredisi")
        {
            
        }
        else if (loanType == "Ticari Kredisi")
        {
            BSMV = 5;
        }

        double brutFaiz = ((interestRate + (interestRate * BSMV / 100) + (interestRate * KKDF / 100)) / 100);
        double taksit = ((Math.Pow(1 + brutFaiz, loanTerm) * brutFaiz) / (Math.Pow(1 + brutFaiz, loanTerm) - 1)) * loanAmount;
        double totalPayment = taksit * loanTerm;
        double totalInterest = totalPayment - loanAmount;

        return (taksit, totalPayment, totalInterest);
    }

}
