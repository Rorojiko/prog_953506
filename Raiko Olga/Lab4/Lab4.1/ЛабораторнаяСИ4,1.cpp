﻿/*4.1 С клавиатуры вводится многострочный текст. Оставить в тексте
только первые вхождения каждой буквы, остальные – удалить.
Вывести слова полученного текста, которые начинаются и
заканчиваются одной и той же буквой. */

#include <iostream>
#include <stdio.h>
#include <locale.h>
using namespace std;

void strSort(char str[], const int size);
void strShow(char str[], int size);

int main()
{
    setlocale(LC_ALL, "Rus");
    printf("Введите текст: ");
    const int size = 100;
    char str[size];
    gets_s(str);
    strSort(str, size);
    printf("%s \n", str);
    strShow(str, size);
    return 0;
}

//функция удаления слов с одинаковыми буквами в начале
void strSort(char str[], const int size)
{
    char basic;
    //цикл идет по каждой букве строки
    for (int x = 0; x < size; x++)
    {
        if (str[x] == '\0')
        {
            break;
        }
        else if (str[x] != ' ')
        {
            //если буква в начале слова или в начале строки, то запоминаем ее
            if ((x == 0) || ((str[x - 1] == ' ') && (x != 0)))
            {
                basic = str[x];
            }

            //начиная с позиции, где мы нашли подходящую букву, идем по строке 
            //в поисках слова, начинающегося с такой же буквы
            for (int i = x; i < size; i++)
            {
                //идем по слову, подсчитывя кол-во букв в нем
                for (int j = i; j < size; j++)
                {
                    if ((str[j] == ' '))
                    {
                        //идем по слову, заменяя все буквы на пробелы
                        if (str[j + 1] == basic)
                        {
                            for (int k = j + 1; ; k++)
                            {
                                if (str[k] != ' ')
                                {
                                    str[k] = ' ';
                                }
                                else
                                {
                                    i += k - 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

//ф-ция вывод слов с одинаковыми буквами в конце и в начале
void strShow(char str[], int size)
{
    char basic;

    //цик идет по каждой букве строки
    for (int y = 0; y < size; y++)
    {
        if (str[y] == '\0')
        {
            break;
        }
        //запоминаем букву
        else if (str[y] != ' ')
        {
            basic = str[y];
            //идем по слову
            for (int i = y; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    //если это последняя буква и она равна записанной ранее букве
                    //выводим его
                    if ((str[j] == basic) && (str[j + 1] == ' '))
                    {
                        for (int k = i; k < j + 1; k++)
                        {
                            printf("%c", str[k]);
                        }
                        printf("\n");
                    }
                    else if (str[j] == ' ')
                    {
                        i += j;
                        break;
                    }
                }
            }
        }
    }
}