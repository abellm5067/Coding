using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AllPrograms
    {
        public void GetMaxPalidrome(string palindrome = "")
        {
            List<string> palindromes = new List<string>();
            if (!string.IsNullOrEmpty(palindrome))
            {
                for (int i = 0; i < palindrome.Length; i++)
                {
                    for (int j = i; j < palindrome.Length; j++)
                    {
                        if (j == 0)
                            continue;
                        else
                        {
                            palindromes.Add(palindrome.Substring(i, j - i + 1));
                        }
                    }

                }
                var palindromelist = new List<string>();
                foreach (string item in palindromes)
                {
                    string forward = item;
                    var revstr = new string(item.Reverse().ToArray());
                    if (forward == revstr)
                    {
                        palindromelist.Add(forward);
                    }
                }
                Console.WriteLine(palindromelist.Max(x => x.Length));
            }
        }
        public void GetMissingItems(int[] vs)
        {
            //int[] vs = new int[] { 10, 8, 5, 3, 2 };
            vs = vs.OrderBy(x => x).ToArray();
            for (int i = 0; i < vs.Length; i++)
            {
                if (i < vs.Length - 1)
                {
                    if ((vs[i + 1] - vs[i]) > 1)
                    {
                        for (int j = vs[i] + 1; j < vs[i + 1]; j++)
                        {
                            Console.WriteLine(j);
                        }
                    }
                }
            }
        }
        public void GetFactorial()
        {
            int output = 0;
            GetFact(5, ref output);
            Console.WriteLine(output);
        }
        public void GetFact(int input, ref int output)
        {

            if (input > 1)
            {
                output = output == 0 ? input * (input - 1) : output * (input - 1);
                GetFact(input - 1, ref output);
            }

        }
        public void PrintRepeated(string str = "")
        {
            string store = "";
            for (int qq = 0; qq < str.Length; qq++)
            {

                if (!store.Contains(str[qq]))
                {
                    Console.WriteLine(str[qq]);
                    Console.WriteLine(str.Where(x => x == str[qq]).Count());
                    store += str[qq];
                }

            }
        }

        public void SortOrder(int[] arr)
        {
            int size = arr.Length;
            int temp;
            for (int j = 0; j <= size - 1; j++)
            {
                int count = 0;
                for (int i = 0; i < size - 1; i++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        count++;
                    }

                }
                if (count == 0)
                    return;
            }

        }
        public void RotateLeft(int[] array)
        {
            int size = array.Length;
            int temp;
            for (int j = size - 1; j > 0; j--)
            {
                temp = array[size - 1];
                array[size - 1] = array[j - 1];
                array[j - 1] = temp;
            }

            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }
        public void RotateRight(int[] array)
        {
            int size = array.Length, temp;
            for (int i = 0; i < size; i++)
            {
                if (i < size - 1)
                {
                    temp = array[0];
                    array[0] = array[i + 1];
                    array[i + 1] = temp;
                }

            }

        }
        public void PrintSuperIntegerContainedString(int superresult, string superinput)
        {
            List<int> Id = new List<int>();
            while (superresult > 0)
            {
                int values = superresult % 10;
                superresult = superresult / 10;
                int index = superinput.ToString().LastIndexOf(values.ToString());
                Id.Add(superinput.ToString().LastIndexOf(values.ToString()));
                superinput = superinput.Remove(index);
            }
            Console.WriteLine(Id.ToString());

        }

        public void ReverseTheWordsOfGivenString(string str, ref string output)
        {
            foreach (var item in str.Split(' '))
            {
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    output += item[i];
                }
                output += " ";
            }

        }
        public void GetSequenceCharacterCount(string s)
        {
            char[] chararr = s.ToCharArray();
            int i = 0; int repeatedCount = 1;
            foreach (char item in chararr)
            {
                if (i < chararr.Length - 1 && i > 0)
                {
                    if (s[i] == s[i + 1] || s[i] == s[i - 1])
                    {
                    }
                    else
                    {
                        chararr[i] = ' ';
                    }
                }
                i++;

            }
            i = 0;
            foreach (char item in chararr)
            {
                if (i < chararr.Length && i > 0)
                {
                    if (chararr[i] != ' ' && chararr[i] == chararr[i - 1])
                    {
                        repeatedCount++;
                    }
                    else
                    {
                        if (repeatedCount > 1)
                        {
                            Console.WriteLine(chararr[i - 1].ToString() + repeatedCount);
                            repeatedCount = 1;
                        }
                    }
                    if (i == chararr.Length - 1)
                    {
                        Console.WriteLine(chararr[i - 1].ToString() + repeatedCount);
                    }
                }
                i++;

            }

        }
        public void NumberofClients(int n, string clientOrders)
        {
            string output = ""; int sum = 0;
            string[] values = clientOrders.Split(' ');
            foreach (var item in values)
            {
                for (int j = 0; j < item.Length; j++)
                {
                    sum += Convert.ToInt32(item[j].ToString());
                }
                output += sum.ToString() + " ";
                sum = 0;
            }

            Console.WriteLine(output);
        }

    }
}
