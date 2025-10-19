using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_EDDII.Model
{
    public enum StatusTarefa { Aberta, Concluida, Cancelada }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; } // Baixa, Média, Alta
        public StatusTarefa Status { get; set; }

        public Tarefa(int id, string descricao, string prioridade)
        {
            Id = id;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = StatusTarefa.Aberta;
        }

        public override string ToString()
        {
            return $"{Id}. {Descricao} [{Prioridade}] - {Status}";
        }
    }
}

