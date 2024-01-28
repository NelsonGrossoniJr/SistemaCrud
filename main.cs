using System;
using System.Collections;
using System.Collections.Generic;
/*

  PRA QUEM FOR CORRIGIR!!!!!!!!
  ESSE MESMO CODIGO NO VISUAL STUDIO NAO ESTA DANDO ERRO AO CALCULAR A IDADE DA PESSOA E TAMBEM ESTAVA TODO SEPARADO PARA FICAR MAIS LEGIVEL MAS ME DEPAREI COM ALGUNS ERROS AO PASSAR PARA O REPLIT E ENTAO JUNTEI TUDO EM UM SÓ ONDE VOCE QUE ESTA CORRIGINDO PODE SÓ COPIAR E COLAR ESSE CODIGO NA IDE PARA CONFERIR OQUE ESTOU FALANDO E VER QUE LA ESTA REDONDO 

   Preciso que coloque o código completo para que eu possa fazer a correção, a medida que for ocorrendo algum tipo de erro ou tiver dificuldade me envie uma mensagem no Microsoft Teams que eu te ajudo.
  

*/
public class Person
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string DataNascimento { get; set; }
    public bool IsIdoso { get; set; }
    public double Altura { get; set; }
}

public class Program
{
    public static void Main()
    {
        ArrayList pessoas = new ArrayList();

        static int CalcularIdade(string dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int anoNascimento = DateTime.Parse(dataNascimento).Year;
            int idade = dataAtual.Year - anoNascimento;

            return idade;
        }

        while (true)
        {
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Pesquisar pessoas");
            Console.WriteLine("2. Adicionar nova pessoa");
            Console.WriteLine("3. Sair");
            Console.Write("Digite uma das opções:");

            String opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    // Pesquisar pessoas

                    // Solicitando que o usuário informe o nome a ser pesquisado
                    Console.Write("Informe o nome (ou parte do nome) da pessoa a ser pesquisada: ");
                    string nomePesquisa = Console.ReadLine();

                    bool pessoaEncontrada = false;
                    int contador = 0;
                    List<Person> pessoasEncontradas = new List<Person>();

                    foreach (Person pessoa in pessoas)
                    {
                        if (pessoa.Nome.Contains(nomePesquisa))
                        {
                            Console.WriteLine($"Nome: {pessoa.Nome}");
                            Console.WriteLine($"{contador + 1} - Visualizar detalhes");
                            pessoasEncontradas.Add(pessoa);
                            pessoaEncontrada = true;
                            contador++;
                        }
                    }

                    if (!pessoaEncontrada)
                    {
                        Console.WriteLine("Nenhuma pessoa encontrada com o nome informado.");
                    }
                    else
                    {
                        Console.Write("Selecione o número da pessoa para ver detalhes: ");
                        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= contador)
                        {
                            int indiceEscolhido = escolha - 1;
                            Person pessoaEscolhida = pessoasEncontradas[indiceEscolhido];

                            Console.WriteLine("Detalhes da pessoa escolhida:");
                            Console.WriteLine($"Nome: {pessoaEscolhida.Nome}");
                            Console.WriteLine($"Sobrenome: {pessoaEscolhida.Sobrenome}");
                            Console.WriteLine($"Data de nascimento: {pessoaEscolhida.DataNascimento}");
                            Console.WriteLine($"Você é idoso ? {pessoaEscolhida.IsIdoso}");
                            Console.WriteLine($"Altura: {pessoaEscolhida.Altura}");

                            //Calculando a idade da pessoa
                            int idade = CalcularIdade(pessoaEscolhida.DataNascimento);
                            Console.WriteLine($"Idade: {idade}");
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida.");
                        }
                    }
                    break;

                case "2":
                    // Código para adicionar nova pessoa
                    string respostaChechandoCorrecao = "n";
                    while (respostaChechandoCorrecao == "n")
                    {
                        Console.Write("Informe o nome da entidade: ");
                        string nome = Console.ReadLine();

                        Console.Write("Informe o sobrenome da entidade: ");
                        string sobrenome = Console.ReadLine();

                        Console.Write("Informe a data de nascimento da entidade (dd/mm/aaaa): ");
                        string dataNascimento = Console.ReadLine();

                        Console.Write("Informe se você já é Idoso?? Se Sim, responda com(true), Se Não com(false):");
                        bool isIdoso = bool.Parse(Console.ReadLine());

                        Console.Write("Informe a sua altura: ");
                        double altura = double.Parse(Console.ReadLine());


                        Person pessoa = new Person();
                        pessoa.Nome = nome;
                        pessoa.Sobrenome = sobrenome;
                        pessoa.DataNascimento = dataNascimento;
                        pessoa.IsIdoso = isIdoso;
                        pessoa.Altura = altura;

                        Console.WriteLine("Seus dados:");
                        Console.WriteLine($"Nome: {pessoa.Nome}");
                        Console.WriteLine($"Sobrenome: {pessoa.Sobrenome}");
                        Console.WriteLine($"Data de nascimento: {pessoa.DataNascimento}");
                        Console.WriteLine($"Você é idoso ? {pessoa.IsIdoso}");
                        Console.WriteLine($"Altura: {pessoa.Altura}");

                        Console.WriteLine("Eles estão corretos ??");
                        Console.WriteLine("( S )SIM");
                        Console.WriteLine("( N )NAO");
                        respostaChechandoCorrecao = Console.ReadLine().ToLower();

                        if (respostaChechandoCorrecao == "n")
                        {
                            Console.WriteLine("Vamos tentar novamente.");
                        }
                        else if (respostaChechandoCorrecao == "s")
                        {
                            Console.WriteLine("Dados confirmados.");
                            pessoas.Add(pessoa);
                        }
                        else
                        {
                            Console.WriteLine("Digite (S) ou (N)");
                            respostaChechandoCorrecao = "n"; // Força o loop a continuar se a entrada for inválida
                        }
                    }
                    break;

                case "3":
                    // Código para sair
                    Console.WriteLine("Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}