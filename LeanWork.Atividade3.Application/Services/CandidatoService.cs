using Flunt.Notifications;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Domain.Entities;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services;

public class CandidatoService : ICandidatoService
{
    private readonly IGenericRepository<Candidato> candidatoRepository;

    public CandidatoService(IGenericRepository<Candidato> candidatoRepository)
    {
        this.candidatoRepository = candidatoRepository;
    }

    public async Task<ResponseModel> Atualizar(CandidatoInputModel cadastroCandidato)
    {
        cadastroCandidato.Validate();

        if (cadastroCandidato.Invalid)
        {
            return new ResponseModel(cadastroCandidato.Notifications);
        }

        var candidato = await candidatoRepository.FindAsync(c => c.Id == cadastroCandidato.Id);

        if (candidato == null)
        {
            cadastroCandidato.AddNotification("Candidato.Atualizar", "Candidato não encontrado");
            return new ResponseModel(cadastroCandidato.Notifications);
        }

        candidato.Modify(
            cadastroCandidato.VagaId,
            cadastroCandidato.Nome,
            cadastroCandidato.TecnologiasConhecidas,
            cadastroCandidato.Ativo
            );

        var resultado = await candidatoRepository.UpdateAsync(candidato).ConfigureAwait(false);

        if (!resultado)
        {
            cadastroCandidato.AddNotification("Candidato.Atualização", "Houve um erro inesperado");

            return new ResponseModel(cadastroCandidato.Notifications);
        }

        await candidatoRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<ResponseModel> Cadastrar(CandidatoInputModel cadastroCandidato)
    {
        cadastroCandidato.Validate();

        if (cadastroCandidato.Invalid)
        {
            return new ResponseModel(cadastroCandidato.Notifications);
        }

        var candidato = new Candidato(
            cadastroCandidato.VagaId,
            cadastroCandidato.Nome,
            cadastroCandidato.TecnologiasConhecidas);

        var resultado = await candidatoRepository.InsertAsync(candidato).ConfigureAwait(false);

        if (resultado is null)
        {
            cadastroCandidato.AddNotification("Candidato.Cadastro", "Houve um erro inesperado");

            return new ResponseModel(cadastroCandidato.Notifications);
        }

        await candidatoRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<IList<CandidatoInputModel>> Obter()
    {
        return candidatoRepository.FindAll(c => c.Ativo).Select(s => new CandidatoInputModel(s)).ToList();
    }

    public async Task<CandidatoInputModel> ObterPorID(int idCandidato)
    {
        var candidato = await candidatoRepository.FindAsync(t => t.Id == idCandidato);

        return new CandidatoInputModel(candidato);
    }

    public async Task<ResponseModel> Deletar(int idCandidato)
    {
        var candidato = await candidatoRepository.FindAsync(t => t.Id == idCandidato).ConfigureAwait(false);

        if (candidato is null)
        {
            var notifications = new List<Notification> { new Notification("Candidato.Deletar", "Falha ao desativar candidato") };
            return new ResponseModel(notifications);
        }

        await candidatoRepository.DeleteAsync(candidato).ConfigureAwait(false);

        return new ResponseModel();
    }
}
