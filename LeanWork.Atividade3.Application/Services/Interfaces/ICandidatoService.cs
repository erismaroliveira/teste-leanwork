using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services.Interfaces;

public interface ICandidatoService
{
    Task<ResponseModel> Atualizar(CandidatoInputModel cadastroCandidato);
    Task<ResponseModel> Cadastrar(CandidatoInputModel cadastroCandidato);
    Task<IList<CandidatoInputModel>> Obter();
    Task<CandidatoInputModel> ObterPorID(int idCandidato);
    Task<ResponseModel> Deletar(int idCandidato);
}
