using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeAulas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            var navigationPage = new NavigationPage(new Views.TesteApi());

            var window = new Window(navigationPage);
            window.Title = "Gerenciador de aulas";

            return window;
        }
    }
}