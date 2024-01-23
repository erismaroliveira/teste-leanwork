using Flunt.Notifications;
using Flunt.Validations;

namespace LeanWork.Atividade3.Shared.InputModels;

public class PesoTecnologiaVagaInputModel : Notifiable
{
    public int TecnologiaId { get; set; }
    public int VagaId { get; set; }
    public int Peso { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
        .Requires()
                .IsNotNull(Peso, "PesoTecnologiaVaga.Peso", "Informe o peso da tecnologia")
        );
    }
}
