namespace UC15_Projetos.classes
{
  public class Utils
  {
    public static void Carregamento(string mensagem, int tempo, int quantidade)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write($"{mensagem}");

      for (var contador = 0; contador < quantidade; contador++)
      {
        Console.Write(".");
        Thread.Sleep(tempo);
      }

      Console.WriteLine(" OK!");
      Thread.Sleep(2500);

      Console.ResetColor();
    }

    public static void VerificarPastaArquivo(string caminho)
    {

      string pasta = caminho.Split("/")[0];

      if (!Directory.Exists(pasta))
      {
        Directory.CreateDirectory(pasta);
      }

      if (!File.Exists(caminho))
      {
        File.Create(caminho).Close();
      }
    }
  }
}