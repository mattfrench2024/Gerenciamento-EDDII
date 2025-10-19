using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_EDDII.Model
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; }

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Tarefas = new List<Tarefa>();
        }

        public override string ToString()
        {
            return $"{Id}. {Nome} - {Tarefas.Count} tarefa(s)";
        }

        public int ContarPorStatus(StatusTarefa status)
        {
            return Tarefas.Count(t => t.Status == status);
        }
    }
}
