using CalculadoraIR.Domain.Entities;
using CalculadoraIR.Domain.Repositories;
using CalculadoraIR.Domain.Services.Input;
using CalculadoraIR.Domain.Services.Result;
using CalculadoraIR.Shared.Command;
using CalculadoraIR.Shared.ValueObjects;
using FluentValidator;
using System;
using System.Linq;

namespace CalculadoraIR.Domain.Services
{
    public class ContribuinteService : 
        Notifiable,
        ICommandHandle<CadastrarContribuinteInput, CadastrarContribuinteResult>,
        ICommandHandle<CalcularIRInput, CalcularIRResult>
    {
        private readonly IContribuinteRepository _contribuinteRepository;

        public ContribuinteService(IContribuinteRepository contribuinteRepository)
        {
            _contribuinteRepository = contribuinteRepository;
        }

        public CadastrarContribuinteResult Handle(CadastrarContribuinteInput input)
        {
            CadastrarContribuinteResult result = new CadastrarContribuinteResult();

            try
            {
                // Cria a instância de Contribuinte
                Contribuinte contribuinte = Contribuinte.Novo(input.Nome, Cpf.Create(input.Cpf), input.RendaBrutaMensal, input.NumeroDeDependentes);

                // Adiciona as notificações do contribuinte ao serviço
                base.AddNotifications(contribuinte.Notifications);

                // Valida se existe alguma notificação
                if(base.IsValid())
                {
                    // Consulta se já existe um usuário cadastrado com o respectivo CPF
                    var consultaBanco = _contribuinteRepository.ObterPorCpf(contribuinte.Cpf);

                    // Se não existir, realiza o cadastro na base de dados
                    // Se existir, adiciona a notificação ao serviço.
                    if (consultaBanco == null)
                    {
                        _contribuinteRepository.Criar(contribuinte);

                        result.Id = contribuinte.Id;
                    }
                    else
                        base.AddNotification(nameof(Contribuinte), "Contribuinte já cadastrado na base de dados");
                }
            }
            catch (Exception ex)
            {
                base.AddNotification("Error", $"Houve uma falha inesperada! Mensagem: {ex.Message}");
            }

            return result;
        }

        public CalcularIRResult Handle(CalcularIRInput input)
        {
            CalcularIRResult result = new CalcularIRResult();

            try
            {
                // Recupera os contribuintes da base de dados
                var contribuintes = _contribuinteRepository.ObterTodos();

                // Varre todos os contribuintes da base de dados.
                foreach(var contribuinte in contribuintes)
                {
                    // Cria um novo imposto
                    var imposto = ImpostoDeRenda.Novo(contribuinte, input.SalarioMinimo);

                    // Verifica se o imposto está válido
                    if (imposto.IsValid())
                        result.ContribuintesImpostoDeRenda.Add(imposto);
                    else
                        base.AddNotifications(imposto.Notifications);
                }

                // Ordena o resultado.
                result.ContribuintesImpostoDeRenda = 
                    result.ContribuintesImpostoDeRenda.OrderByDescending(x => x.Imposto)
                          .ThenByDescending(x => x.Contribuinte.Nome).ToList();
            }
            catch (Exception ex)
            {
                base.AddNotification("Error", $"Houve uma falha inesperada! Mensagem: {ex.Message}");
            }

            return result;
        }
    }
}
