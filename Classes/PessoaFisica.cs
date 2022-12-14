using UC15_Projetos.Interfaces;
namespace UC15_Projetos.classes
{

  public class PessoaFisica : Pessoa, IPessoaFisica
  {
    public string? cpf { get; set; }
    public DateTime dataNascimento { get; set; }
    public string caminho { get; private set; } = "Database/PessoaFisica.csv";

    public bool ValidarDataNascimento(DateTime dataNascimento)
    {
      DateTime dataAtual = DateTime.Today;
      double anos = (dataAtual - dataNascimento).TotalDays / 365;

      if (anos >= 18)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public bool ValidarDataNascimento(string dataNascimento)
    {

      if (DateTime.TryParse(dataNascimento, out DateTime dataConvertida))
      {
        DateTime dataAtual = DateTime.Today;
        double anos = (dataAtual - dataConvertida).TotalDays / 365;

        if (anos >= 18)
        {
          return true;
        }
      }
      return false;
    }

    public override float CalcularImposto()
    {
      if (this.rendimento <= 1500)
      {
        return 0;
      }

      else if (this.rendimento > 1500 && this.rendimento <= 3500)
      {
        return this.rendimento * 0.02f;
      }

      else if (this.rendimento > 3500 && this.rendimento <= 6000)
      {
        return this.rendimento * 0.035f;
      }

      else
      {
        return this.rendimento * 0.05f;
      }
    }

    public void Inserir()
    {

      Utils.VerificarPastaArquivo(caminho);
      string[] informacoes = { $"{this.nome},{this.cpf},{this.dataNascimento}" };
      File.AppendAllLines(caminho, informacoes);
    }

    public List<PessoaFisica> LerArquivo()
    {

      List<PessoaFisica> listPf = new List<PessoaFisica>();
      string[] linhas = File.ReadAllLines(caminho);

      foreach (string cadaLinha in linhas)
      {
        string[] atributos = cadaLinha.Split(",");

        PessoaFisica novoPf = new PessoaFisica();
        novoPf.nome = atributos[0];
        novoPf.cpf = atributos[1];
        novoPf.dataNascimento = DateTime.TryParse(atributos[2], out DateTime dataConvertida) ? dataConvertida : DateTime.Now;

        listPf.Add(novoPf);
      }
      return listPf;

    }
  }
}