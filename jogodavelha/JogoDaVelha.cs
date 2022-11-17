using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    //Lógica do Jogo da Velha
    public class JogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        // Construtor da Classe JogoDaVelha
        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }
        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela(); 
                LerEscolhaDoUsuario();
                RenderizarTabela(); 
                VerificarFimDeJogo();
                MudarVez();
            }
        }
        // Método para alternar os jogadores
        private void MudarVez()
        {
            if (vez == 'X')
            {
                vez = 'O';
            }
            else
            {
                vez = 'X';
            }
        }
        // Verificar o fim do jogo
        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
            {
                return;
            }

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo! vitória de {vez}");
                return;
            }

            if (quantidadePreenchida == 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo! Deu Empate!");
                return;
            }
        }
        // Validação de vitória horizontal
        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }
        // Validação de vitória vertical
        private bool ExisteVitoriaVertical()
        {
            bool vitoriaColuna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaColuna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaColuna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaColuna1 || vitoriaColuna2 || vitoriaColuna3;
        }
        // Validação de vitória diagonal
        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaDiagonal1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool vitoriaDiagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            return vitoriaDiagonal1 || vitoriaDiagonal2;
        }
        // ler a entrada do usuário
        private void LerEscolhaDoUsuario()
        {
            Console.Write($"Agora é do {vez} jogar. Escolha uma posição de 1 a 9 que esteja disponível no tabuleiro: ");

            //ver se o usuário está digitando um número inteiro, ou não
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.Write("Valor inválido! Escolha entre os campos 1 e 9: ");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            // Preencher com a escolha do usuário
            PreencherEscolha(posicaoEscolhida);
        }
        //Posição escolhida na tabela
        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        // Validação do campo escolhido pelo usuário
        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            if (posicoes[indice] == 'O' || posicoes[indice] == 'X')
            {
                return false;
            }
            else
            {
                return true;
            }              
        }
        //Imprimir a tabela no console
        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return  $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__|\n" +
                    $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__|\n" +
                    $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  |\n\n";
        }
    }
}