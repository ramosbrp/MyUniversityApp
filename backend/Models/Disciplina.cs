﻿namespace MyUniversityAPP.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CursoId { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual List<Matricula> Matriculas { get; set; }

        public Disciplina()
        {
            Nome = string.Empty;
            Curso = new Curso();
            Professor = new Professor();
            Matriculas = new List<Matricula>();
        }


    }
}
