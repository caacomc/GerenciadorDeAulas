using System.Collections.ObjectModel;

namespace GerenciadorDeAulas.Views;

public partial class MenuPage : ContentPage
{
	public ObservableCollection<string> DiasSemana { get; set; }
	public MenuPage()
	{
		InitializeComponent();

		DiasSemana = new ObservableCollection<string>
		{
			"Segunda-Feira", "Terça-Feira","Quarta-Feira", "Quinta-Feira",
            "Sexta-Feira", "Adicionar Final de Semana"
        };

		lst_dias.ItemsSource = DiasSemana;
	}

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
		var swipeItem = sender as SwipeItem;
		var itemSelecionado = swipeItem.BindingContext as string;

		if(itemSelecionado != null)
		{
			try
			{
				await Navigation.PushAsync(new Views.HorariosPage
				{
					BindingContext = itemSelecionado
				});
			}
			catch (Exception ex)
			{
				DisplayAlertAsync("OPS", ex.Message, "OK");
			}
		}
    }
}