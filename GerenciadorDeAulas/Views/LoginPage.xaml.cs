using Escola_Models;
using GerenciadorDeAulas.Services;

namespace GerenciadorDeAulas.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var LoginService = new LoginService();
        Usuario? user = null;

        var nome = NomeEntry.Text;
        var senha = SenhaEntry.Text;

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlertAsync("Erro", "Preencha todos os campos", "OK");
            return;
        }

        try
        {
            user = await LoginService.Login(nome, senha);
        }
        catch (Exception ex) {await DisplayAlertAsync("Erro", "Algo deu errado no login, tente novamente.", "OK"); }

        if (user != null) 
        {
            
            var usuario = new Usuario
            {
                Nome_Usuario = user.Nome_Usuario,
                DataAdmissao = user.DataAdmissao
            };
            if (user.ID_cargo == TipoCargo.Professor)
            {
                await Navigation.PushAsync(new ProfessorProfilePage(usuario));
            }
            else if (user.ID_cargo == TipoCargo.Coordenador)
            {
                await Navigation.PushAsync(new CoordenadorProfilePage(usuario));
            }

            
        }else {await DisplayAlertAsync("Erro", "Algo deu errado no login, tente novamente.", "OK"); }
        
    }
}