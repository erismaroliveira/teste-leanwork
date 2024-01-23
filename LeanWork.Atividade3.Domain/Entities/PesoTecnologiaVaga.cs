namespace LeanWork.Atividade3.Domain.Entities;

public class PesoTecnologiaVaga
{
    public int Id { get; set; }
    public int TecnologiaId { get; set; }
    public int VagaId { get; set; }
    public int Peso { get; set; }

    public PesoTecnologiaVaga()
    { }

    public PesoTecnologiaVaga(int tecnologiaId, int vagaId, int peso)
    {
        TecnologiaId = tecnologiaId;
        VagaId = vagaId;
        Peso = peso;
    }
}
