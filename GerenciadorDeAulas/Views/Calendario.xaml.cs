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

        if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
        {
            lblEventos.Text = "Fim de Semana";
        }
        else if (data.Day == 1 && data.Month == 1)
        {
            lblEventos.Text = "Ano Novo 🎉";
        }
        else if (data.Month == 7)
        {
            lblEventos.Text = "Férias escolares 📚";
        }
        else if (data.Day == 8 && data.Month == 3)
        {
            lblEventos.Text = "Dia Internacional das Mulheres 🌹";
        }
        else if (data.Day == 21 && data.Month == 4)
        {
            lblEventos.Text = "Feriado Tiradentes";
        }
        else if (data.Day == 1 && data.Month == 5)
        {
            lblEventos.Text = "Dia Mundial do Trabalho ⚒️";
        }
        else if (data.Day == 7 && data.Month == 9)
        {
            lblEventos.Text = "Independência do Brasil";
        }
        else if (data.Day == 12 && data.Month == 10)
        {
            lblEventos.Text = "Dia de Nossa Senhora Aparecida 🙏❤️";
        }
        else if (data.Day == 15 && data.Month == 10)
        {
            lblEventos.Text = "Dia dos Professores 👨‍🏫";
        }
        else if (data.Day == 2 && data.Month == 11)
        {
            lblEventos.Text = "Finados";
        }
        else if (data.Day == 15 && data.Month == 11)
        {
            lblEventos.Text = "Proclamação da República";
        }
        else if (data.Day == 20 && data.Month == 11)
        {
            lblEventos.Text = "Dia Nacional de Zumbi e da Consciência Negra";
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