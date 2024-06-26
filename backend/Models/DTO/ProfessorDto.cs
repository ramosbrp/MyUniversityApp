﻿namespace MyUniversityAPP.Models.DTO
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<DisciplinaDto> Disciplinas { get; set; }

        public ProfessorDto()
        {
            Nome = string.Empty;
            Disciplinas = new List<DisciplinaDto>();
        }
    }
}
