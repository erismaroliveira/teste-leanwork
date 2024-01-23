namespace LeanWork.Atividade3.Domain.Entities;

public class Tecnologia
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public Tecnologia()
    { }

    public Tecnologia(string nome)
    {
        Nome = nome;
    }

    public void Modify(string nome)
    {
        Nome = nome;
    }
}
