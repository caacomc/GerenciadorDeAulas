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
            var navigationPage = new NavigationPage(new Views.LoginPage());

            var window = new Window(navigationPage);
            window.Title = "Gerenciador de aulas";
            window.Width = 450;
            window.Height = 650;

            return window;
        }
    }
}