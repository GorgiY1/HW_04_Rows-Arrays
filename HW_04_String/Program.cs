using System;
using System.Linq;

namespace HW_04_String
{
    class Apart
    {
        public int Num_apart { get; set; }
        public int Amount_residents { get; set; }

        public override string ToString()
        {
            return $"\nApartment number: {Num_apart};\nAmount of residents: {Amount_residents};\n";
        }
    }
    class Program
    {
        static void InfoAboutRow (string s)
        {
            Console.WriteLine($"\t{s.Length} - Count symbols");

            int numberLetters = 0;
            int numberUppercase = 0;
            int numberLowercase = 0;
            int countNumbers = 0;
            int punctuationCharacters = 0;
            int numberSpaces = 0;

            foreach (char item in s)
            {
                if (char.IsLetter(item))
                {
                    numberLetters++;
                }
                if (char.IsUpper(item))
                {
                    numberUppercase++;
                }
                if (char.IsLower(item))
                {
                    numberLowercase++;
                }
                if (char.IsDigit(item))
                {
                    countNumbers++;
                } 
                if (char.IsPunctuation(item)) 
                {
                    punctuationCharacters++;
                }
                if (char.IsWhiteSpace(item))
                {
                    numberSpaces++;
                }

            }
            Console.WriteLine($"\t{numberLetters} - Number of all Letters");
            Console.WriteLine($"\t{numberUppercase} - Number of all uppercase letters");
            Console.WriteLine($"\t{numberLowercase} - Number of all lowercase letters");
            Console.WriteLine($"\t{countNumbers} - Count of numbers");
            Console.WriteLine($"\t{punctuationCharacters} - Number of punctuation characters ");
            Console.WriteLine($"\t{numberSpaces} - Number of spaces");
        }

        static int[] BecomeUnique(int []arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr.Length <= i)
                    {
                        i = arr.Length-1;
                    }

