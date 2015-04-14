using NDDigital.DiarioAcademia.Dominio.TurmaModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Texto.TurmaTexto
{
    public class TurmaTextoRepository : ITurmaRepository
    {
        private List<Turma> _turmas;
        private const string _arquivo = "TurmaRepository.txt";

        public TurmaTextoRepository()
        {
            if (!File.Exists(_arquivo))// Verifrica se o arquivo existe
            {
                using (var s = File.CreateText(_arquivo)) { } // Se não existe ele cria um novo
            }

            var lines = File.ReadAllLines(_arquivo); //Lê todas as linhas do arquivo

            _turmas = new List<Turma>(); //Estancia a lista

            foreach (var line in lines)
            {
                var turma = new Turma();

                var data = line.Split(';');//Separa do caracter especial

                turma.Id = Convert.ToInt16(data[0]); //Cada posição é adicionada nas respectivas
                turma.Descricao = data[1];                //propriedade do objeto
                turma.Ano = Convert.ToInt16(data[2]);

                _turmas.Add(turma); //Adiciona na lista
            }
        }

        public Turma Adicionar(Turma novaTurma)
        {
            if (!_turmas.Contains(novaTurma))
            {
                novaTurma.Id = _turmas.Count + 1;

                _turmas.Add(novaTurma);
            }

            ObjetoParaArquivo();

            return novaTurma;
        }

        public void Editar(Turma turmaEditada)
        {
            int indice = _turmas.IndexOf(turmaEditada);
            if (turmaEditada != null)
            {
                _turmas[indice] = turmaEditada;
            }
            ObjetoParaArquivo();
        }

        public Turma BuscaPorId(int id)
        {
            return _turmas.Find(p => p.Id == id);
        }

        public void Deletar(Turma turmaRemovida)
        {
            if (_turmas.Contains(turmaRemovida))
            {
                _turmas.Remove(turmaRemovida);
            }

            ObjetoParaArquivo();
        }

        public void Editar(int id)
        {
            var turmaEditada = BuscaPorId(id);
            int indice = _turmas.IndexOf(turmaEditada);
            if (turmaEditada != null)
            {
                _turmas[indice] = turmaEditada;
            }
            ObjetoParaArquivo();
        }

        public void Deletar(int id)
        {
            var turmaRemovida = BuscaPorId(id);

            if (_turmas.Contains(turmaRemovida))
            {
                _turmas.Remove(turmaRemovida);
            }

            ObjetoParaArquivo();
        }

        public IEnumerable<Turma> BuscaTodos()
        {
            return _turmas.ToList();
        }

        //Escreve os objetos da lista no arquivo.
        private void ObjetoParaArquivo()
        {
            using (StreamWriter sw = File.CreateText(_arquivo))
            {
                foreach (var turma in _turmas)
                {
                    sw.WriteLine("{0};{1};{2}",
                        turma.Id,
                        turma.Descricao,
                        turma.Ano);
                }
            }
        }

        public Turma BuscaPorTexto(string texto)
        {
            return _turmas.Find(p => p.Descricao == texto);
        }
    }
}
