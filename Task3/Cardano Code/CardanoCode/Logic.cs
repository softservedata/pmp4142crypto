﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoCode
{
    public class Logic
    {
        string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        Random random;
        const int N = 4;
        //
        char[,] input_matr = new char[N, N];
        char[,] rotate90 = new char[N, N];
        char[,] rotate180 = new char[N, N];
        char[,] rotate270 = new char[N, N];
        char[,] key = new char[N, N];
        //
        public string Encipher(string input_text,int[] arr)
        {
            random = new Random();
            string res = "";
            int temp = 0;
            //
            (input_matr, rotate90, rotate180, rotate270, key) = GetKeys(arr);
            //
            char[,] matr_encrypted = new char[N, N];
            //
            while (temp < input_text.Length)
            {
                (temp,matr_encrypted) = MatrixUpdateEncipher(matr_encrypted, input_matr, input_text, temp);
                //PrintMatrix(matr_encrypted);
                //Console.WriteLine();
                //90
                (temp, matr_encrypted) = MatrixUpdateEncipher(matr_encrypted, rotate90, input_text, temp);;
                //PrintMatrix(matr_encrypted);
                //Console.WriteLine();
                //180
                (temp, matr_encrypted) = MatrixUpdateEncipher(matr_encrypted, rotate180, input_text, temp);
                //PrintMatrix(matr_encrypted);
                //Console.WriteLine();
                //270
                (temp, matr_encrypted) = MatrixUpdateEncipher(matr_encrypted, rotate270, input_text, temp);
                //PrintMatrix(matr_encrypted);
                //Console.WriteLine();
                //check free space
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (matr_encrypted[i, j] == '\0')
                            matr_encrypted[i, j] = GetRandomCharacter(chars, random);
                    }
                }
                //add to str
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        res += matr_encrypted[i, j];
                    }
                }
                //
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        matr_encrypted[i, j] = '\0';
                    }
                }
            }
            //PrintMatrix(input_matr);
            //Console.WriteLine();
            //PrintMatrix(key);
            return res;
        }
        public string Decipher(string input_text, int[] arr)
        {
            string res = "";
           
            char[,] matr_encrypted = new char[N, N];
            int temp = 0;
            while (temp < input_text.Length)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        matr_encrypted[i, j] = input_text[temp];
                        temp++;
                    }
                }
                res = MessageUpdateDecipher(matr_encrypted, input_matr, res);
                res = MessageUpdateDecipher(matr_encrypted, rotate90, res);
                res = MessageUpdateDecipher(matr_encrypted, rotate180, res);
                res = MessageUpdateDecipher(matr_encrypted, rotate270, res);
              
            }
            return res;
        }
        public char[,] Rotate90Clockwise(char[,] a)
        {
            char[,] arr = new char[N, N];
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {
                    char temp = a[i, j];
                    arr[i, j] = a[N - 1 - j, i];
                    arr[N - 1 - j, i] = a[N - 1 - i, N - 1 - j];
                    arr[N - 1 - i, N - 1 - j] = a[j, N - 1 - i];
                    arr[j, N - 1 - i] = temp;
                }
            }
            return arr;
        }
        public void PrintMatrix(char[,] arr)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(arr[i, j] + " ");
                Console.Write("\n");
            }
        }
        public char GetRandomCharacter(string text, Random rng)
        {
            int index = rng.Next(text.Length);
            return text[index];
        }
        public (int,char[,]) MatrixUpdateEncipher(char[,] matr,char[,] key,string input_text,int temp)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (key[i, j] == '1')
                    {
                        if (temp < input_text.Length)
                        {
                            matr[i, j] = input_text[temp];
                            temp++;
                        }
                        else
                            matr[i, j] = GetRandomCharacter(chars, random);
                    }
                }
            }
            return (temp,matr);
        }
        public string MessageUpdateDecipher(char[,] matr, char[,] key, string res_text)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (key[i, j] == '1')
                        res_text += matr[i, j];
                }
            }
            return res_text;
        }
        public (char[,],char[,], char[,], char[,], char[,]) GetKeys(int[] arr)
        {
            char[,] input_matr = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                var temp_arr = Convert.ToString(arr[i], 2).PadLeft(4, '0').ToCharArray();
                for (int j = 0; j < N; j++)
                {
                    input_matr[i, j] = temp_arr[j];
                }
            }
            //
            var rotate90 = Rotate90Clockwise(input_matr);
            //PrintMatrix(rotate90);
            //Console.WriteLine();
            var rotate180 = Rotate90Clockwise(rotate90);
            //PrintMatrix(rotate180);
            //Console.WriteLine();
            var rotate270 = Rotate90Clockwise(rotate180);
            //PrintMatrix(rotate270);
            //Console.WriteLine();
            //
            char[,] key = new char[N, N];
            //
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (input_matr[i, j] == '1' || rotate90[i, j] == '1' || rotate180[i, j] == '1' || rotate270[i, j] == '1')
                        key[i, j] = '1';
                    else
                        key[i, j] = 'R';
                }
            }
            //
            return (input_matr, rotate90, rotate180, rotate270, key);
        }
        public int[] CodeHucker(string input_text,char[,] matr)
        {
            int t = 0;
            int[] key = new int[N];
            for (int i = 0; i < N; i++)
            {
                string temp = "";
                for (int j = 0; j < N; j++)
                {
                    if (input_text[t] == matr[i, j])
                    {
                        temp += "1";
                        t++;
                    }
                    else
                    {
                        temp += "0";
                    }
                }
                key[i] = Convert.ToInt32(temp, 2);
            }

            return key;
        }
    }
}

