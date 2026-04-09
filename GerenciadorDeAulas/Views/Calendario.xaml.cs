namespace GerenciadorDeAulas.Views;

public partial class Calendario : ContentPage
{
    public Calendario()
    {
        InitializeComponent();
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime data = e.NewDate ?? DateTime.Now;

        if (data.Day == 1 && data.Month == 1)
        {
            lblEventos.Text = "Ano Novo 🎉";
        }
        else if (data.Month == 7)
        {
            lblEventos.Text = "Férias escolares 📚";
        }
        else if (data.Day == 25 && data.Month == 12)
        {
            lblEventos.Text = "Natal 🎄";
        }
        else
        {
            lblEventos.Text = "Dia letivo normal";
        }
    }
}