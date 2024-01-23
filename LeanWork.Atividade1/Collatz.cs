namespace LeanWork.Atividade1;

public class Collatz
{
    public static int ObterTamanhoSequenciaCollatz(long numero)
    {
        int iteracao = 1;

        while (numero != 1)
        {
            if (numero % 2 == 0)
                numero /= 2;
            else
                numero = 3 * numero + 1;

            iteracao++;
        }

        return iteracao;
    }
}
