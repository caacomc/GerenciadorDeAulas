using GerenciadorDeAulas.Models;
namespace GerenciadorDeAulas.Views;

public partial class ProfessorProfilePage : ContentPage
{
    public ProfessorProfilePage(Usuario usuario)
    {
        InitializeComponent();
        BindingContext = usuario;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Calendario());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GerenciarAulasCoordenador());
    }

}