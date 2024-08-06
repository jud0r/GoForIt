// See https://aka.ms/new-console-template for more information

using GoForIt;

Car car1 = new Car("Mercedes", "black");
Car car2 = new Car("Mercedes", "black");

Console.WriteLine(car1.Equals(car2));
Console.WriteLine(car1 == car2);
Console.WriteLine(!(car1 != car2));


int[] intArray = [1, 2, 3, 4, 5];
string[] stringArray = ["Banana", "Apple", "Kiwi"];
double[] doubleArray = [3.5, 2.2, 4.7];

List<int> intList = new List<int> { 6, 7, 8, 9, 10};
List<string> stringList = new List<string> { "Jorel", "Pedro", "Marcos" };
List<double> doubleList = new List<double> { 10.2, 13.7, 25.5 };
Car[] cars = new Car[] { car1, car2 };

Console.WriteLine("Int array:");
Printing.PrintArray(intArray);
Console.WriteLine();
Console.WriteLine("String array:");
Printing.PrintArray(stringArray);
Console.WriteLine();
Console.WriteLine("Double array:");
Printing.PrintArray(doubleArray);
Console.WriteLine();
Console.WriteLine("Int list:");
Printing.PrintArray(intList);
Console.WriteLine();
Console.WriteLine("String list:");
Printing.PrintArray(stringList);
Console.WriteLine();
Console.WriteLine("Double list:");
Printing.PrintArray(doubleList);
Console.WriteLine();
Console.WriteLine("Cars list");
Printing.PrintArray(cars);

Console.WriteLine();
Console.WriteLine();

var listValidator = new ValidList();

var success = new Dictionary<string, string[]>
{
    {"list1", ["A", "A", "B"] },
    {"list2", ["C", "C", "C"] }
};

var fail = new Dictionary<string, string[]>
{
    {"list1", ["A", "A", "B"] },
    {"list2", ["A", "C", "C"] }
};
Console.WriteLine($"[Success case] Is correct: {ValidList.AreListsValid(success) == true}");
Console.WriteLine($"[Fail case] Is correct: {ValidList.AreListsValid(fail) == false}");

Console.WriteLine();

listValidator.OrderList();

Console.WriteLine();

var th = new Threads();
th.Test2();

Console.ReadLine();