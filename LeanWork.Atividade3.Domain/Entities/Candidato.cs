using System.ComponentModel.DataAnnotations.Schema;

namespace LeanWork.Atividade3.Domain.Entities;

public class Candidato
{
    public int Id { get; set; }
    public int VagaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public List<int> TecnologiasConhecidas { get; set; } = [];
    public virtual Vaga Vaga { get; set; }
    [NotMapped]
    public Dictionary<int, int> Pontuacoes { get; set; }

    public Candidato()
    { }

    public Candidato(int idVaga, string nome, List<int> tecnologias)
    {
        VagaId = idVaga;
        Nome = nome;
        TecnologiasConhecidas = tecnologias;
        Ativo = true;
    }

    public void Modify(int vagaId, string nome, List<int> tecnologiasConhecidas, bool ativo)
    {
        VagaId = vagaId;
        Nome = nome;
        TecnologiasConhecidas = tecnologiasConhecidas;
        Ativo = ativo;
    }
}
