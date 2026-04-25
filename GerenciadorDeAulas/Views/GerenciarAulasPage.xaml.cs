using GerenciadorDeAulas.Models;
using System.Collections.ObjectModel;
namespace GerenciadorDeAulas.Views;

public partial class GerenciarAulasPage : ContentPage
{
    ObservableCollection<Horario> horarios = new();
    Horario horarioSelecionado;

    public GerenciarAulasPage()
	{
		InitializeComponent();
        CarregarHorarios();
        gradeHorarios.ItemsSource = horarios;
    }

    void CarregarHorarios()
    {
        horarios.Add(new Horario
        {
            HorarioTexto = "08:00",
            Status = StatusHorario.Livre
        });

        horarios.Add(new Horario
        {
            HorarioTexto = "09:00",
            Status = StatusHorario.Ocupado
        });

        horarios.Add(new Horario
        {
            HorarioTexto = "10:00",
            Status = StatusHorario.Livre
        });
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync ("Selecionado", "Horário escolhido!", "OK");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await DisplayAlertAsync ("Adicionar", "Abrir tela de cadastro", "OK");
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await DisplayAlertAsync ("Remover", "Remover aula selecionada", "OK");
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {

    }
}