using Escola_Models;
using System.Collections.ObjectModel;

namespace GerenciadorDeAulas.Views;

public partial class GerenciarProfessores : ContentPage
{
	public ObservableCollection<Professor> ListaProfessores { get; set; }
	public GerenciarProfessores()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CadastrarProfessoresPage());
    }
}