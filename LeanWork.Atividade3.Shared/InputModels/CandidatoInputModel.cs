using Flunt.Notifications;
using Flunt.Validations;
using LeanWork.Atividade3.Domain.Entities;

namespace LeanWork.Atividade3.Shared.InputModels;

public class CandidatoInputModel : Notifiable
{
    public int Id { get; set; }
    public int VagaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public List<int> TecnologiasConhecidas { get; set; } = [];
    public Dictionary<int, int>? Pontuacoes { get; set; }

    public CandidatoInputModel()
    { }

    public CandidatoInputModel(int vagaId, string nome, List<int> tecnologias)
    {
        VagaId = vagaId;
        Nome = nome;
        TecnologiasConhecidas = tecnologias;
    }

    public CandidatoInputModel(Candidato candidato)
    {
        Id = candidato.Id;
        VagaId = candidato.VagaId;
        Nome = candidato.Nome;
        TecnologiasConhecidas = candidato.TecnologiasConhecidas;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
        .Requires()
                .HasMaxLen(Nome, 8, "Candidato.Nome", "Nome inválido")
        );
    }
}
