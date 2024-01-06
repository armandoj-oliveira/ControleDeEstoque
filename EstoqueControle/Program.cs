Dictionary<string, List<int>> estoqueQuant = new();

void ExibirMensagemLista(string nome)
{
    int quantidade = nome.Length;
    string asterisco = string.Empty.PadLeft(quantidade, '-');
    Console.WriteLine(asterisco);
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(nome);
    Console.ResetColor();
    Console.WriteLine(asterisco);
}

void AdicionarProduto()
{
    bool sair = false;

    while(!sair)
    {
        Console.Write("\nInforme o nome do produto que deseja adicionar: ");
        string nomeProduto = Console.ReadLine()!;

        if (string.IsNullOrEmpty(nomeProduto))
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" ERRO ");
            Console.ResetColor();
            Console.WriteLine("Nada foi digitado!!!");
            Console.WriteLine("Por favor, informe o nome do produto!!!");

        } else
        {
            estoqueQuant.Add(nomeProduto, new List<int>());
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n SUCESSO ");
            Console.ResetColor();
            Console.WriteLine("Nome registrado com sucesso pelo sistema!!!");
            Console.Write("\nDeseja registrar outro produto? (S/N): ");
            char contEscolha = Convert.ToChar(Console.ReadLine()!.ToLower());

            if ( contEscolha == 'n')
            {
                sair = true;
            }
        }
    }
}

void AdicionarProdutoQuantidade()
{
    bool sair = false;

    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(" AVISO ");
    Console.ResetColor();
    Console.WriteLine("Necessita conter um produto registrado antes de informar a quantidade!!!");

    while (!sair)
    {
        Console.Write("\nInforme o nome do produto que deseja adicionar a sua quantidade: ");
        string nomeProduto = Console.ReadLine()!;

        if(string.IsNullOrEmpty(nomeProduto))
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n ERRO ");
            Console.ResetColor();
            Console.WriteLine("Nada foi digitado!!!");
            Console.WriteLine("Por favor, informe o nome do produto!!!");

        } else if (estoqueQuant.ContainsKey(nomeProduto))
        {
            Console.Write($"\nInforme a quantidade de itens que tem o produto {nomeProduto}: ");
            int? quantProd = Convert.ToInt32(Console.ReadLine()!);

            if (quantProd.HasValue)
            {
                estoqueQuant[nomeProduto].Add((int)quantProd);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n SUCESSO ");
                Console.ResetColor();
                Console.WriteLine("Quantidade atribuida ao produto com sucesso no sistema!!!");
            } else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n ERRO ");
                Console.ResetColor();
                Console.WriteLine("Informe um número válido!!!");
            }

            Console.Write("\nDeseja continuar a registrar quantidade de produtos? (S/N): ");
            char contEscolha = Convert.ToChar(Console.ReadLine()!.ToLower());

            if (contEscolha == 'n')
            {
                sair = true;
            }

        } else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" ERRO ");
            Console.ResetColor();
            Console.WriteLine("Informe um número válido!!!");
        }
    }
}

void MostrarProtudoQuantidade()
{
    Console.WriteLine("\nVocê registrou os seguintes produtos!!!");

    foreach (var item in estoqueQuant){
        Console.WriteLine($"\nProduto: {item.Key}             Quantidade: {string.Join("",item.Value)}");
    }
}
byte ExibirMenu()
{
    ExibirMensagemLista(" GERENCIADOR DE ESTOQUE ");
    Console.WriteLine("\nAbaixo estão listadas as opções, por favor digite:");
    Console.WriteLine(" 1 - Adicionar Produto");
    Console.WriteLine(" 2 - Adicionar Quantidade");
    Console.WriteLine(" 3 - Mostrar Produtos e suas Quantidades");
    Console.WriteLine(" 0 - Sair do Sistema");
    Console.Write("---> ");
    byte opcao = Convert.ToByte(Console.ReadLine()!);

    return opcao;
}
void ExecutarEstoqueControle()
{
    bool sair = false;

    while (!sair)
    {
        byte escolha = ExibirMenu();

        switch (escolha)
        {
            case 0:
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Aguardamos atenciosamente seu retorno!!!");
                Console.ResetColor();
                Thread.Sleep(1000);

                sair = true;

                break;
            case 1:
                Console.Clear();
                ExibirMensagemLista(" ADICIONAR NOVO PRODUTO! ");
                AdicionarProduto();
                Console.WriteLine("\nAguarde alguns segundos...");
                Thread.Sleep(1000);
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                ExibirMensagemLista(" ADICIONAR QUANTIDADE AOS PRODUTOS! ");
                AdicionarProdutoQuantidade();
                Console.WriteLine("\nAguarde alguns segundos...");
                Thread.Sleep(1000);
                Console.Clear();
                break;
            case 3:
                Console.Clear();
                ExibirMensagemLista(" MOSTRAR OS PRODUTOS E SUAS QUANTIADES! ");
                MostrarProtudoQuantidade();
                Console.WriteLine("\nAguarde alguns segundos...");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            default:
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Opção Inválida!!!");
                Console.ResetColor();
                Thread.Sleep(1000);
                break;
        }

    }
}

ExecutarEstoqueControle();