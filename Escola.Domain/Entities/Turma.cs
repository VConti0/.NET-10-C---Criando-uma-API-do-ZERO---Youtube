using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities
{
     public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CursoId { get; set; }
        public bool Excluido { get; set; } 
        public Curso Curso { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
