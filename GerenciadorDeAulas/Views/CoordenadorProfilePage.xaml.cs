using Escola_Models;

namespace GerenciadorDeAulas.Views;

public partial class CoordenadorProfilePage : ContentPage
{
	public CoordenadorProfilePage(Usuario usuario)
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
        await Navigation.PushAsync(new GerenciarAulasPage());
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GerenciarProfessores());
    }
}