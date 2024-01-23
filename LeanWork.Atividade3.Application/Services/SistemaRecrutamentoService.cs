using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Domain.Entities;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services;

public class SistemaRecrutamentoService : ISistemaRecrutamentoService
{
    private readonly IGenericRepository<PesoTecnologiaVaga> pesoTecnologiaVagaRepository;
    private readonly IGenericRepository<Vaga> vagaRepository;
    private readonly IGenericRepository<Candidato> candidatoRepository;

    public SistemaRecrutamentoService(IGenericRepository<PesoTecnologiaVaga> pesoTecnologiaVagaRepository, IGenericRepository<Vaga> vagaRepository, IGenericRepository<Candidato> candidatoRepository, IVagaService vagaService)
    {
        this.pesoTecnologiaVagaRepository = pesoTecnologiaVagaRepository;
        this.vagaRepository = vagaRepository;
        this.candidatoRepository = candidatoRepository;
    }

    public async Task<ResponseModel> CadastrarPesoTecnologiaVaga(PesoTecnologiaVagaInputModel cadastroPesoTecnologia)
    {
        cadastroPesoTecnologia.Validate();

        if (cadastroPesoTecnologia.Invalid)
        {
            return new ResponseModel(cadastroPesoTecnologia.Notifications);
        }

        var pesoTecnologiaVaga = new PesoTecnologiaVaga(
            cadastroPesoTecnologia.TecnologiaId,
            cadastroPesoTecnologia.VagaId,
            cadastroPesoTecnologia.Peso);

        var resultado = await pesoTecnologiaVagaRepository.InsertAsync(pesoTecnologiaVaga).ConfigureAwait(false);

        if (resultado is null)
        {
            cadastroPesoTecnologia.AddNotification("PesoTecnologia.Cadastro", "Houve um erro inesperado");

            return new ResponseModel(cadastroPesoTecnologia.Notifications);
        }

        await pesoTecnologiaVagaRepository.SaveAsync().ConfigureAwait(false);

        return new ResponseModel();
    }

    private Dictionary<int, int> CalcularPontuacoes(List<int> tecnologiasConhecidas, int vagaId)
    {
        var pontuacoes = new Dictionary<int, int>();

        var vaga = vagaRepository.Find(vagaId);

        if (vaga != null)
        {
            foreach (var tecnologiaId in tecnologiasConhecidas)
            {
                // obter o peso da tecnologia para a vaga específica
                var peso = ObterPesoTecnologiaParaVaga(tecnologiaId, vagaId);

                // Atribuir pontuação com base no peso
                pontuacoes.Add(tecnologiaId, peso);
            }
        }

        return pontuacoes;
    }

    private int ObterPesoTecnologiaParaVaga(int tecnologiaId, int vagaId)
    {
        // obter o peso da tecnologia para a vaga específica
        var peso = pesoTecnologiaVagaRepository
            .Find(p => p.TecnologiaId.Equals(tecnologiaId) && p.VagaId.Equals(vagaId));

        return peso?.Peso ?? 1; // Se não encontrar, atribui um peso padrão de 1
    }

    public async Task<List<CandidatoInputModel>> GerarRelatorioPontuacao()
    {
        var candidatosOrdenados = new List<CandidatoInputModel>();

        var candidatos = candidatoRepository.FindAll(c => c.Ativo).Select(s => new CandidatoInputModel(s)).ToList();

        foreach (var candidato in candidatos)
        {
            candidato.Pontuacoes = CalcularPontuacoes(candidato.TecnologiasConhecidas, candidato.VagaId);
            candidatosOrdenados.Add(candidato);
        }
        candidatosOrdenados = candidatosOrdenados.OrderByDescending(c => c.Pontuacoes.Values.Sum()).ToList();

        return candidatosOrdenados;
    }
}
