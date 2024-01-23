using Flunt.Notifications;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Domain.Entities;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services;

public class TecnologiaService : ITecnologiaService
{
    private readonly IGenericRepository<Tecnologia> tecnologiaRepository;

    public TecnologiaService(IGenericRepository<Tecnologia> candidatoRepository)
    {
        this.tecnologiaRepository = candidatoRepository;
    }

    public async Task<ResponseModel> Atualizar(TecnologiaInputModel cadastroTecnologia)
    {
        cadastroTecnologia.Validate();

        if (cadastroTecnologia.Invalid)
        {
            return new ResponseModel(cadastroTecnologia.Notifications);
        }

        var tecnologia = await tecnologiaRepository.FindAsync(t => t.Id == cadastroTecnologia.Id);

        if (tecnologia == null)
        {
            cadastroTecnologia.AddNotification("Tecnologia.Atualizar", "Tecnologia não encontrado");
            return new ResponseModel(cadastroTecnologia.Notifications);
        }

        tecnologia.Modify(cadastroTecnologia.Nome);

        var resultado = await tecnologiaRepository.UpdateAsync(tecnologia).ConfigureAwait(false);

        if (!resultado)
        {
            cadastroTecnologia.AddNotification("Tecnologia.Atualização", "Houve um erro inesperado");

            return new ResponseModel(cadastroTecnologia.Notifications);
        }

        await tecnologiaRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<ResponseModel> Cadastrar(TecnologiaInputModel cadastroTecnologia)
    {
        cadastroTecnologia.Validate();

        if (cadastroTecnologia.Invalid)
        {
            return new ResponseModel(cadastroTecnologia.Notifications);
        }

        var tecnologia = new Tecnologia(
            cadastroTecnologia.Nome
            );

        var resultado = await tecnologiaRepository.InsertAsync(tecnologia).ConfigureAwait(false);

        if (resultado is null)
        {
            cadastroTecnologia.AddNotification("Tecnologia.Cadastro", "Houve um erro inesperado");

            return new ResponseModel(cadastroTecnologia.Notifications);
        }

        await tecnologiaRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    public async Task<IList<TecnologiaInputModel>> Obter()
    {
        return tecnologiaRepository.FindAll(t => t != null).Select(s => new TecnologiaInputModel(s)).ToList();
    }

    public async Task<TecnologiaInputModel> ObterPorID(int idTecnologia)
    {
        var tecnologia = await tecnologiaRepository.FindAsync(t => t.Id == idTecnologia);

        return new TecnologiaInputModel(tecnologia);
    }

    public async Task<ResponseModel> Deletar(int idTecnologia)
    {
        var tecnologia = await tecnologiaRepository.FindAsync(t => t.Id == idTecnologia).ConfigureAwait(false);

        if (tecnologia is null)
        {
            var notifications = new List<Notification> { new Notification("Tecnologia.Deletar", "Falha ao desativar tecnologia") };
            return new ResponseModel(notifications);
        }

        await tecnologiaRepository.DeleteAsync(tecnologia).ConfigureAwait(false);

        return new ResponseModel();
    }
}
