using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {   
            Aluno[] alunos = new Aluno[5];
            var IndiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //Adicionar aluno
                        Console.WriteLine("Informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Iforme a nota do aluno:");

                       if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                       {
                        aluno.Nota = nota;
                       }
                       else 
                       {
                           throw new ArgumentException("O valor da nota deve ser decimal");
                       }
                       alunos[IndiceAluno] = aluno;
                       IndiceAluno++;

                        break;

                    case "2":
                        
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        } 

                        break;

                    case "3":
                        
                        decimal NotaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                NotaTotal = NotaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }        
                        }

                        var mediaGeral = NotaTotal / nrAlunos;
                        conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = conceito.C;
                        }
                        else if (mediaGeral < 8 )
                        {
                            conceitoGeral = conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = conceito.A;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} Conceito: {conceitoGeral}");
                                               
                        break;

                    default:
                     
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine();    
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("1 -Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
