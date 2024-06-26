﻿namespace MyUniversityAPP.Models.DTO
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<DisciplinaDto> Disciplinas { get; set; }

        public CursoDto()
        {
            Nome = string.Empty;
            Disciplinas = new List<DisciplinaDto>();
        }

    }
}
