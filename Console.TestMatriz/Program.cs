﻿using static System.Linq.Enumerable;

int[,] m = { { 1, 2 }, { 3, 4 } }; //Multidimensional Arrays 

Console.WriteLine(m.Rank);
Console.WriteLine(m.Length);

Console.WriteLine("===========");
foreach (int x in m)
{
    Console.WriteLine(x);
}

var printMatriz = (int[,] mt) =>
{
    Console.WriteLine("===========");
    foreach (int r in Range(0, mt.Rank))
    {
        foreach (int c in Range(0, mt.GetLength(r)))
        {
            Console.WriteLine($"mt[{r},{c}] => {mt[r, c]}");
        }
    }
};

printMatriz(m);

List<List<int>> listMatriz = new()
{
    new() {1,2,3},
    new() {4,5,6},
    new() {7,8,9},
};

int[,] m1 = new int[listMatriz.Count, listMatriz[0].Count];

foreach (int r in Range(0, m1.Rank))
{
    foreach (int c in Range(0, m1.GetLength(r)))
    {
        m1[r, c] = listMatriz[r][c];
    }
}

printMatriz(m1);

List<List<int>> jaggedList = new()
{
    new() {1,2,3},
    new() {4,5},
    new() {6,7,8,9},
};

int[][] m2 = jaggedList.Select(x => x.ToArray()).ToArray();

var printJagged = (int[][] jg) =>
{
    Console.WriteLine("===========");
    foreach (int r in Range(0, jg.Length))
    {
        foreach (int c in Range(0, jg[r].Length))
        {
            Console.WriteLine($"jg[{r}][{c}] => {jg[r][c]}");
        }
    }
};

printJagged(m2);

//Instanciation types:

int[,] t = new int[3, 4];
int[,] t1 = { { 1, 2, 3}, { 1, 2, 3} };

int[][] t2 = new int[2][];
t2[0] = new int[3];
t2[1] = new int[4];

int[][] t3 =
{
    new int[] { 1, 2, 3},
    new int[] { 1, 2, 3},
    new int[] { 1, 2, 3},
};