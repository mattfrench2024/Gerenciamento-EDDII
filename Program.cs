using Gerenciamento_EDDII.Model;
using Gerenciamento_EDDII.Controller;
using Gerenciamento_EDDII.View;

namespace Gerenciamento_EDDII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var projetos = new Projetos();
            var projetoCtrl = new ProjetoController(projetos);
            var tarefaCtrl = new TarefaController(projetos);
            var menu = new MenuView(projetoCtrl, tarefaCtrl);

            menu.ExibirMenu();
        }
    }
}
