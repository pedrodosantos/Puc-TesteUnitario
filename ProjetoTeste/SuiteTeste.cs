using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assigment3;
using System.Collections.Generic;
using Assigment5;

namespace ProjetoTeste
{
  [TestClass]
  public class SuiteTeste
  {

    [TestMethod]
    [DataRow("Pedro", "pedro@mail.com", "pedro123", "123ABC!", TipoUsuario.Aluno)]
    [DataRow("Artur", "artur@htomail.com", "132artuh", "ABC123zd@", TipoUsuario.Aluno)]

    public void casoTeste1_CriarConta_Sucesso(string Nome, string Email, string Login, string Senha, TipoUsuario tpUsuario)
    {
      bool status = CadastroUsuario.CriarConta(Nome, Email, Login, Senha, tpUsuario);
      Assert.IsTrue(status);
    }


    [TestMethod]
    [DataRow("", "", "", "", TipoUsuario.Aluno)]
    [DataRow("Artur", "arturhtomail.com", "132artuh", "ABC123zd@", TipoUsuario.Aluno)]
    [DataRow("", "artur@htomail.com", "132artuh", "ABC123zd@", TipoUsuario.Aluno)]
    [DataRow("Artur", "artur@htomail.com", "", "ABC123zd@", TipoUsuario.Aluno)]
    [DataRow("Artur", "arturh@tomail.com", "!32artuh", "ABC123zd@", TipoUsuario.Aluno)]
    [DataRow("Artur", "arturh@tomail.com", "132artuh", "aaaa", TipoUsuario.Aluno)]

    public void casoTeste2_CriarConta_False(string Nome, string Email, string Login, string Senha, TipoUsuario tpUsuario)
    {
      bool status = CadastroUsuario.CriarConta(Nome, Email, Login, Senha, tpUsuario);
      Assert.IsFalse(status);
    }

    [TestMethod]
    public void casoTeste3_HabiliatrFuncionalidade_Aluno()
    {
      string url = CadastroUsuario.HabilitaFuncionalidades(TipoUsuario.Aluno);
      Assert.AreEqual("Funcionalidades/Auth/Aluno.html", url);
    }

    [TestMethod]
    public void casoTeste4_HabiliatrFuncionalidade_Professor()
    {
      string url = CadastroUsuario.HabilitaFuncionalidades(TipoUsuario.Professor);
      Assert.AreEqual("Funcionalidades/Auth/Professor.html", url);
    }

    [TestMethod]
    [DataRow("pedro123", "123ABC!", TipoUsuario.Aluno)]

    public void casoTeste5_Login_Sucesso_Aluno(string Login, string Senha, TipoUsuario tpUsuario)
    {
      string url = CadastroUsuario.Login(Login, Senha, tpUsuario);
      Assert.AreEqual("Funcionalidades/Auth/Aluno.html", url);
    }

    [TestMethod]
    [DataRow("pedro123", "123ABC!", TipoUsuario.Professor)]

    public void casoTeste6_Login_Sucesso_Professor(string Login, string Senha, TipoUsuario tpUsuario)
    {
      string url = CadastroUsuario.Login(Login, Senha, tpUsuario);
      Assert.AreEqual("Funcionalidades/Auth/Professor.html", url);
    }

    [TestMethod]
    [DataRow("", "123ABC!", TipoUsuario.Professor)]
    [DataRow("pedro123", "", TipoUsuario.Aluno)]

    public void casoTeste7_Login_Invalido(string Login, string Senha, TipoUsuario tpUsuario)
    {
      string url = CadastroUsuario.Login(Login, Senha, tpUsuario);
      Assert.AreEqual("LoginSenhaObrigatorio.html", url);
    }


    [TestMethod]
    [DataRow("", 0, "", "")]
    [DataRow("Teste de Software", 0, "", "")]
    [DataRow("Teste de Software", -1, "", "")]
    [DataRow("Teste de Software", 5, "", "")]
    [DataRow("Teste de Software", 5, "Engenharia de Software", "")]

    public void casoTeste8_CadastrarTurma_Invalido(string Disciplina, int Codigo, string Curso, string UnidadeUniversidade)
    {
      bool status = CadastroUsuario.CadastrarTurma(Disciplina, Codigo, Curso, UnidadeUniversidade);
      Assert.IsFalse(status);
    }

    [TestMethod]
    [DataRow("Teste de Software", 5, "Engenharia de Software", "Praça da Liberadade")]

    public void casoTeste9_CadastrarTurma_Valido(string Disciplina, int Codigo, string Curso, string UnidadeUniversidade)
    {
      bool status = CadastroUsuario.CadastrarTurma(Disciplina, Codigo, Curso, UnidadeUniversidade);
      Assert.IsFalse(status);
    }


    [TestMethod]
    [DataRow("Teste de Software", 5, "pedro595", TipoUsuario.Professor)]

