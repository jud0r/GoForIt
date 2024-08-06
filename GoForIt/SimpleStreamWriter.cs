

namespace GoForIt
{
    public class SimpleStreamWriter : IDisposable
    {
        private readonly StreamWriter _writer;

        public SimpleStreamWriter(string path, bool append = false)
        {
            _writer = new StreamWriter(path, append);
        }

        public void WriteLine(string text)
        {
            _writer.WriteLine(text);
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }

    class Car(string name, string color)
    {
        public string Name { get; } = name;
        public string Color { get; } = color;

        public static bool operator ==(Car a, Car b) => a.Equals(b);
        public static bool operator !=(Car a, Car b) => !a.Equals(b);

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Car) return false;
            var auxObj = obj as Car;
            return Name.Equals(auxObj?.Name) && Color.Equals(auxObj?.Color);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}";
        }
    }

    static class Printing
    {
        public static void PrintArray<T>(IEnumerable<T> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }

    class ValidList()
    {
        public static bool AreListsValid(Dictionary<string, string[]> lists)
        {
            var generalList = new List<string>();
            var auxList = new List<string>();
            foreach (var list in lists)
            {
                foreach (var item in list.Value)
                {
                    if (generalList.Contains(item))
                    {
                        return false;
                    }
                    auxList.Add(item);
                }
                generalList.AddRange(auxList);
            }
            return true;
        }

        //Deferred Execution: The Order() and OrderDescending() methods in LINQ use deferred execution.
        //This means that the sorting operation is not performed until the enumeration of the sorted sequence begins.
        public void OrderList()
        {
            List<int> list = [2, 1, 3];
            IEnumerable<int> sortedList1 = list.Order();
            list.Add(4);
            IEnumerable<int> sortedList2 = list.OrderDescending();
            DisplayList(sortedList1);
            DisplayList(sortedList2);
        }

        private void DisplayList(IEnumerable<int> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
