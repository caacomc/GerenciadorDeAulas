using System.Collections.ObjectModel;
using GerenciadorDeAulas.Models;

namespace GerenciadorDeAulas.Views;

public partial class HorariosPage : ContentPage
{
    ObservableCollection<Horario> horarios = new();
    public HorariosPage()
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
            Status = StatusHorario.Ocupado,
            Disciplina = "Matemática"
        });

        horarios.Add(new Horario
        {
            HorarioTexto = "10:00",
            Status = StatusHorario.Ocupado,
            Disciplina = "História"
        });
        horarios.Add(new Horario
        {
            HorarioTexto = "14:00",
            Status = StatusHorario.Livre,
            Disciplina = "-"
        });
    }

}