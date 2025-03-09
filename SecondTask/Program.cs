using SecondTask.Models;
using SecondTask.Models.Base;
using SecondTask.Utils;

namespace SecondTask
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //Данные для теста
            var testCases = new List<(object firstObject, object secondObject)>
            {
                (new Cat { Name = "Пушок",  Color = "Черный" }, new Animal { Name = "Неклассифицированное животное" }),
                (new Animal { Name = "Неклассифицированное животное" }, new Animal { Name = "Странное животное" }),
                (new Dog { Name = "Боря", Breed = "Овчарка" }, new Animal { Name = "Неклассифицированное животное" }),
                (null, new Animal { Name = "Неклассифицированное животное",}), // предупреждение то будет разработчику, но для теста все-таки.
                (new Animal { Name = "Неклассифицированное животное"}, 1),
                (new Dog { Name = "Дружок", Breed = "Бульдог" }, "Строка"),
                ("Строка", new Cat { Name = "Злыдня", Color = "Белый" }),
                (new Water { IsSaltwater = true }, new Animal { Name = "Неклассифицированное животное" }),
                (1, 2),
            };

            // Словарь для обработки исключений
            var exceptionHandlers = new Dictionary<Type, Action<Exception>>
            {
                { typeof(ArgumentNullException), ex => Console.WriteLine($"{nameof(ArgumentNullException)}: {ex.Message}") },
                { typeof(ArgumentException), ex => Console.WriteLine($"{nameof(ArgumentException)}: {ex.Message}") },
                { typeof(Exception), ex => Console.WriteLine($"Unexpected exception: {ex.Message}") }
            };

            foreach (var testCase in testCases)
            {
                HandleTestCase(testCase, exceptionHandlers);
            }
        }

        /// <summary>
        /// Обрабатывает тестовый случай, вызывая метод GetClassRelationInfo и обрабатывая исключения.
        /// </summary>
        /// <param name="testCase">Тестовый случай.</param>
        /// <param name="exceptionHandlers">Словарь обработчиков исключений.</param>
        private static void HandleTestCase((object firstObject, object secondObject) testCase, Dictionary<Type, Action<Exception>> exceptionHandlers)
        {
            try
            {
                string result = ClassInfoProvider.GetClassRelationInfo(testCase.firstObject, testCase.secondObject);
                Console.WriteLine($"{result}");
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
                if (exceptionHandlers.TryGetValue(exceptionType, out Action<Exception>? value))
                {
                    value(ex);
                }
                else
                {
                    exceptionHandlers[typeof(Exception)](ex);
                }
            }
            Console.WriteLine();
        }
    }
}
