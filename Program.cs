using UC15_Projetos.classes;
using System.Globalization;

namespace UC15_Projetos
{
    class Program
    {
        static void Main(string[] args)
        {

            const int SLEEP_TIME = 2500;

            Console.Clear();
            Utils.Carregamento("Iniciando Sistemas", 100, 50);
            Console.Clear();
            Console.WriteLine(@$"



                ================================================
                |        Bem Vindo ao Sistema de Cadastro      |
                |            Pessoa Física & Jurídica          |
                ================================================
                |                                              |
                |             1 - Pessoa Física                |
                |                                              |
                |             2 - Pessoa Jurídica              |
                |                                              |
                |             0 - Sair                         |
                ================================================
                
                
                ");

            string? op;
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            do
            {
                Console.Clear();
                Console.WriteLine(@$"



                ================================================
                |        Bem Vindo ao Sistema de Cadastro      |
                |            Pessoa Física & Jurídica          |
                ================================================
                |                                              |
                |             1 - Pessoa Física                |
                |                                              |
                |             2 - Pessoa Jurídica              |
                |                                              |
                |             0 - Sair                         |
                ================================================
                
                
                ");


                op = Console.ReadLine();

                switch (op)
                {

                    case "1":

                        string? opPf;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                            =============================================
                            |        Escolha uma das opções abaixo      |
                            |-------------------------------------------|
                            |           1 - Cadastrar Pessoa Física     |
                            |           2 - Listar Pessoas Física       |
                            |                                           |
                            |           0 - Voltar ao menu anterior     |
                            =============================================
                            ");
                            opPf = Console.ReadLine();

                            switch (opPf)
                            {
                                case "1":

                                    Console.Clear();
                                    PessoaFisica pessoaFisica = new PessoaFisica();
                                    pessoaFisica.endereco = new Endereco();

                                    Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                                    pessoaFisica.nome = Console.ReadLine();
                                    bool dataValida;
                                    do
                                    {

                                        Console.WriteLine($"Digite a data de nascimento Ex:DD/MM/AAAA");
                                        string? dataNascimento = Console.ReadLine();

                                        dataValida = pessoaFisica.ValidarDataNascimento(dataNascimento!);

                                        if (dataValida)
                                        {
                                            DateTime DataConvertida;
                                            DateTime.TryParse(dataNascimento, out DataConvertida);

                                            pessoaFisica.dataNascimento = DataConvertida;

                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"Data digitada invalida, por favor digite uma data valida");
                                            Console.ResetColor();
                                            Thread.Sleep(SLEEP_TIME);
                                        }

                                    } while (dataValida == false);
                                    Console.WriteLine($"Digite o numero do CPF");
                                    pessoaFisica.cpf = Console.ReadLine();

                                    Console.WriteLine($"Digite o rendimento mensal (DIGITE SOMENTE NUMEROS)");
                                    pessoaFisica.rendimento = float.Parse(Console.ReadLine()!);

                                    Console.WriteLine($"Digite a rua");
                                    pessoaFisica.endereco.logradouro = Console.ReadLine();

                                    Console.WriteLine($"Digite o numero");
                                    pessoaFisica.endereco.numero = int.Parse(Console.ReadLine()!);

                                    Console.WriteLine($"Este endereço é comercial? S/N");
                                    string endCom = Console.ReadLine()!.ToUpper();

                                    pessoaFisica.endereco.endComercial = endCom == "S" ? true : false;

                                    listaPf.Add(pessoaFisica);
                                    pessoaFisica.Inserir();

                                    using (StreamWriter sw = new StreamWriter($"{pessoaFisica.nome}.txt"))
                                    {
                                        sw.WriteLine(pessoaFisica.nome);
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Cadastro realizado com sucesso");
                                    Console.ResetColor();
                                    Thread.Sleep(SLEEP_TIME);

                                    break;

                                case "2":

                                    Console.Clear();

                                    if (listaPf.Count > 0)
                                    {
                                        Console.WriteLine(listaPf.Count);
                                        foreach (PessoaFisica pf in listaPf)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(@$"
                                            Nome: {pf.nome}
                                            Endereço: {pf.endereco!.logradouro}, {pf.endereco.numero}
                                            Imposto a ser pago: {pf.CalcularImposto().ToString("C", CultureInfo.CurrentCulture)}
                                            Data de Nascimento: {pf.dataNascimento.ToString("d")}
                                            ");

                                            Console.WriteLine("Aperte 'ENTER' para continuar");
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Lista vazia");
                                        Thread.Sleep(SLEEP_TIME);
                                    }

                                    break;

                                case "0":
                                    break;

                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($"Opção Inválida, por favor digite uma opção válida");
                                    Console.ResetColor();
                                    Thread.Sleep(SLEEP_TIME);
                                    break;
                            }

                        } while (opPf != "0");
                        break;
                    case "2":
                        PessoaJuridica pessoaJuridica = new PessoaJuridica();

                        pessoaJuridica.nome = "Fantasia";
                        pessoaJuridica.razaoSocial = "Empresa Fantasia LTDA";
                        pessoaJuridica.cnpj = "55.444.111/0001-22";
                        pessoaJuridica.rendimento = 1887999999;
                        pessoaJuridica.endereco = new Endereco();
                        pessoaJuridica.endereco.logradouro = "Rua 01";
                        pessoaJuridica.endereco.numero = 539;
                        pessoaJuridica.endereco.complemento = "4º andar, sala 01";
                        pessoaJuridica.endereco.endComercial = true;

                        Console.Clear();

                        pessoaJuridica.Inserir();
                        using (StreamWriter sw = new StreamWriter($"{pessoaJuridica.nome}.txt"))
                        {
                            sw.WriteLine(pessoaJuridica.nome);
                        }

                        List<PessoaJuridica> exibirListaPj = pessoaJuridica.LerArquivo();
                        foreach (PessoaJuridica cadaItem in exibirListaPj)
                        {
                            Console.WriteLine(@$"
                =================================
                Nome: {cadaItem.nome}
                Razão Social: {cadaItem.razaoSocial}
                CNPJ: {cadaItem.cnpj}
                CNPJ Válido: {cadaItem.ValidarCnpj()}");
                        }

                        Console.WriteLine($"Aperte ENTER para continuar");
                        Console.ReadLine();

                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine($"Obrigado por utilizar nosso sistema!");
                        Thread.Sleep(SLEEP_TIME);

                        Utils.Carregamento("Finalizando Sistemas", 100, 10);

                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção Inválida, por favor digite uma opção válida");
                        Console.ResetColor();
                        Thread.Sleep(SLEEP_TIME);
                        break;
                }




            } while (op != "0");

        }
    }
}













// PessoaFisica pessoaFisica = new PessoaFisica();

// pessoaFisica.cpf = "123.456.789-00";
// pessoaFisica.dataNascimento = new DateTime(1997, 10, 30);
// pessoaFisica.nome = "João";
// pessoaFisica.rendimento = 1000;
// pessoaFisica.endereco = new Endereco();
// pessoaFisica.endereco.logradouro = "Rua 1";
// pessoaFisica.endereco.numero = 1;
// pessoaFisica.endereco.complemento = "Casa 1";
// pessoaFisica.endereco.endComercial = false;
// pessoaFisica.endereco.cep = "12345-678";

// Console.WriteLine($"Bem vindo {pessoaFisica.nome}! Seu CPF é {pessoaFisica.cpf} e sua data de nascimento é {pessoaFisica.dataNascimento.ToUniversalTime()}.");

// Console.WriteLine($"Você pagará um imposto no valor de R$ {pessoaFisica.CalcularImposto()}.");

// pessoaFisica.rendimento = 4000;

// Console.WriteLine($"Você pagará um imposto no valor de R$ {pessoaFisica.CalcularImposto()}.");

// Console.WriteLine($"Sua data de nascimento é {pessoaFisica.dataNascimento} e essa data é válida? (date) {pessoaFisica.ValidarDataNascimento(pessoaFisica.dataNascimento)}.");

// Console.WriteLine($"Sua data de nascimento é 02/01/2016 e essa data é válida? (string) {pessoaFisica.ValidarDataNascimento("02/01/2016")}.");

// Console.WriteLine(@$"
// RELATÓRIO DE PESSOA FÍSICA
// Nome: {pessoaFisica.nome}
// CPF: {pessoaFisica.cpf}
// Data de nascimento: {pessoaFisica.dataNascimento.ToUniversalTime()}
// Rendimento: {pessoaFisica.rendimento}
// Endereço: {pessoaFisica.endereco.logradouro}, {pessoaFisica.endereco.numero} - {pessoaFisica.endereco.complemento}
// CEP: {pessoaFisica.endereco.cep}
// Maior de idade? {pessoaFisica.ValidarDataNascimento(pessoaFisica.dataNascimento)}
// ");



// // pj
// PessoaJuridica pessoaJuridica = new PessoaJuridica();
// pessoaJuridica.cnpj = "13.456.789/0001-00";
// pessoaJuridica.razaoSocial = "Empresa Fantasia";
// pessoaJuridica.rendimento = 1000;
// pessoaJuridica.endereco = new Endereco();
// pessoaJuridica.endereco.logradouro = "Rua 20";
// pessoaJuridica.endereco.numero = 882;
// pessoaJuridica.endereco.complemento = "4 Andar, sala 10";
// pessoaJuridica.endereco.cep = "12345-678";
// pessoaJuridica.endereco.endComercial = true;

// Console.WriteLine($"\n=================\nBem vindo {pessoaJuridica.razaoSocial}! Seu CNPJ é {pessoaJuridica.cnpj}.");
// Console.WriteLine(@$"
// RELATÓRIO DE PESSOA JURÍDICA
// Razao Social: {pessoaJuridica.razaoSocial}
// CNPJ: {pessoaJuridica.cnpj}
// Rendimento: {pessoaJuridica.rendimento}
// Endereço: {pessoaJuridica.endereco.logradouro}, {pessoaJuridica.endereco.numero} - {pessoaJuridica.endereco.complemento}
// Endereço Comercial: {pessoaJuridica.endereco.endComercial}
// CEP: {pessoaJuridica.endereco.cep}
// Cpnj Valido: {pessoaJuridica.ValidarCnpj()}
// ");

