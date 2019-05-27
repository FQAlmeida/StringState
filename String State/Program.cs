using System;
using System.Text;

namespace String_State
{
    class Program
    {
        const char CharLayout = '_';
        static void Main(string[] args)
        {
            string FinalState = "PALAVRA".ToUpper(); // Palavra Alvo || Estado Final
            // Dá pra dar um outro jeito para criar esse array e popular ele com o charLayout, mas assim fica criativo :)
            char[] ActualState = new StringBuilder(FinalState.Length).Append(CharLayout, FinalState.Length).ToString().ToCharArray(); // Palavra Atual || Estado Atual, já Preenche o estado com CharLayout e converte para charArray
            char input;

            while (true)
            { // Repete até o Estado Final e o Atual serem iguais
                input = Console.ReadLine().ToCharArray()[0]; // Lê o primeiro character do console, deve ter um jeito melhor de fazer isso :(
                if (FinalState.Contains(input)) // Verifica se o Estado Final contém o char que o usuário digitou
                {
                    for (int aux = FinalState.IndexOf(input); aux < FinalState.Length; aux++) // Se contém, acha os indexes desse character, começando no primeiro
                    {
                        if (FinalState[aux] == input) // Para cada vez que achar
                        {
                            if (ActualState[aux] == CharLayout) // Checa se essa posição está vazia no Estado Atual
                            {
                                ActualState[aux] = input; // Se estiver, troca a posição pelo caracter desejado
                                break; // Break para não trocar em todas as ocorrências
                            }
                        }
                    }
                }
                if (FinalState == new String(ActualState)) // Final :)
                {
                    Console.WriteLine("Congrats");
                    Environment.Exit(0);
                }
                Console.WriteLine(String.Format("Final: {0}\nAtual: {1}", FinalState, new String(ActualState))); // Mostra o estado atual do sistema
            }
        }
    }
}
