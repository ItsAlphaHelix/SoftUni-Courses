using System;
using System.Linq;

namespace Tuples
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string[] nameTownInput = Console.ReadLine()
                .Split(' ');
            string firstName = nameTownInput[0];
            string lastName = nameTownInput[1];
            string street = nameTownInput[2];
            string town = string.Join(" ", nameTownInput.Skip(3));

            string[] numberBeerInput = Console.ReadLine()
                .Split(' ');
            string name = numberBeerInput[0];
            int quantity = int.Parse(numberBeerInput[1]);
            string drunk = numberBeerInput[2];
            bool isDrunk = drunk == "drunk";

            string[] numbersInput = Console.ReadLine()
                .Split(' ');
            string nameTwo = numbersInput[0];
            double doubleNumber = double.Parse(numbersInput[1]);
            string bank = numbersInput[2];

            TupleClass<string, string, string> nameTown =
                new TupleClass<string, string, string>($"{firstName} {lastName}", street, town);

            TupleClass<string, int, bool> nameBeer = new TupleClass<string, int, bool>(name, quantity, isDrunk);

            TupleClass<string, double, string> numbers = new TupleClass<string, double, string>(nameTwo, doubleNumber, bank);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());
        }
    }
}
