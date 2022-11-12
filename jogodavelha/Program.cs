namespace Jogo_da_Velha
{

    public class Program
    {
        private static void Main(string[] args)
        {
            string[,] Matriz = new string[3, 3];
            string Turno = "X";
            int Rodadas = 0, index = 1;

            // Preenchendo os espaços e imprimindo a Matriz

            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    Matriz[i, j] = index.ToString();
                    Console.Write($"[ {Matriz[i, j]} ] ");
                    index++;
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write($"Jogador : ");
            string Jogada = Console.ReadLine();
            Console.Clear();
            while (Rodadas < 9)
            {

                for (int i = 0; i < Matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < Matriz.GetLength(1); j++)
                    {
                        if (Matriz[i, j] == Jogada)
                        {
                            Matriz[i, j] = Turno;

                        }
                        Console.Write($"[ {Matriz[i, j]} ] ");
                    }
                    Console.WriteLine();
                }
                Console.Write($"Jogador : ");
                Jogada = Console.ReadLine();
                Rodadas++;
            }

        }
    }
}
