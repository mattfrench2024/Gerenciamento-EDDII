using Gerenciamento_EDDII.Controller;
using Gerenciamento_EDDII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_EDDII.View
{
    public class MenuView
    {
        private ProjetoController projetoController;
        private TarefaController tarefaController;

        public MenuView(ProjetoController pCtrl, TarefaController tCtrl)
        {
            projetoController = pCtrl;
            tarefaController = tCtrl;
        }

        public void ExibirMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n---- MENU ----");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar projeto");
                Console.WriteLine("2. Pesquisar projeto");
                Console.WriteLine("3. Remover projeto");
                Console.WriteLine("4. Adicionar tarefa em projeto");
                Console.WriteLine("5. Concluir tarefa");
                Console.WriteLine("6. Cancelar tarefa");
                Console.WriteLine("7. Reabrir tarefa");
                Console.WriteLine("8. Listar tarefas de um projeto");
                Console.WriteLine("9. Filtrar tarefas em um projeto");
                Console.WriteLine("10. Filtrar tarefas em todos os projetos");
                Console.WriteLine("11. Resumo geral");
                Console.Write("Escolha: ");
                string? entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcao))
                {
                    Console.WriteLine("❌ Opção inválida. Digite um número válido.");
                    opcao = -1;
                }
                Console.WriteLine();

                switch (opcao)
                {
                    case 1: projetoController.AdicionarProjeto(); break;
                    case 2: projetoController.ListarProjetos(); break;
                    case 3: projetoController.RemoverProjeto(); break;
                    case 4: tarefaController.AdicionarTarefa(); break;
                    case 5: tarefaController.AlterarStatus(StatusTarefa.Concluida); break;
                    case 6: tarefaController.AlterarStatus(StatusTarefa.Cancelada); break;
                    case 7: tarefaController.AlterarStatus(StatusTarefa.Aberta); break;
                    case 8: tarefaController.ListarTarefas(); break;
                    case 9: tarefaController.FiltrarPorStatusOuPrioridade(false); break;
                    case 10: tarefaController.FiltrarPorStatusOuPrioridade(true); break;
                    case 11: projetoController.ResumoGeral(); break;
                    case 0: Console.WriteLine("Encerrando..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            } while (opcao != 0);
        }
    }
}
