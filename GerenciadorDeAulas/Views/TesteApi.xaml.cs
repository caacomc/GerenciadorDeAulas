using Escola_Models;
using GerenciadorDeAulas.Services;

namespace GerenciadorDeAulas.Views;

public partial class TesteApi : ContentPage
{
	public TesteApi()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var BuscaUsuario = new LoginService();
		NetworkAccess accessType = Connectivity.Current.NetworkAccess;
		if (accessType != NetworkAccess.Internet)
		{
			await DisplayAlertAsync("Sem conexão", "Por favor, conecte-se a uma rede de internet para realizar a pesquisa.", "OK");
            return;
        }

		try
		{
			if (!string.IsNullOrEmpty(txt_user.Text) && !string.IsNullOrEmpty(txt_senha.Text)) 
			{
				Usuario? u = await BuscaUsuario.Login(txt_user.Text, txt_senha.Text);
				if (u != null) 
				{
					string User = $"Nome: {u.Nome_Usuario} \n" +
						$"ID Cargo: {u.ID_Cargo} \n" +
						$"Email: {u.Email} \n" +
						$"Senha: {u.SenhaUsuario}";

					lbl_res.Text = User;
				}
			}
		}
		catch (Exception ex)
		{
			lbl_res.Text = ex.Message;
		}
    }
}