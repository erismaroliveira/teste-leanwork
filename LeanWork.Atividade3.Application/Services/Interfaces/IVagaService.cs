using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services.Interfaces;

public interface IVagaService
{
    Task<ResponseModel> Atualizar(VagaInputModel cadastroVaga);
    Task<ResponseModel> Cadastrar(VagaInputModel cadastroVaga);
    Task<IList<VagaInputModel>> Obter();
    Task<VagaInputModel> ObterPorID(int idVaga);
    Task<ResponseModel> Deletar(int idVaga);
}
