using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_EDDII.Model
{
    public class Projetos
    {
        private List<Projeto> _itens = new List<Projeto>();

        public bool Adicionar(Projeto p)
        {
            if (_itens.Any(x => x.Id == p.Id))
                return false;

            _itens.Add(p);
            return true;
        }

        public bool Remover(Projeto p)
        {
            // só remove se não tiver tarefas
            if (p.Tarefas.Any()) return false;
            return _itens.Remove(p);
        }

        public Projeto? Buscar(int id)
        {
            return _itens.FirstOrDefault(x => x.Id == id);
        }

        public List<Projeto> Listar()
        {
            return _itens;
        }
    }
}
