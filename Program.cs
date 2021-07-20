using System;

namespace DIO.Series.Classes
{
    class Program
    {
        static EstoqueRepositorio repositorio = new EstoqueRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarEstoque();
						break;
					case "2":
						InserirRoupa();
						break;
					case "3":
						AtualizarEstoque();
						break;
					case "4":
						ExcluirRoupa();
						break;
					case "5":
						VisualizarRoupa();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirRoupa()
		{
			Console.Write("Digite o id da peça de roupa: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarRoupa()
		{
			Console.Write("Digite o id da peça de roupa: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarEstoque()
		{
			Console.Write("Digite o id da peça de roupa: ");
			int indiceRoupa = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Roupas)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Roupas), i));
			}
			Console.Write("Digite a categoria entre as opções acima: ");
			int entradaTipoRoupa = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da peça de roupa: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Tamanho da peça de roupa: ");
			string entradaTamanho = Console.ReadLine();

            Console.Write("Digite as Cores disponíveis da peça de roupa: ");
			string entradaCor = Console.ReadLine();

			Console.Write("Digite a Descrição da peça de roupa: ");
			string entradaDescricao = Console.ReadLine();

			Estoque atualizaRoupa = new Estoque(id: indiceRoupa,
										roupa: (Roupas)entradaTipoRoupa,
										modelo: entradaModelo,
										tamanho: entradaTamanho,
                                        cor: entradaCor,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceRoupa, atualizaRoupa);
		}
        private static void ListarEstoque()
		{
			Console.WriteLine("Listar peças de roupa disponível: ");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma peça de roupa cadastrada. O estoque está vazio!");
				return;
			}

			foreach (var roupa in lista)
			{
                var excluido = roupa.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", roupa.retornaId(), roupa.retornaModelo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirRoupa()
		{
			Console.WriteLine("Inserir nova peça de roupa");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Roupas)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Roupas), i));
			}
			Console.Write("Digite a categoria entre as opções acima: ");
			int entradaTipoRoupa = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da peça de roupa: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Tamanho da peça de roupa: ");
			string entradaTamanho = Console.ReadLine();

            Console.Write("Digite as Cores disponíveis da peça de roupa: ");
			string entradaCor = Console.ReadLine();

			Console.Write("Digite a Descrição da peça de roupa: ");
			string entradaDescricao = Console.ReadLine();

			Estoque novaRoupa = new Estoque(id: repositorio.ProximoId(),
										roupa: (Roupas)entradaTipoRoupa,
										modelo: entradaModelo,
										tamanho: entradaTamanho,
                                        cor: entradaCor,
										descricao: entradaDescricao);
			repositorio.Insere(novaRoupa);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Seja Bem-Vindo ao ESTOQUE - Erva Doce Store!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar peças de roupa");
			Console.WriteLine("2- Inserir nova peça");
			Console.WriteLine("3- Atualizar estoque");
			Console.WriteLine("4- Excluir peça");
			Console.WriteLine("5- Visualizar peça");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
