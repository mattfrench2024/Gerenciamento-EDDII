using Gerenciamento_EDDII.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_EDDII.Controller
{
    public class ProjetoController
    {
        private readonly Projetos _projetos;

        public ProjetoController(Projetos projetos)
        {
            _projetos = projetos;
        }

        private static int LerInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int valor))
                    return valor;

                Console.WriteLine("❌ Valor inválido. Digite um número inteiro.");
            }
        }

        private static string LerString(string mensagem)
        {
            Console.Write(mensagem);
            string? valor = Console.ReadLine();
            return valor ?? string.Empty;
        }

        public void AdicionarProjeto()
        {
            int id = LerInt("ID do projeto: ");
            string nome = LerString("Nome do projeto: ");

            var projeto = new Projeto(id, nome);
            if (_projetos.Adicionar(projeto))
                Console.WriteLine("✅ Projeto adicionado com sucesso!");
            else
                Console.WriteLine("⚠️ ID já existente!");
        }

        public void RemoverProjeto()
        {
            int id = LerInt("ID do projeto a remover: ");
            var projeto = _projetos.Buscar(id);

            if (projeto == null)
            {
                Console.WriteLine("❌ Projeto não encontrado.");
                return;
            }

            if (_projetos.Remover(projeto))
                Console.WriteLine("✅ Projeto removido com sucesso.");
            else
                Console.WriteLine("⚠️ Não é possível remover projeto com tarefas associadas.");
        }

        public void ListarProjetos()
        {
            var lista = _projetos.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum projeto cadastrado.");
                return;
            }

            Console.WriteLine("\n--- Lista de Projetos ---");
            foreach (var p in lista)
                Console.WriteLine(p);
        }

        public void ResumoGeral()
        {
            var lista = _projetos.Listar();
            int totalProjetos = lista.Count;
            int abertas = lista.Sum(p => p.ContarPorStatus(StatusTarefa.Aberta));
            int concluidas = lista.Sum(p => p.ContarPorStatus(StatusTarefa.Concluida));
            int canceladas = lista.Sum(p => p.ContarPorStatus(StatusTarefa.Cancelada));

            double percentual = (abertas + concluidas) > 0
                ? (double)concluidas / (abertas + concluidas) * 100
                : 0;

            Console.WriteLine("\n📊 --- Resumo Geral ---");
            Console.WriteLine($"Projetos Totais: {totalProjetos}");
            Console.WriteLine($"Tarefas Abertas: {abertas}");
            Console.WriteLine($"Tarefas Concluídas: {concluidas}");
            Console.WriteLine($"Tarefas Canceladas: {canceladas}");
            Console.WriteLine($"Percentual Concluídas: {percentual:F1}%\n");
        }
    }
}
