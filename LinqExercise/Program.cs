using LinqExercise.Data;
using LinqExercise.Extentions;
using LinqExercise.Models;
using System.Linq;
using System.Xml.Serialization;
namespace LinqExercise
{
    public class Program
    {
        public static List<int> FilterList(List<int> lst, Func<int, bool> condition)
        {
            List<int> result = new List<int>();
            foreach (var item in lst)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int i = 8;


            Func<int, bool> IsEven = (x) => x % 2 == 0;
            Console.WriteLine(IsEven(5));
            Console.WriteLine(IsEven(4));
            //---------------------------------
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evens = FilterList(numbers, IsEven);
            List<int> fiveOrMore = FilterList(numbers, x => x >= 5);
           
            #region שימוש בFUNC במקום פונקציה רגילה
            Func<List<int>, Predicate<int>, List<int>> FilterFunc = (lst, condition) =>
            {
                {
                    List<int> result = new List<int>();
                    foreach (var item in lst)
                    {
                        if (condition(item))
                        {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            };
			#endregion

			#region שימוש בEXTENSIONS
			//example of using extension methods

			#endregion

			#region שימוש בLINQ
			List<Student> students = new List<Student>()
            {
                new Student() { Name = "Alice", Age = 20, grade = 90, ClassName = "Math" },
                new Student() { Name = "Bob", Age = 22, grade = 85, ClassName = "Science" },
                new Student() { Name = "Charlie", Age = 21, grade = 95, ClassName = "Math" },
                new Student() { Name = "David", Age = 23, grade = 80, ClassName = "History" },
                new Student() { Name = "Eve", Age = 20, grade = 88, ClassName = "Science" },
                new Student() { Name = "Frank", Age = 24, grade = 92, ClassName = "Math" },
                };

            #region דוגמאות LINQ

            bool isExist = students.Any(x => x.grade == 90);
            // למעלה: האם קיים מישהו עם ציון 90 ברשימה

            //---Linq Methods---
            var max_student = students.Max((s) => s.grade);
            //Max
            var st = students.FirstOrDefault(x => x.grade >= 80);
            //FirstOrDefault
            Student s = students.SingleOrDefault(x => x.grade == 88);
            //SingleOrDefault
            List <Student> new_s = students.Where(x => x.grade > 85).ToList();
			//where
            //where Query
			//OrderBy
			//Any
			//Select
            

			#endregion
			#endregion

			#region Test Monkey Exercise
			//השלמת תרגיל הקופים מהחומר הנלמד
            MonkeyList monkeys = new MonkeyList(); // יצירת אובייקט של רשימת הקופים

            try
            {
                // 1. הדפסת נתוני קוף לפי שם
                //42
                Monkey monkeyByName = monkeys.SearchMonkeyByName("Baboon");
                Console.WriteLine(monkeyByName);

                // 2. הדפסת כל הקופים לפי מיקום
                // 42
                List<Monkey> monkeysByLocation = monkeys.GetAllMonkeysPerLocation("Africa & Asia");
                monkeysByLocation.ForEach(m => Console.WriteLine(m.Name));

                // 3. בדיקה אם יש קוף במיקום מסוים
                //42
                bool isMonkeyInLocation = monkeys.IsThereMonkeyInThatLocation("Japan");
                Console.WriteLine(isMonkeyInLocation);

                // 4. מיון לפי מיקום ושם
                //42
                List<Monkey> sortedMonkeys = monkeys.SortByLocattionAndName();
                sortedMonkeys.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 5. חיפוש קוף לפי שם (שימוש ב-LINQ)
                //42
                Monkey monkeyByNameQuery = monkeys.SearchMonkeyByNameQuery("Capuchin Monkey");
                Console.WriteLine(monkeyByNameQuery);

                // 6. הדפסת כל הקופים לפי מיקום (שימוש ב-LINQ)
                //42
                var monkeysByLocationQuery = monkeys.GetAllMonkeysPerLocationQuery("Central & South America");
                monkeysByLocationQuery.ForEach(m => Console.WriteLine(m.Name));

                // 7. מיון לפי מיקום ושם (שימוש ב-LINQ)
                //42
                var sortedMonkeysQuery = monkeys.SortByLocattionAndNameQuery();
                sortedMonkeysQuery.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 8. הדפסת מספר הקופים לפי מיקום
                // 42
                //monkeys.PrintNumberOfMonkeysPerLocation();

                // 9. הדפסת מספר הקופים לפי מיקום (שימוש ב-LINQ)
                monkeys.PrintNumberOfMonkeysPerLocationQuery();

                // 10. קבלת כל הקופים לפי שם
                var monkeysByNameArray = monkeys.GetAllMonkeysByName("Golden Lion Tamarin");
                foreach (var monkey in monkeysByNameArray)
                {
                    Console.WriteLine(monkey.Name);
                }

                // 11. יצירת מילון של קופים
                var monkeyDictionary = monkeys.CreateDictionaryFromMonkeyList();
                foreach (var kvp in monkeyDictionary)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}");
                }

                // 12. בדיקה אם קוף קיים לפי שם (שימוש במילון)
                bool doesMonkeyExist = monkeys.MonkeExistByName("Mandrill");
                Console.WriteLine(doesMonkeyExist);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("TBD");
            }
			#endregion
		}
        public static int maxBy(List<Student> students, Func <Student, int> param)
        {
            int max = -1;

            foreach (var student in students)
            {
                int num = param(student);
                if (max < param(student))
                    max = param(student);
            }
            return max;
            if (students[0].grade == param(students[0]))
               return students.Max((student) => student.grade);

            return students.Max((student) => student.Age);

        }
	}
}

