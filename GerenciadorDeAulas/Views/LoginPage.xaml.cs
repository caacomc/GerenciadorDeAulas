using Escola_Models;

namespace GerenciadorDeAulas.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var nome = NomeEntry.Text;
        var senha = SenhaEntry.Text;

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlertAsync ("Erro", "Preencha todos os campos", "OK");
            return;
        }

        var usuario = new Usuario
        {
            Nome_Usuario = nome,
            DataAdmissao = DateTime.Now
        };

        await Navigation.PushAsync(new ProfessorProfilePage(usuario));
    }
}