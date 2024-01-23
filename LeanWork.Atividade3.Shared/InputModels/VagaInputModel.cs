using Flunt.Notifications;
using Flunt.Validations;
using LeanWork.Atividade3.Domain.Entities;

namespace LeanWork.Atividade3.Shared.InputModels;

public class VagaInputModel : Notifiable
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public bool Ativo { get; set; }

    public VagaInputModel()
    { }

    public VagaInputModel(Vaga vaga)
    {
        Id = vaga.Id;
        Titulo = vaga.Titulo;
        Ativo = vaga.Ativo;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
        .Requires()
                .HasMaxLen(Titulo, 8, "Vaga.Titulo", "Titulo inválido")
        );
    }
}