    public void casoTeste10_IncluirAlunoTurma_Invalido(string Disciplina, int CodigoTurma, string LoginAluno, TipoUsuario tpUsuario)
    {
      bool status = CadastroUsuario.IncluirAlunoTurma(Disciplina, CodigoTurma, LoginAluno, tpUsuario);
      Assert.IsFalse(status);
    }

    [TestMethod]
    [DataRow("Teste de Software", 5, "pedro595", TipoUsuario.Aluno)]

    public void casoTeste11_IncluirAlunoTurma_Valido(string Disciplina, int CodigoTurma, string LoginAluno, TipoUsuario tpUsuario)
    {
      bool status = CadastroUsuario.IncluirAlunoTurma(Disciplina, CodigoTurma, LoginAluno, tpUsuario);
      Assert.IsTrue(status);
    }


    [TestMethod]
    [DataRow(-1, StatusJF.EmCriacao)]
    [DataRow(0, StatusJF.EmCriacao)]
    [DataRow(1, StatusJF.EmCriacao)]
    [DataRow(99, StatusJF.EmCriacao)]
    [DataRow(-1, StatusJF.Finalizado)]
    [DataRow(0, StatusJF.Finalizado)]
    [DataRow(1, StatusJF.Finalizado)]
    [DataRow(99, StatusJF.Finalizado)]
    [DataRow(-1, StatusJF.EmPreparacao)]
    [DataRow(0, StatusJF.EmPreparacao)]
    [DataRow(1, StatusJF.EmPreparacao)]
    [DataRow(99, StatusJF.EmPreparacao)]
    [DataRow(-1, StatusJF.EmExecucao)]
    [DataRow(0, StatusJF.EmExecucao)]
    [DataRow(1, StatusJF.EmExecucao)]
    [DataRow(99, StatusJF.EmExecucao)]

    public void casoTeste12_AlterarStatus_ValorLimite(int CodigoJF, StatusJF statusJF)
    {
      bool status = CadastroJF.AlterarStatusJF(CodigoJF, statusJF);
      Assert.IsTrue(status);
    }


    [TestMethod]
    [DataRow("Enunciado referente ao JF com um total de 55 caracteres")]
    [DataRow("Enunciado referente ao JF com um total de 50 carac")]
    [DataRow("Enunciado referente ao JF com um total de 49 cara")]
    [DataRow("E")]
    [DataRow("")]

    public void casoTeste13_TamanhoTextoJF_ValorLimite(string Texto)
    {
      bool status = CadastroJF.ValidarTamanhoTextoJF(Texto);
      Assert.IsTrue(status);
    }

    [TestMethod]
    [DataRow(StatusJF.EmCriacao)]
    [DataRow(StatusJF.EmExecucao)]
    [DataRow(StatusJF.EmPreparacao)]
    [DataRow(StatusJF.Finalizado)]

    public void casoTeste14_ValidarPermissaoJF_ClasseEquivalencia(StatusJF statusJF)
    {
      bool status = CadastroJF.ValidarPermissaoAcessoJF(statusJF);
      Assert.IsTrue(status);
    }

    [TestMethod]
    [DataRow(50, 60)]
    [DataRow(1, 1)]
    public void casoTeste15_ValidarConfiguracaoJF_ClasseEquivalencia(int TamnMaxEquipe, int TempoMaxMinutos)
    {
      ConfiguracaoJF configuracaoJF = new ConfiguracaoJF();
      configuracaoJF.TamanhoMaxEquipe = TamnMaxEquipe;
      configuracaoJF.TempoMax = TempoMaxMinutos;

      bool status = CadastroJF.ValidarConfiguracaoJF(configuracaoJF);
      Assert.IsTrue(status);
    }

    [TestMethod]
  
    public void casoTeste16_ExibirJF_ClasseEquivalencia()
    {
      JulgamentoFatos julgamentoFatos = new JulgamentoFatos();
      julgamentoFatos.AlternativaCorreta = Resposta.V;
      julgamentoFatos.ConjuntoFatos = new List<string>();
      julgamentoFatos.Texto = "Enunciado referente ao JF com um total de 50 carac";
      julgamentoFatos.TopicoDisciplina = "Teste de Software";


      bool status = CadastroJF.ExbiirJF(julgamentoFatos);
      Assert.IsFalse(status);
    }

    [TestMethod]

    public void casoTeste17_ExibirJF_ClasseEquivalencia()
    {
      JulgamentoFatos julgamentoFatos = new JulgamentoFatos();
      julgamentoFatos.AlternativaCorreta = Resposta.V;
      julgamentoFatos.ConjuntoFatos = new List<string>();
      julgamentoFatos.Texto = "Enunciado referente ao JF com um total de 50 carac";
      julgamentoFatos.TopicoDisciplina = "";


      bool status = CadastroJF.ExbiirJF(julgamentoFatos);
      Assert.IsFalse(status);
    }
  }
}
