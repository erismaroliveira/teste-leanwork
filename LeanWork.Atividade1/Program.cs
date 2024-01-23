using LeanWork.Atividade1;

/*
 * Desenvolva uma aplicação que descubra qual o número inicial entre 1 e 1 milhão que produz a maior sequência.
 */

Console.WriteLine("============ Método Collatz ============");

long maxNumeroInicial = 0;
int maxTamanho = 0;

for (long i = 1; i <= 1000000; i++)
{
    int tamanho = Collatz.ObterTamanhoSequenciaCollatz(i);

    if (tamanho > maxTamanho)
    {
        maxTamanho = tamanho;
        maxNumeroInicial = i;
    }
}

Console.WriteLine($"O número inicial que produz a maior sequência é {maxNumeroInicial} com {maxTamanho} termos.");

/*
 * elabore um método que defina se o seguinte array contém somente números ímpares e demonstre o resultado no console
 */

Console.WriteLine("============ Método Números ímpares ============");

int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

var resultado = numeros.All(n => n % 2 != 0);

Console.WriteLine($"{(resultado ? "Todos são ímpares" : "Nem todos são ímpares")}");

/*
 * elabore um método que traga somente os números do primeiro array que não estejam contidos no segundo array e demonstre o resultado no console
 */

Console.WriteLine("============ Método Números do primeiro array que não estejam contidos no segundo array ============");

int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

var resultado2 = primeiroArray.Except(segundoArray).ToArray();

foreach (var item in resultado2)
{
    Console.Write($"{item} ");
}

Console.Write("\n");
Console.WriteLine("============ Fim ============");