                    if (arr[i] == arr[j])
                    {
                        Array.Clear(arr, j, 1);
                        Array.Sort(arr);
                        Array.Reverse(arr);
                        Array.Resize<int>(ref arr, arr.Length - 1);
                        Array.Reverse(arr);
                    }
                }
            }
            return arr;
        }

        static void Print(int[] arr)
        {
            foreach (int item in arr) // show all array to console 
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int menu = 0;
            string line;
            string tmpLine = "";
            char character;

            Random random = new Random();
            do
            {
                Console.WriteLine("\nSelect a Task: from 1 to 6");

                try
                {
                    menu = int.Parse(Console.ReadLine());
                    if (menu < 0 || menu > 6)
                    {
                        throw new Exception("You entered invalid number, Input number from 1 to 6");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("================== Task: 1 =================\n");
                        Console.WriteLine("Создать метод принимающий, введенную пользователем, строку и выводящий на экран статистику по этой строке.Статистика должна включать общее количество символов,количество букв(и сколько в верхнем регистре и нижнем),количество цифр, количество символов пунктуации и количество пробельных символов.");
                        
                        /*1. Создать метод принимающий, введенную пользователем, 
                         * строку и выводящий на экран статистику по этой строке. 
                         * Статистика должна включать общее количество символов, 
                         * количество букв (и сколько в верхнем регистре и нижнем), 
                         * количество цифр, количество символов пунктуации и количество пробельных символов.*/

                        do
                        {
                            Console.WriteLine("Move to another element press enter...");
                            Console.WriteLine("Enter a row OR ENTER: ");
                           
                            line = Console.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                InfoAboutRow(line); // information about a row
                            }
                            
                        } while (!string.IsNullOrEmpty(line)); // for exit from loop click enter and do not input row

                        break;

                    case 2:
                        Console.WriteLine("================== Task: 2 =================\n");

                        Console.WriteLine("Пользователь вводит строку и символ. В строке найти все вхождения этого символа и перевести его в верхний регистр,а также удалить часть строки, начиная с последнего вхождения этого символа и до конца.");
                        /*2. Пользователь вводит строку и символ. 
                         * В строке найти все вхождения этого символа и перевести его в верхний регистр, 
                         * а также удалить часть строки, начиная с последнего вхождения этого символа и до конца.*/

                        do
                        {
                            Console.Write("Enter a row: ");
                            line = Console.ReadLine();
                            Console.Write("Enter a character: ");

                            if (string.IsNullOrEmpty(line))
                            {
                                break;
                            }

                            character = char.Parse(Console.ReadLine());

                            line = line.Replace(character, char.ToUpper(character));
                            Console.WriteLine(line);

                            Exception ex = new Exception($"This line: {line} - not have the character: {character}");

                            try
                            {
                                if (line.Contains(char.ToUpper(character)))
                                {
                                    Console.WriteLine(line.Remove(line.LastIndexOf(char.ToUpper(character))));
                                }
                                else
                                {
                                    throw ex;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        } while (!string.IsNullOrEmpty(line)); // for exit from loop click enter and do not input row

                        break;

                    case 3:

                        Console.WriteLine("================== Task: 3 =================\n");

                        Console.WriteLine("Программа преобразует строку таким образом, что цифры, которые находятся в слове,переносятся в конец строки без изменения порядка следования остальных символов.");
                        
                        /*3. Программа преобразует строку таким образом, что цифры, которые находятся в слове,
                         * переносятся в конец строки без изменения порядка следования остальных символов.*/

                        do
                        {
                            Console.Write("Enter a row or enter for exit from this menu: ");
                            line = Console.ReadLine();

                            if (string.IsNullOrEmpty(line))
                            {
                                break;
                            }

                            foreach (char item in line)
                            {
                                if (char.IsDigit(item))
                                {
                                    tmpLine += item;
                                    line = line.Remove(line.IndexOf(item), 1);
                                }
                            }

                            line += tmpLine;
                            Console.WriteLine(line);

                            tmpLine = "";

                        } while (!string.IsNullOrEmpty(line));

                        break;

                    case 4:

                        Console.WriteLine("================== Task: 4 =================\n");
                        Console.WriteLine("аны 2 массива размерности M и N соответственно. Необходимо переписать в третий массив общие элементы первых двух массивов без повторений.");

                        /*4. Даны 2 массива размерности M и N соответственно. 
                         * Необходимо переписать в третий массив общие элементы первых двух массивов без повторений.*/

                        int[] arr = new int[8];
                        int[] arr1 = new int[12];
                        int[] arr2 = new int[0];

                        int tmp = -1;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = random.Next(0, 10);
                        }

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            arr1[i] = random.Next(0, 10);
                        }

                        Array.Sort(arr);
                        Array.Sort(arr1);

                        Console.WriteLine("This is source arrays: ");

                        Console.Write("Arr1: ");
                        Print(arr);
                        Console.Write("Arr2: ");
                        Print(arr1);

                        arr = BecomeUnique(arr); // all numbers of array become unique
                        arr1 = BecomeUnique(arr1); // all numbers of array become unique


                        int index = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = 0; j < arr1.Length; j++)
                            {
                                if (arr[i] == arr1[j])//here the variable "tmp" does not allow this number to be repeated 
                                {
                                    Array.Resize<int>(ref arr2, arr2.Length + 1);

                                    arr2[index] = arr[i];
                                    index++;
                                }
                            }
                        }
                        arr2 = BecomeUnique(arr2); // all numbers of array become unique
                        Console.Write("Arr3, Result array: ");
                        Print(arr2);

                        break;
                    case 5:

                        Console.WriteLine("================== Task: 5 =================\n");

                        /*5. Дан двумерный массив размерностью 5х5, 
                         * заполненный случайными числами из диапазона от 0 до 100. 
                         * Переформировать массив таким образом, 
                         * чтобы его столбцы располагались по убыванию их поэлементных сумм.*/

                        int size = 3;

                        int[,] numArr = new int[size, size];
                        int[] sumArr = new int[size];

                        //Array.Sort(jaggedDouble[0]);

                        for (int i = 0; i < numArr.GetLength(0); i++)
                        {
                            for (int j = 0; j < numArr.GetLength(1); j++)
                            {
                                numArr[j, i] = random.Next(0, 100);
                                sumArr[i] += numArr[j, i];
                            }
                        }

                        Console.WriteLine("Before sorting: \n");
                        for (int i = 0; i < numArr.GetLength(0); i++)
                        {
                            for (int j = 0; j < numArr.GetLength(1); j++)
                            {
                                Console.Write($"{numArr[i, j]}\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        for (int i = 0; i < sumArr.Length; i++)
                        {
                            Console.Write($"{sumArr[i]}\t");
                        }

                        Console.WriteLine("\n\nAfter sorting: \n");

                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size - 1 - i; j++)
                            {
                                if (sumArr[j + 1] < sumArr[j])
                                {
                                    int buf1 = sumArr[j + 1];
                                    sumArr[j + 1] = sumArr[j];
                                    sumArr[j] = buf1;

                                    for (int l = 0; l < size; l++)
                                    {
                                        int buf2 = numArr[l, j + 1];
                                        numArr[l, j + 1] = numArr[l, j];
                                        numArr[l, j] = buf2;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < numArr.GetLength(0); i++)
                        {
                            for (int j = 0; j < numArr.GetLength(1); j++)
                            {
                                Console.Write($"{numArr[i, j]}\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        for (int i = 0; i < sumArr.Length; i++)
                        {
                            Console.Write($"{sumArr[i]}\t");
                        }

                        Console.WriteLine();
                        break;

                    case 6:

                        /*6. В массиве хранится информация о количестве жильцов каждой
                         * квартиры пятиэтажного дома (4 подъезда, на каждом этаже по 2 квартиры).
                        - по выбранному номеру квартиры определить количество жильцов,
                        а также их соседей, проживающих на одном этаже;
                        - определить суммарное количество жильцов для каждого подъезда;
                        - определить номера квартир, где живут многодетные семьи. 
                        Условно будем считать таковыми, у которых количество членов семьи превышает пять человек.
                        */

                        Apart[,,] arrResidents = new Apart[5, 4, 2];

                        for (int i = 0; i < arrResidents.GetLength(0); i++)
                        {
                            for (int j = 0; j < arrResidents.GetLength(1); j++)
                            {
                                for (int l = 0; l < arrResidents.GetLength(2); l++)
                                {
                                    arrResidents[i, j, l] = new Apart();
                                }
                            }
                        }

                        int ap_number = 0;
                        for (int i = 0; i < arrResidents.GetLength(1); i++)
                        {
                            for (int j = 0; j < arrResidents.GetLength(0); j++)
                            {
                                for (int l = 0; l < arrResidents.GetLength(2); l++)
                                {
                                    arrResidents[j, i, l].Amount_residents = random.Next(1, 10);
                                    arrResidents[j, i, l].Num_apart = ++ap_number;
                                }
                            }
                        }

                        int menu2 = 0;
                        int select_number = 0;
                        int sum_resid = 0;
                       
                        do
                        {
                            Console.WriteLine("\n=============================");
                            Console.WriteLine($"\n   Select operation: ");
                            Console.WriteLine($"1. Show all resident of house: ");
                            Console.WriteLine($"2. Show amount residents by number: ");
                            Console.WriteLine($"3. Calculate the total number of residents for each entrance: ");
                            Console.WriteLine($"4. Find apartment numbers where large families live: ");
                            Console.WriteLine("=============================\n");


                            try
                            {
                                menu2 = int.Parse(Console.ReadLine());
                                if (menu < 0 || menu > 4)
                                {
                                    throw new Exception("You entered invalid number, Input number from 1 to 4");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }

                            switch (menu2)
                            {
                                case 1:

                                    for (int i = 0; i < arrResidents.GetLength(0); i++)
                                    {
                                        Console.WriteLine($"Floor: {i + 1}");
                                        Console.WriteLine("Entrances: ap'num': res|ap'num': res"); //apartments in the entrances on the some floor 
                                        for (int j = 0; j < arrResidents.GetLength(1); j++)
                                        {
                                            int l = 0;
                                            Console.Write($"Entrance {j + 1}: "); //Entrance {Entrance number} ap'{apartment number}'
                                            for (; l < arrResidents.GetLength(2); l++)
                                            {
                                                Console.Write($"ap'{arrResidents[i, j, l].Num_apart}': {arrResidents[i, j, l].Amount_residents}\t");  //amount residents in every apartment
                                            }
                                            Console.WriteLine();
                                        }
                                    }

                                    break;

                                case 2:

                                    Console.Write("Input apart number: ");
                                    select_number = int.Parse(Console.ReadLine());

                                    for (int i = 0; i < arrResidents.GetLength(1); i++)
                                    {
                                        for (int j = 0; j < arrResidents.GetLength(0); j++)
                                        {
                                            for (int l = 0; l < arrResidents.GetLength(2); l++)
                                            {
                                                if (arrResidents[j, i, l].Num_apart == select_number)
                                                {
                                                    Console.WriteLine($"In apartment by number:{arrResidents[j, i, l].Num_apart}, lives: {arrResidents[j, i, l].Amount_residents} residents ");
                                                }
                                            }
                                        }
                                    }

                                    break;

                                case 3:

                                    for (int i = 0; i < arrResidents.GetLength(1); i++)
                                    {
                                        Console.Write($"Entrance {i + 1}: "); //Entrance {Entrance number} ap'{apartment number}'

                                        for (int j = 0; j < arrResidents.GetLength(0); j++)
                                        {
                                            int l = 0;
                                            for (; l < arrResidents.GetLength(2); l++)
                                            {
                                                sum_resid += arrResidents[j, i, l].Amount_residents;
                                            }
                                        }
                                        Console.WriteLine($"{sum_resid} residents");
                                        sum_resid = 0;
                                    }

                                    break;

                                case 4:

                                    sum_resid = 0;
                                    for (int i = 0; i < arrResidents.GetLength(1); i++)
                                    {
                                        for (int j = 0; j < arrResidents.GetLength(0); j++)
                                        {
                                            int l = 0;
                                            for (; l < arrResidents.GetLength(2); l++)
                                            {
                                                if (arrResidents[j, i, l].Amount_residents > 5)
                                                {
                                                    Console.WriteLine($"Large families live in these apartments: {arrResidents[j, i, l].Num_apart}, amount humans: {arrResidents[j, i, l].Amount_residents}");
                                                    sum_resid++;
                                                }
                                            }
                                        }
                                        Console.WriteLine($"\nEntrance '{i + 1}' in it: {sum_resid} large families\n");
                                        sum_resid = 0;
                                    }
                                    break;

                                default:
                                    break;
                            }

                        } while (menu2 != 0);

                        break;
                    default:
                        break;
                }
            } while (menu != 0);
           
            

           
            
            Console.ReadKey();
        }
    }
}
