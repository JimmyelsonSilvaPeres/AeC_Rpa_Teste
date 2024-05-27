namespace Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Resultado> Resultados { get; set; }
    }
}