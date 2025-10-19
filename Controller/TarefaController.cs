using Gerenciamento_EDDII.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_EDDII.Controller
{
    public class TarefaController
    {
        private readonly Projetos _projetos;

        public TarefaController(Projetos projetos)
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

        private Projeto? SelecionarProjeto()
        {
            int id = LerInt("ID do projeto: ");
            return _projetos.Buscar(id);
        }

        public void AdicionarTarefa()
        {
            var projeto = SelecionarProjeto();
            if (projeto == null)
            {
                Console.WriteLine("❌ Projeto não encontrado.");
                return;
            }

            int id = LerInt("ID da tarefa: ");
            string desc = LerString("Descrição: ");
            string prioridade = LerString("Prioridade (Baixa/Média/Alta): ");

            projeto.Tarefas.Add(new Tarefa(id, desc, prioridade));
            Console.WriteLine("✅ Tarefa adicionada com sucesso!");
        }

        public void AlterarStatus(StatusTarefa novoStatus)
        {
            var projeto = SelecionarProjeto();
            if (projeto == null)
            {
                Console.WriteLine("❌ Projeto não encontrado.");
                return;
            }

            int id = LerInt("ID da tarefa: ");
            var tarefa = projeto.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                Console.WriteLine("❌ Tarefa não encontrada.");
                return;
            }

            tarefa.Status = novoStatus;
            Console.WriteLine($"✅ Tarefa marcada como {novoStatus}.");
        }

        public void ListarTarefas()
        {
            var projeto = SelecionarProjeto();
            if (projeto == null)
            {
                Console.WriteLine("❌ Projeto não encontrado.");
                return;
            }

            if (projeto.Tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa neste projeto.");
                return;
            }

            Console.WriteLine($"\n--- Tarefas do Projeto: {projeto.Nome} ---");
            foreach (var t in projeto.Tarefas)
                Console.WriteLine(t);
        }

        public void FiltrarPorStatusOuPrioridade(bool emTodos)
        {
            Console.Write("Filtrar por (1) Status ou (2) Prioridade? ");
            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int op) || (op != 1 && op != 2))
            {
                Console.WriteLine("❌ Opção inválida.");
                return;
            }

            string filtro = "";
            StatusTarefa? statusFiltro = null;

            if (op == 1)
            {
                Console.Write("Status (Aberta/Concluida/Cancelada): ");
                filtro = Console.ReadLine() ?? "";
                if (!Enum.TryParse(filtro, true, out StatusTarefa status))
                {
                    Console.WriteLine("❌ Status inválido.");
                    return;
                }
                statusFiltro = status;
            }
            else
            {
                filtro = LerString("Prioridade (Baixa/Média/Alta): ");
            }

            var projetoSelecionado = SelecionarProjeto();
            var listaProjetos = emTodos
                ? _projetos.Listar()
                : (projetoSelecionado != null ? new List<Projeto> { projetoSelecionado } : new List<Projeto>());


            foreach (var p in listaProjetos)
            {
                if (p == null) continue;

                var filtradas = (op == 1)
                    ? p.Tarefas.Where(t => t.Status == statusFiltro)
                    : p.Tarefas.Where(t => t.Prioridade.Equals(filtro, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"\n📁 Projeto: {p.Nome}");
                if (!filtradas.Any())
                    Console.WriteLine("Nenhuma tarefa encontrada com o filtro especificado.");
                else
                    foreach (var t in filtradas)
                        Console.WriteLine(t);
            }
        }
    }
}
