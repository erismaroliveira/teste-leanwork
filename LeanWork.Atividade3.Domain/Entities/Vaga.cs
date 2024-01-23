namespace LeanWork.Atividade3.Domain.Entities;

public class Vaga
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public List<Candidato> Candidatos { get; set; }

    public Vaga()
    { }

    public Vaga(string titulo, DateTime dataCadastro)
    {
        Titulo = titulo;
        DataCadastro = dataCadastro;
        Ativo = true;
    }

    public void Modify(string titulo, bool ativo, DateTime dataAtualizacao)
    {
        Titulo = titulo;
        Ativo = ativo;
        DataAtualizacao = dataAtualizacao;
    }

    public void Desativar()
    {
        Ativo = false;
        DataAtualizacao = DateTime.Now;
    }
}
