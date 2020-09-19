using Assigment3;
using System;
using System.Collections.Generic;
using System.Linq;
using static Assigment5.Auxiliar;

namespace Assigment5
{
  class CadastrarJF
  {
    public static class CadastroJF
    {
      public static void ExbiirJF(JulgamentoFatos JulgamentoFatos)
      {
        if (JulgamentoFatos != null)
        {
          Console.WriteLine(JulgamentoFatos.AlternativaCorreta);
          Console.WriteLine(JulgamentoFatos.ConjuntoFatos.First());
          Console.WriteLine(JulgamentoFatos.Texto);
          Console.WriteLine(JulgamentoFatos.TopicoDisciplina);
        }
        else
          Console.WriteLine("Erro ao exibir Julgamento de Fato");
      }

      public static bool CadastrarJF(int CodigoTurma, List<JulgamentoFatos> listaJulgamentoFatos, ConfiguracaoJF configuracaoJF)
      {
        if (CodigoTurma <= 0 || !listaJulgamentoFatos.Any() || configuracaoJF == null)
          return false;

        return BancoDados.salvarDb(CodigoTurma, listaJulgamentoFatos, configuracaoJF);
      }


      public static bool ValidarConfiguracaoJF(ConfiguracaoJF configuracaoJF) { 
        
        if(configuracaoJF.TamanhoMaxEquipe > 0 && (configuracaoJF.TempoMax > 0 && configuracaoJF.TempoMax < 60))
        return true;

        return false;
      
      }

      public static bool ValidarTamanhoTextoJF(string texto) 
      {
        if (texto is null)
          return false;

        if (texto.Length > 0 && texto.Length <= 50)
          return true;
        else
          return false;
      }

      public static bool AlterarStatusJF(int codJF, StatusJF novoStatusJF) 
      {
        if (codJF <= 0)
          return false;

        return BancoDados.atualizarDb(codJF, novoStatusJF);
      }

      public static bool ValidarRespoostaJF(List<JulgamentoFatos> listaJulgamentoFatos, JulgamentoFatos JFAtual)
      {
        foreach(var item in listaJulgamentoFatos)
        {
          if (item.AlternativaCorreta == JFAtual.AlternativaCorreta)
            return true;
        }
        return false;
      }

      public static void BloquearJF(List<JulgamentoFatos> listaJulgamentoFatos, StatusJF statusAtual)
      {
       if(statusAtual == StatusJF.Finalizado)
        {
          listaJulgamentoFatos.Select(s => s.Texto == "BLOQUEADO");
        }
      }

      public static void ValidarPermissaoAcessoJF(StatusJF statusAtual) {

        if (statusAtual == StatusJF.EmCriacao) 
          Console.WriteLine("Montando os JF");

        if (statusAtual == StatusJF.EmPreparacao)
          Console.WriteLine("Alunos têm acesso ao JF para formar equipes");

        if (statusAtual == StatusJF.EmExecucao)
          Console.WriteLine("Alunos têm acesso para responder ao JF");

        if (statusAtual == StatusJF.Finalizado)
          Console.WriteLine("JF concluido");
      }
    }

  }
}
