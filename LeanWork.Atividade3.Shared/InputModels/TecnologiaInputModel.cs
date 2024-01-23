using Flunt.Notifications;
using Flunt.Validations;
using LeanWork.Atividade3.Domain.Entities;

namespace LeanWork.Atividade3.Shared.InputModels;

public class TecnologiaInputModel : Notifiable
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public TecnologiaInputModel()
    { }

    public TecnologiaInputModel(string nome)
    {
        Nome = nome;
    }

    public TecnologiaInputModel(Tecnologia tecnologia)
    {
        Id = tecnologia.Id;
        Nome = tecnologia.Nome;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
        .Requires()
                .HasMaxLen(Nome, 8, "Tecnologia.Nome", "Nome inválido")
        );
    }
}
