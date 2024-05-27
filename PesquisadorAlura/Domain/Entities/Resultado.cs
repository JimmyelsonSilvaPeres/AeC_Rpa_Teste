namespace Domain.Entities
{
    public class Resultado : BaseEntity
    {
        public string Titulo { get; set; }
        public int CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public int ConsultaId { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}