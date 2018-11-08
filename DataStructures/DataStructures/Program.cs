using DataStructures.libraries.BinarySearchTree;
using DataStructures.libraries.List;
using DataStructures.libraries.Recursive;
using DataStructures.libraries.Sortings;
using DataStructures.libraries.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.libraries.Utilities;
using System.Data.SqlClient;
using System.Configuration;

namespace DataStructures
{
    public class Program
    {

        public static double GetBalanceCompoundByYear(double currentBalance, double interestRate, DateTime startDate, DateTime endDate)
        {
            double newBalance = 0.00d;
            double monthlyPrinciple = 1200.00d;

            Console.Write($"\nOriginal Balance:\t{currentBalance}\tInterest Rate:\t{interestRate}%\n");
            Console.Write($"\nFrom:\t{startDate}\tTo:\t{endDate}\n");

            int numberOfMonths = (int)((endDate - startDate).Days / 365) * 12;

            for(int i = 0; i < numberOfMonths; i++)
            { 
                // If we are calculate APR (Annual Percentage Rate) that are compound Monthly
                // 12 is the number of months in a year.
                double monthlyRate = (interestRate / 1200); // Equivalent to (interestRate / 100 / 12)
                double financialCharge = currentBalance * monthlyRate;

                newBalance = Math.Round(currentBalance + financialCharge, 2) - monthlyPrinciple;
                currentBalance = newBalance;

                Console.Write($"\nCompounded Monthly {i + 1}:\t{currentBalance}");
            }

            return newBalance;        
        }

        public static decimal GetTaxRate(DateTime dt)
        {
            decimal taxBalance = new decimal(5143.00d);
            decimal taxInterest = new decimal(2d);
            decimal retTaxRate = new decimal(0d);

            //retTaxRate = taxBalance + (taxBalance * (taxInterest / 100) * ((DateTime.Now - dt).Days) / 365);
            // Total compounded interest = P(1 + r/n) ^(nt) - P
            double baseValue = (double)(1 + ((taxInterest / 100) / 12));
            double exponent = (12 * (DateTime.Now.Year - dt.Year));
            retTaxRate = taxBalance * (decimal)Math.Pow(baseValue, exponent);
            return retTaxRate;
        }

