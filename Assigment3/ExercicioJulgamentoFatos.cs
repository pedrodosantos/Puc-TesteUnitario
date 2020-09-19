using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Assigment5;
using static Assigment5.Auxiliar;

namespace Assigment3
{
  public static class CadastroUsuario
  {

    public static bool CriarConta(string Nome, string Email, string Login, string Senha, TipoUsuario tpUsuario)
    {
      if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Email))
        return false;

      if (ValidaLogin(Login) && ValidaSenha(Senha) && ValidaEmail(Email))
        if (BancoDados.buscarb(Login, Senha, tpUsuario, false))
          return false; // Usuario já cadastrado
        else
          return BancoDados.salvarDb(Nome, Email, Login, Senha, tpUsuario);

      return false;
    }

    public static string Login(string Login, string Senha, TipoUsuario tpUsuario)
    {
      string url = string.Empty;
      if (ValidaLogin(Login) && ValidaSenha(Senha))
        if (BancoDados.buscarb(Login, Senha, tpUsuario, true))
          url = HabilitaFuncionalidades(tpUsuario);
        else
          url = "LoginSenhaInvalido.html";
      else
        url = "LoginSenhaObrigatorio.html";

      return url;
    }

    public static string HabilitaFuncionalidades(TipoUsuario tpUsuario)
    {
      if (tpUsuario == TipoUsuario.Aluno)
        return "Funcionalidades/Auth/Aluno.html";

      if (tpUsuario == TipoUsuario.Professor)
        return "Funcionalidades/Auth/Professor.html";

      return "PerfilInvalido.html";
    }

    public static bool CadastrarTurma(string Disciplina, int Codigo, string Curso, string UnidadeUniversidade)
    {
      if (!string.IsNullOrEmpty(Disciplina) && !string.IsNullOrEmpty(Curso) && !string.IsNullOrEmpty(UnidadeUniversidade) && Codigo > 0)
        if (BancoDados.buscarTurmaDb(Codigo))
          return false; // Turma já cadastrada
        else
          return BancoDados.SalvarTurmaDb(Disciplina, Codigo, Curso, UnidadeUniversidade);

      return false;
    }

    public static bool IncluirAlunoTurma(string Disciplina, int CodigoTurma, string LoginAluno, TipoUsuario tpUsuario)
    {
      if (tpUsuario != TipoUsuario.Aluno)
        return false;

      if (BancoDados.buscarTurmaDb(CodigoTurma))
        return BancoDados.incluirAlunoTurmaDb(Disciplina, CodigoTurma, LoginAluno);

      return false;
    }

    private static bool ValidaLogin(string Login)
    {
      //Login com tamanho entre 5 e 10 caracteres
      if (Login.Length >= 5 && Login.Length <= 10)
      {
        //Não inicia com caracter especial
        if (char.IsLetterOrDigit(Convert.ToChar(Login.Substring(0, 1))))
          return true;
      }

      return false;
    }

    private static bool ValidaSenha(string Senha)
    {
      //Senha com tamanho 6 caracteres
      if (Senha.Length >= 6)
      {
        //Se a senha contem caracter especial, letra, número e letra maiuscla é uma senha valida
        if (Senha.Any(ch => !char.IsLetterOrDigit(ch)) && Senha.Any(ch => char.IsLetter(ch)) && Senha.Any(ch => !char.IsDigit(ch)) && Senha.Any(ch => !char.IsUpper(ch)))
          return true;
      }

      return false;
    }

    private static bool ValidaEmail(string Email)
    {
      if (Email.Contains("@"))
        return true;

      return false;
    }

  }
}
