using GerenciadorDeAulas.Models;
using System.Collections.ObjectModel;

namespace GerenciadorDeAulas.Views;

public partial class GerenciarAulasCoordenador : ContentPage
{
    // Lista principal com todos os horários
    ObservableCollection<Horario> horarios = new();

    // Listas para os Pickers
    List<string> professores = new() { "Todos", "Ana", "Carlos", "Mariana", "João" };
    List<string> disciplinas = new() { "Todas", "Matemática", "História", "Português", "Física", "Química", "Inglês" };
    List<string> salas = new() {  "Lab 1", "Lab 2", "Sala 101", "Sala 102", "Auditório" };

    // Dias da semana (colunas)
    List<string> dias = new() { "Seg", "Ter", "Qua", "Qui", "Sex" };

    // Horários (linhas)
    List<string> horas = new() { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };

    // Guarda a célula selecionada
    Frame celulaSelecionada;

    // Guarda qual horário foi selecionado
    string horarioSelecionado = "";
    string diaSelecionado = "";

    public GerenciarAulasCoordenador()
    {
        InitializeComponent();

        // Carrega Pickers
        CarregarPickers();


        // Desenha a grade
        MontarGrade();
    }


    // CARREGA PICKERS
    void CarregarPickers()
    {
        pickerFiltroProfessor.ItemsSource = professores;
        pickerFiltroDisciplina.ItemsSource = disciplinas;
        pickerFiltroSala.ItemsSource = salas;

        pickerProfessor.ItemsSource = professores;
        pickerDisciplina.ItemsSource = disciplinas;

        // Seleção padrão
        pickerFiltroProfessor.SelectedIndex = 0;
        pickerFiltroDisciplina.SelectedIndex = 0;
        pickerFiltroSala.SelectedIndex = 0;
       
    }

    
    // MONTA GRADE
 
    void MontarGrade()
    {
        gradeSemanal.Children.Clear();
        gradeSemanal.RowDefinitions.Clear();
        gradeSemanal.ColumnDefinitions.Clear();

        // Coluna do horário
        gradeSemanal.ColumnDefinitions.Add(new ColumnDefinition { Width = 90 });

        // Colunas dos dias
        for (int i = 0; i < dias.Count; i++)
            gradeSemanal.ColumnDefinitions.Add(new ColumnDefinition { Width = 130 });

        // Cabeçalho
        gradeSemanal.RowDefinitions.Add(new RowDefinition { Height = 50 });

        // Linhas dos horários
        for (int i = 0; i < horas.Count; i++)
            gradeSemanal.RowDefinitions.Add(new RowDefinition { Height = 90 });

        // Cabeçalho vazio
        AddCabecalho("Horário", 0);

        // Cabeçalhos dias
        for (int i = 0; i < dias.Count; i++)
            AddCabecalho(dias[i], i + 1);

        // Monta linhas
        for (int linha = 0; linha < horas.Count; linha++)
        {
            // Horário
            AddHorario(horas[linha], linha + 1);

            // Células
            for (int coluna = 0; coluna < dias.Count; coluna++)
            {
                CriarCelula(horas[linha], dias[coluna], linha + 1, coluna + 1);
            }
        }
    }

    // Cabeçalho
    void AddCabecalho(string texto, int coluna)
    {
        var label = new Label
        {
            Text = texto,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black
        };

        gradeSemanal.Add(label, coluna, 0);
    }

    // Horários
    void AddHorario(string texto, int linha)
    {
        var label = new Label
        {
            Text = texto,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black
        };

        gradeSemanal.Add(label, 0, linha);
    }

    // Cria célula
    void CriarCelula(string hora, string dia, int linha, int coluna)
    {
        // Procura aula existente
        var aula = horarios.FirstOrDefault(h =>
            h.HorarioTexto == hora &&
            h.DiaSemana == dia &&
            h.Sala == pickerFiltroSala.SelectedItem?.ToString());

        string texto = aula == null
            ? "-"
            : $"{aula.Disciplina}\n{aula.Professor}";

        var label = new Label
        {
            Text = texto,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            TextColor = Colors.Black
        };

        var frame = new Frame
        {
            BackgroundColor = Colors.White,
            Padding = 5,
            Content = label
        };

        // Clique na célula
        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) =>
        {
            // Desmarca anterior
            if (celulaSelecionada != null)
                celulaSelecionada.BackgroundColor = Colors.White;

            // Marca atual
            frame.BackgroundColor = Colors.LightPink;
            celulaSelecionada = frame;

            horarioSelecionado = hora;
            diaSelecionado = dia;

            // Preenche formulário se existir aula
            if (aula != null)
            {
                pickerProfessor.SelectedItem = aula.Professor;
                pickerDisciplina.SelectedItem = aula.Disciplina;
            }
            else
            {
                pickerProfessor.SelectedItem = null;
                pickerDisciplina.SelectedItem = null;
            }
        };

        frame.GestureRecognizers.Add(tap);

        gradeSemanal.Add(frame, coluna, linha);
    }

 
    // FILTRAR
    void Filtrar_Clicked(object sender, EventArgs e)
    {
        MontarGrade();
    }

    
    // SALVAR
    void SalvarAula_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(horarioSelecionado) || string.IsNullOrEmpty(diaSelecionado))
        {
            DisplayAlert("Aviso", "Selecione uma célula primeiro.", "OK");
            return;
        }

        var sala = pickerFiltroSala.SelectedItem?.ToString();

        var aula = horarios.FirstOrDefault(h =>
            h.HorarioTexto == horarioSelecionado &&
            h.DiaSemana == diaSelecionado &&
            h.Sala == sala);

        if (aula == null)
        {
            horarios.Add(new Horario
            {
                HorarioTexto = horarioSelecionado,
                DiaSemana = diaSelecionado,
                Sala = sala,
                Professor = pickerProfessor.SelectedItem?.ToString(),
                Disciplina = pickerDisciplina.SelectedItem?.ToString(),
                Status = StatusHorario.Ocupado
            });
        }
        else
        {
            aula.Professor = pickerProfessor.SelectedItem?.ToString();
            aula.Disciplina = pickerDisciplina.SelectedItem?.ToString();
        }

        MontarGrade();
    }

    // REMOVER
  
    void RemoverAula_Clicked(object sender, EventArgs e)
    {
        var sala = pickerFiltroSala.SelectedItem?.ToString();

        var aula = horarios.FirstOrDefault(h =>
            h.HorarioTexto == horarioSelecionado &&
            h.DiaSemana == diaSelecionado &&
            h.Sala == sala);

        if (aula != null)
            horarios.Remove(aula);

        MontarGrade();
    }
}