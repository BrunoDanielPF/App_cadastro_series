using System;

namespace CRUD_DOTNET
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }
        }
            private static void ListarSeries()
            {
                Console.WriteLine("Listar Series");
                var lista = repositorio.Lista();
                if(lista.Count == 0)
                {
                    Console.WriteLine("nehuma serie cadastrada.");
                    return;
                }
                foreach(var serie in lista)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }

            private static void InserirSerie()
            {
                Console.WriteLine("Inserir nova série");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), in));
                }
                Console.Write("digite o genero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o titulo da série:");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano de inicio da série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("digite a descrição da série");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(
                    id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    Descricao: entradaDescricao
                );
                repositorio.Insere(novaSerie);
            }
            private static string ObterOpcaoUsuario()
        {
            
                Console.WriteLine();
                Console.WriteLine("DIO séries a seu dispor!");
                Console.WriteLine("informe a opção desejada");

                Console.WriteLine("1 - Listar Séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir serie");
                Console.WriteLine("5 - Visualizar serie");
                Console.WriteLine("C - Limpar Tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string OpcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return OpcaoUsuario;    
        }
    }
}
