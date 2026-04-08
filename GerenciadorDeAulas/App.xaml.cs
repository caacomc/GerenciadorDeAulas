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
            var navigationPage = new NavigationPage(new Views.MenuPage());
            Window Window = new Window(navigationPage);
            Window.Title = "Gerenciador de aulas";
            return Window;
        }
    }
}