        public static void ShowDataFromDatabase()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["3O"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();
                Console.WriteLine("Database Connected\n");

                SqlDataReader sqlReader = null;
                SqlCommand sqlCommand = new SqlCommand("SELECT [CityId],[StateId],[CityName],[IsActive],[Created],[LastUpdated] FROM [3O].[dbo].[MajorUSCitiesEnum]", conn);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    Console.WriteLine($"{sqlReader["CityId"].ToString()} | {sqlReader["StateId"].ToString()} | {sqlReader["CityName"].ToString()} | {sqlReader["IsActive"].ToString()} | {sqlReader["Created"].ToString()} | {sqlReader["LastUpdated"].ToString()}");
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ShowOutputInForLoop()
        {
            int i = 0;
            for(;i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void Main(string[] args)
        {
            //ShowOutputInForLoop();
            //ShowDataFromDatabase();
            Console.Write($"\n\nNew Balance: {GetBalanceCompoundByYear(250000.00d, 2.75d, DateTime.Now, new DateTime(2035, 11, 4))}\n\n");

            Console.WriteLine(GetTaxRate(DateTime.Now));
            Console.WriteLine(GetTaxRate(new DateTime(1995, 4, 15)));
            Console.WriteLine(Math.Round(GetTaxRate(new DateTime(1995, 4, 15)) - GetTaxRate(DateTime.Now), 2));
            string input = Console.ReadLine();

            //BinarySearchTree bst = new BinarySearchTree();

            //bst.Insert('F');
            //bst.Insert('D');
            //bst.Insert('J');
            //bst.Insert('B');
            //bst.Insert('E');
            //bst.Insert('G');
            //bst.Insert('K');
            //bst.Insert('A');
            //bst.Insert('C');
            //bst.Insert('I');
            //bst.Insert('H');

            //Console.Write("Total Number of Node(s) = " + bst.Size + "\n");

            //Console.Write("Post-Order Tree Output:\t");
            //bst.ShowPreOrderTree(bst.Root);
            //Console.Write("\n");
            
            //Console.Write("In-Order Tree Output:\t");
            //bst.ShowInOrderTree(bst.Root);
            //Console.Write("\n");

            //Console.Write("Post-Order Tree output:\t");
            //bst.ShowPostOrderTree(bst.Root);
            //Console.Write("\n");

            //Console.Write("Delete 'F' from the tree:\t");
            //bool success = false;
            //bst.Delete(bst.Root, 'F', ref success);
            //bst.ShowInOrderTree(bst.Root);
            //Console.Write("\n\n");

            //Console.Write("Ackermann Function for m = 1 , n = 2 :\n");
            //Console.Write("Acker(1, 2) = " + Recursion.Acker(1, 2));
            //Console.Write("\n\n");

            //Console.Write("Tower of Hanoi :\n");
            //Recursion.SolveTowers(3, 'A', 'B', 'C');
            //Console.Write("\n\n");

            //Console.Write("Binary Search of Array : <1, 5, 9, 12, 15, 21, 29, 31>\n");
            //int[] array = {1, 5, 9, 12, 15, 21, 29, 31};
            //int index = -1;
            //int searchValue = 15;
            //Recursion.BinarySearchOfArray(array, 0, 7, searchValue, ref index);
            //if (index >= 0)
            //    Console.Write("Found " + array[index] + " at index = " + index);
            //else
            //    Console.Write("Can't Find value " + searchValue + " in the array");
            //Console.Write("\n\n");

            //Console.Write("Selection Sort Algorithm:\nInput: <45, 8, 5, 99, 20, 18, 35, 40>\nOutput: ");
            //int[] array2 = { 45, 8, 5, 99, 20, 18, 35, 40 };
            //SortFunction.SelectionSort(array2, 1, 8);
            //for (int i = 0; i < array2.Length; i++)
            //    Console.Write(" " + array2[i]);
            //Console.Write("\n\n");

            //Console.Write("Bubble Sort Algorithm:\nInput: <20, 18, 16, 14, 12, 10, 8, 6, 4, 2, 1>\nOutput: ");
            //int[] array3 = { 20, 18, 16, 14, 12, 10, 8, 6, 4, 2, 1 };
            //SortFunction.BubbleSort(array3);
            //for (int i = 0; i < array3.Length; i++)
            //    Console.Write(" " + array3[i]);
            //Console.Write("\n\n");

            //Console.Write("Insertion Sort Algorithm:\nInput: <29, 10, 14, 37, 13>\nOutput: ");
            //int[] array4 = { 29, 10, 14, 37, 13 };
            //SortFunction.InsertionSort(array4, array4.Length);
            //for (int i = 0; i < array4.Length; i++)
            //    Console.Write(" " + array4[i]);
            //Console.Write("\n\n");

            //Console.Write("Merge Sort Algorithm:\nInput: <29, 10, 14, 37, 13 >\nOutput: ");
            //int[] array5 = { 29, 10, 14, 37, 13 };
            //SortFunction.MergeSort(array5, 1, array5.Length);
            //for (int i = 0; i < array5.Length; i++)
            //    Console.Write(" " + array5[i]);
            //Console.Write("\n\n");
            
            //Console.Write("Kth Smallest Integer Value,\nInput: <10, 5, 3, 8, 6, 4 >\nOutput: ");
            //int[] array6 = { 10, 5, 3, 8, 6, 4 };
            //Console.Write(" " + Recursion.FindSmallestNumber(array6, 1, array6.Length));

            //Console.Write("Quick Sort Algorithm:\nInput: <10, 5, 3, 8, 6, 4>\nOutput: ");
            //SortFunction.QuickSort_Recursive(array6, 0, array6.Length - 1);
            //Console.Write("\n\n");
            //for (int i = 0; i < array6.Length; i++)
            //    Console.Write(" " + array6[i]);
            //Console.Write("\n\n");


            //int[] arrs = { 0, 3, 5, 7, 10 };
            //Console.Write("Missing Range of Sorted List: [ 0, 3, 5, 7, 10 ] ");
            //Google.FindMissingRange(arrs);
            //Console.WriteLine();

            //String test = "Child & Service     #123";
            //test = Utilities.cleanString(test);
            //Console.WriteLine();
            //Console.Write("Clean string = " + test);
            //Console.WriteLine();

            //RunLinkListSamples();

            //RunPalindromesTest();

            //RunAnBnFormTest();

            Console.ReadKey();
        }

        public static void RunLinkListSamples()
        {
            LinkList ll = new LinkList();

            ll.Add(3);
            ll.Add(16);
            ll.Add(55);
            ll.Add(75);
            ll.Add(88);
            ll.Add(4);
            ll.Add(56);

            Console.Write("\n");
            Console.Write("Link List:\t" + ll.ToString());
            Console.Write("Get Item in List Position 5:\t" + ll.GetListItemAt(5));
            Console.Write("\n");
        }

        public static void RunPalindromesTest()
        {
            string word = "abcdcba";
            Console.Write("\n");
            Console.Write("Palindromes Test:\t" + word + " = " + Recursion.IsPalindromes(word));
            Console.Write("\n");

        }

        public static void RunAnBnFormTest()
        {
            string word = "aaaaaaabbbbbbb";
            Console.Write("\n");
            Console.Write("A^nB^n Form Test:\t" + word + " = " + Recursion.IsWordAnBnForm(word));
            Console.Write("\n");
        }
    }
}
