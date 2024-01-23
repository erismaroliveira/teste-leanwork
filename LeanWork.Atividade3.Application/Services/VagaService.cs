using Flunt.Notifications;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Domain.Entities;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services;

public class VagaService : IVagaService
{
    private readonly IGenericRepository<Vaga> vagaRepository;

    public VagaService(IGenericRepository<Vaga> vagaRepository)
    {
        this.vagaRepository = vagaRepository;
    }

    public async Task<ResponseModel> Atualizar(VagaInputModel cadastroVaga)
    {
        cadastroVaga.Validate();

        if (cadastroVaga.Invalid)
        {
            return new ResponseModel(cadastroVaga.Notifications);
        }

        var vaga = await vagaRepository.FindAsync(v => v.Id == cadastroVaga.Id);

        if (vaga == null)
        {
            cadastroVaga.AddNotification("Vaga.Atualizar", "Vaga não encontrado");
            return new ResponseModel(cadastroVaga.Notifications);
        }

        vaga.Modify(
            cadastroVaga.Titulo,
            cadastroVaga.Ativo,
            DateTime.Now);

        var resultado = await vagaRepository.UpdateAsync(vaga).ConfigureAwait(false);

        if (!resultado)
        {
            cadastroVaga.AddNotification("Vaga.Atualização", "Houve um erro inesperado");

            return new ResponseModel(cadastroVaga.Notifications);
        }

        await vagaRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<ResponseModel> Cadastrar(VagaInputModel cadastroVaga)
    {
        cadastroVaga.Validate();

        if (cadastroVaga.Invalid)
        {
            return new ResponseModel(cadastroVaga.Notifications);
        }

        var vaga = new Vaga(
            cadastroVaga.Titulo,
            DateTime.Now
            );

        var resultado = await vagaRepository.InsertAsync(vaga).ConfigureAwait(false);

        if (resultado is null)
        {
            cadastroVaga.AddNotification("Tecnologia.Cadastro", "Houve um erro inesperado");

            return new ResponseModel(cadastroVaga.Notifications);
        }

        await vagaRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<IList<VagaInputModel>> Obter()
    {
        return vagaRepository.FindAll(v => v.Ativo).Select(s => new VagaInputModel(s)).ToList();
    }

    public async Task<VagaInputModel> ObterPorID(int idVaga)
    {
        var vaga = await vagaRepository.FindAsync(v => v.Id == idVaga);

        return new VagaInputModel(vaga);
    }

    public async Task<ResponseModel> Deletar(int idVaga)
    {
        var vaga = await vagaRepository.FindAsync(v => v.Id == idVaga).ConfigureAwait(false);

        if (vaga is null)
        {
            var notifications = new List<Notification> { new Notification("Vaga.Deletar", "Falha ao desativar vaga") };
            return new ResponseModel(notifications);
        }

        await vagaRepository.DeleteAsync(vaga).ConfigureAwait(false);

        return new ResponseModel();
    }
}
