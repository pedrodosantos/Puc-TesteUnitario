using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment5
{
  public class JulgamentoFatos
  {
    public List<string> ConjuntoFatos { get; set; }

    public string Texto { get; set; }

    public string TopicoDisciplina { get; set; }

    public Resposta AlternativaCorreta { get; set; }
  }

 public  enum Resposta
  {
    F = 0,
    V = 1
  }
}
