using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services.Interfaces;

public interface ITecnologiaService
{
    Task<ResponseModel> Atualizar(TecnologiaInputModel cadastroTecnologia);
    Task<ResponseModel> Cadastrar(TecnologiaInputModel cadastroTecnologia);
    Task<IList<TecnologiaInputModel>> Obter();
    Task<TecnologiaInputModel> ObterPorID(int idTecnologia);
    Task<ResponseModel> Deletar(int idTecnologia);
}
