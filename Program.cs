using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace LINQ
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }

        public readonly static Employee Default = new Employee
        {
            Id = 0,
            FirstName = "NULL",
            LastName = "NULL",
            Salary = 0,
            Age = 0
        };           

        private Employee()
        {

        }

        public Employee(int id, string fName, string lName, int salary, int age)
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Salary = salary;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.FirstName} - {this.LastName} - {this.Salary} - {this.Age}";
        }

    }
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{FullName} - {Salary}$";
        }
    }

    public class Sale
    {
        public int SaleID { get; set; } 
        public DateTime SaleDate { get; set; }
        public int Amount { get; set; }
        
        public Sale(int id , DateTime date , int amount)
        {
            this.SaleID = id;
            this.SaleDate = date;
            this.Amount = amount;
        }
    
    }


    public static class DataBase
    {
        public static IEnumerable<Employee> GetAllEmployees()
            {
                return new List<Employee>()
                {
                    new Employee(1, "Ali", "Ahmed", 5000, 30),
                    new Employee(2, "Omar", "Khalid", 6000, 28),
                    new Employee(3, "Hassan", "Mohamed", 5500, 35),
                    new Employee(4, "Sami", "Yousef", 4800, 32),
                    new Employee(5, "Nasser", "Fahad", 7000, 40),
                    new Employee(6, "Khalid", "Salem", 7500, 45),
                    new Employee(7, "Faisal", "Mubarak", 5200, 29),
                    new Employee(8, "Yousef", "Hadi", 6300, 38),
                    new Employee(9, "Majed", "Saad", 5900, 31),
                    new Employee(10, "Rami", "Ibrahim", 6700, 36),
                    new Employee(11, "Sultan", "Talal", 5600, 27),
                    new Employee(12, "Tariq", "Mahmoud", 7400, 42),
                    new Employee(13, "Bader", "Jassim", 5100, 33),
                    new Employee(14, "Saleh", "Abdulaziz", 5300, 30),
                    new Employee(15, "Hadi", "Rashid", 6200, 37),
                    new Employee(16, "Mansour", "Hassan", 6800, 41),
                    new Employee(17, "Jamal", "Saeed", 5700, 34),
                    new Employee(18, "Adel", "Osama", 4900, 26),
                    new Employee(19, "Ibrahim", "Farhan", 7100, 39),
                    new Employee(20, "Saif", "Othman", 5400, 28)
                };
            }

        public static IEnumerable<Sale> GetAllSales()
        {
            return new List<Sale>
            {
                new Sale(1 , new DateTime(2015,1,1) , 1000) ,
                new Sale(2 , new DateTime(2015,5,1) , 1255) ,
                new Sale(3 , new DateTime(2015,9,1) , 1200) ,
                new Sale(4 , new DateTime(2016,8,1) , 1020) ,
                new Sale(5 , new DateTime(2016,7,1) , 1800) ,
                new Sale(6 , new DateTime(2016,2,1) , 1600) ,
                new Sale(7 , new DateTime(2016,1,1) , 1130) ,
                new Sale(8 , new DateTime(2016,3,1) , 1200) ,
                new Sale(9 , new DateTime(2016,6,1) , 1030) ,
                new Sale(10, new DateTime(2016,4,1) , 1150) ,
                new Sale(11, new DateTime(2017,7,1) , 1745) ,
                new Sale(12, new DateTime(2017,4,1) , 1585) ,
                new Sale(13, new DateTime(2017,2,1) , 1855) ,
                new Sale(14, new DateTime(2018,3,1) , 1110) ,
                new Sale(15, new DateTime(2018,8,1) , 1440) ,
                new Sale(16, new DateTime(2018,7,1) , 1630) ,
                new Sale(17, new DateTime(2018,9,1) , 1025) ,
                new Sale(18, new DateTime(2019,2,1) , 1010) ,
                new Sale(19, new DateTime(2019,1,1) , 1005) ,
                new Sale(20, new DateTime(2020,1,1) , 1370) ,
                new Sale(21, new DateTime(2020,5,1) , 1850) ,
                new Sale(22, new DateTime(2020,1,1) , 1720) 
            };
        }

    }

    public static class ExtentionsEmployee
    {
        public static IEnumerable<Employee> Filter
            (this IEnumerable<Employee> source , Func<Employee , bool> condition)
        {
            foreach (Employee e in source)
            {
                if(condition(e))
                {
                    yield return e;
                }
            }
        }

        public static void Print (this IEnumerable<Employee> sourse , string Message)
        {
            Console.WriteLine($"\t {Message}");
            Console.WriteLine("---------------------------------------");
            foreach(Employee e in sourse)
            {
                Console.WriteLine(e.Id + "  " + e.FirstName + "  " + e.LastName + "  " + e.Salary + "  " + e.Age);
            }
        }

    }

    public static class ExtentionsSales
    {
        public static void Print (this IEnumerable<Sale> sourse , string Message)
        {
            Console.WriteLine($"\t {Message}");
            Console.WriteLine("---------------------------------------");
            foreach (Sale e in sourse)
            {
                Console.WriteLine(e.SaleID + "  " + e.SaleDate.ToString() + "  " + e.Amount);
            }
        }

        public static void PrintTotalSales(this IEnumerable<Sale> sourse , string Message)
        {
            Console.WriteLine(Message + " : " + sourse.Sum(s => s.Amount));
        }
    }

    public static class Program
    {
          
        static void Main(string[] args)
        {


            Console.ReadKey();
        }

        static void SimulationFunctionInLinq()
        {
            // Here i made similer function in Linq

            var list = DataBase.GetAllEmployees();

            var L = list.Filter(e => e.Salary >= 6000 && e.Age > 35);

            L.Print("Filter");

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }

        static void GenericAndNonGeneric()
        {
            // Linq don't support ArrayList becuase it's non-Generic
            // it uses IEnumerable
            var collection = new ArrayList();
            // collection.Where(); => There is error here !

            // But it support List becuase it's Generic
            // it uses IEnumerable<T>
            var MyList = new List<int>();
            MyList.Where(e => e == 1);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }

        static void MethodsToWriteQuery()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // How to Write query ?
            // you have 3 method to write query :

            // Extension Method : 
            var EvenNumbersMethod1 =
                Numbers.Where(e => e % 2 == 0);

            // Enumerable Method : 
            var EvenNumbersMethod2 =
                Enumerable.Where(Numbers, e => e % 2 == 0);

            // Query Method : 
            var EvenNumbersMethod3 =
                from n in Numbers
                where n % 2 == 0
                select n;

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }

        static void ImportantNote()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                        
            // Very important Note !

            // when you create query : 
            var EvenNumbers = Numbers.Where(e => e % 2 == 0);

            // then , you added new item or removed item 
            Numbers.Add(10);
            Numbers.Remove(4);
            // These changes will be considered
            // Becuase this query it's "Deferred Execution"
            // when you make enumeration , It will execute the query
            var result = EvenNumbers.ToList();
            // or 
            foreach (var n in EvenNumbers) { Console.Write($" {n} "); }

            // For more details , don't forget to ask AI . Good luck ^_^ !
            // 23:50 : 
            // https://www.youtube.com/watch?v=8jkN8XCj9Og&list=PL4n1Qos4Tb6Sj1Y4xJuJoWCuqleeG2yt6&index=4

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }

        static void Note1()
        {
            List<string> strings = new List<string> { "I", "Love", "C#" };

            // this line : 
            strings.Select(x => x);
            // and this line : 
            strings.Select(x => { return x; });
            // are same 

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }

        static void YouCanSelectDataBy3Method()
        {
            // 1) Select : 

            Console.WriteLine("\n");

            var AllEmployees = DataBase.GetAllEmployees();

            var Result = AllEmployees.Select(x =>
            {
                return new EmployeeDTO
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Salary = x.Salary
                };
            }).OrderByDescending(x => x.Salary);

            foreach (var r in Result) { Console.WriteLine(r.ToString()); }

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // 2) Select Many : 

            Console.WriteLine("\n");

            string[] ManyStrings = {
                "Hello my name is mohamad",
                "I am Back-end developer",
                "Good luck all ^_^"
            };

            var Words = ManyStrings.SelectMany(x => x.Split(' '));

            foreach (var w in Words) { Console.WriteLine(w.ToString()); }

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            // 3) Zip : 

            Console.WriteLine("\n");

            string[] ColorsName = { "Red", "Green", "Blue" };
            string[] ColorsRGB = { "255.0.0", "0.255.0", "0.0.255" };

            var Colors = ColorsName.Zip(ColorsRGB, (names, rgb) => $"{names} : {rgb}");

            foreach (var col in Colors) { Console.WriteLine(col); }

            Console.ReadKey();

        }

        static void SortingData()
        {
            // # Sorting Data #
            // Summary of this lesson : ("https://www.youtube.com/watch?v=5RtrL0qKju8&list=PL4n1Qos4Tb6Sj1Y4xJuJoWCuqleeG2yt6&index=6")

            // 1) you can sort data OrderBy ASC and DESC
            // 2) you can Order data by Primary order and Secondary order 
            //      for example : you ordered employees by salary , but if there repeated salary it will depend on secondary order
            // 3) you can make your own Comparer by user IComparer interface
        }

        static void PartitioningData()
        {
            // to partioning data , you have many method to do that 

            var emps = DataBase.GetAllEmployees(); // Get Data 


            // 1) Skip - in this method you ignore some data 


            // ignore first 5 elements
            var Q1 = emps.Skip(5);
            Q1.Print("Skipping First 5 elements");


            // keep ignoring while salary does not equal 5200
            var Q2 = emps.SkipWhile(e => e.Salary != 5200);
            Q2.Print("Skipping while salary not equal 5200");

            // ignore last 5 elements
            //var Q3 = Employees.SkipLast(10); 
            // but it is not working :( it looks not support on this version of Linq namespace



            // *-*-*



            // 2) Take - the Take method is reverse Skip method 


            // take first 5 elements
            var Q4 = emps.Take(5);
            Q1.Print("Skipping First 5 elements");


            // keep taking while salary does not equal 5200
            var Q5 = emps.TakeWhile(e => e.Salary != 5200);
            Q2.Print("Skipping while salary not equal 5200");

            // take last 5 elements
            //var Q6 = Employees.TakeLast(10); 
            // but it is not working :( it looks not support on this version of Linq namespace



            // *-*-*



            // 3) Chunk - convert data to many parts 

            // Must the version of project >= .Net 6

            //var chunks = Employees.Chunk().ToList();

            // for (int i = 0; i < chunks.Count; i++)
            //     chunks[i].Print($"Chunk {i + 1}");



            // ##** ---- **##



            // usege paginate function

            var page = 1;
            var size = 10;

            Console.WriteLine("result per page:");
            if (int.TryParse(Console.ReadLine(), out int resultPerPage))
            {
                size = resultPerPage;
            }
            Console.WriteLine("page No.:");
            if (int.TryParse(Console.ReadLine(), out int pageNo))
            {
                page = pageNo;
            }

            var Employees = DataBase.GetAllEmployees();

            var result = emps.Paginate(page, size);

            var resultCount = result.Count();

            var startRecord = ((page - 1) * size) + 1;

            var endRecord =
                 resultCount < size
                ? startRecord + resultCount - 1
                : size * (page - 1) + size;

            result.Print($"showing employees {startRecord} - {endRecord}");


        }

        // this method for paginate like google chroome : page : 1 , 2 , 3
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source,
        int page = 1, int size = 10) where T : class
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (size <= 0)
            {
                size = 10;
            }

            var total = source.Count();

            var pages = (int)Math.Ceiling((decimal)total / size);

            var result = source.Skip((page - 1) * size).Take(size);

            return result;
        }

        static void QuantifiersData()
        {
            // Quantifiers is method for knowlaged if element exist or no (True or False)

            var emps = DataBase.GetAllEmployees();

            // 1) Any() method 
            //    if you have array (1,2,3,4,5) it will visite all elements , that's mean the complexety = O(n)
            //    when it find the target element it returns true

            var Q1 = emps.Any(e => e.Salary < 0);
            Console.WriteLine($"Is there any employee with salary smaller than 0 ? : {Q1}");

            var Q2 = emps.Any(e => e.Salary > 7000);
            Console.WriteLine($"Is there any employee with salary greater than 7000 ? : {Q2}");


            // 2) All() method
            //      this method in LINQ checks whether all elements in a collection satisfy a specified condition,
            //      returning true if they do and false otherwise.
            //      the complexety = O(n)


            var Q3 = emps.All(e => e.Salary < 10_000);
            Console.WriteLine($"Is all employee with salary smaller than 10000 ? : {Q3}");


            // 3) Contain() method
            //      The Contains method checks whether a collection contains a specific element,
            //      returning true if the element exists and false otherwise.

            var Q4 = emps.Any(e => e.FirstName.Contains("M"));
            Console.WriteLine($"Is there employee with First name contain 'M' ? : {Q4}");



            //### Key Differences:
            //# Any() is used with a condition, while Contains() checks for a specific value.
            //# Any() can be used without a condition to check if a collection has elements, whereas Contains() always requires a specific value.
            //# Performance: Contains() is optimized for collections like HashSet<T>, whereas Any() might require iterating over all elements.

        }

        static void GroupingData()
        {

            // Grouping data 
            // for example : you have a log of your sales all the years and you want
            // to know how much you sale in every year
            // so the perfect practice is using GroupBy() method



            // 1) first method : GroupBy()


            // 1- Example 1 : Age : 

            var emps = DataBase.GetAllEmployees();

            var SortedEmps = emps.OrderBy(e => e.Age).ToList(); // sort by age ^_^

            var Groups = SortedEmps.GroupBy(e => e.Age);

            foreach (var group in Groups)
            {
                group.Print($"Employees with age {group.Key} : ");
                Console.WriteLine();
            }

            // *-*-*-*-

            // 2- Example 2 : Sales : 

            var sales = DataBase.GetAllSales();

            var SalesGroups = sales.GroupBy(s => s.SaleDate.Year);

            foreach (var group in SalesGroups)
            {
                group.Print($"Sales in {group.Key} : ");
                group.PrintTotalSales($"Total amount sales in {group.Key}");
                Console.WriteLine("\n");
            }


            // 2) second method : ToLookUp()


            var sales1 = DataBase.GetAllSales();

            var SalesGroups1 = sales.ToLookup(s => s.SaleDate.Year);

            foreach (var group in SalesGroups1)
            {
                group.Print($"Sales in {group.Key} : ");
                group.PrintTotalSales($"Total amount sales in {group.Key}");
                Console.WriteLine("\n");
            }



            // the diff between ToLookUp() and GroupBy() : 
            //  GroupBy executes lazily (Lazy Execution) and does not store results, while ToLookup executes
            //  immediately (Immediate Execution) and stores data like a Dictionary, making it faster for repeated
            //  access. Also, ToLookup does not throw an exception when accessing a missing key; it returns an empty
            //  collection instead.


        }

        static void GenerationOparetions()
        {
            // 1) Empty

            var Emps = new List<Employee>();
            // here you created a new list but it's empty so if you have
            // more than 1000 line of code and you didn't use it then you
            // are just wasting memory for nothing !! 

            // Isntead of that 
            // there is other method : 

            var Emp1 = Enumerable.Empty<Employee>();
            // here you just gave a "promise"
            // without wasting memory 

            // ....
            // 1000 line of code 

            foreach (Employee e in Emps)
            {   /** ... code  **/  }


            // 2) Default

            // in Data Types any data type has a default value 
            // for example : (int : 0) , (DateTime : 01:01:0001) , etc
            // so if you have an object you can gave it a default value 
            // by this way :

            var Emp5 = Enumerable.Empty<Employee>();

            var Emp6 = Emp5.DefaultIfEmpty();

            // you can specify the default value :
            var Emp7 = Emp5.DefaultIfEmpty(Employee.Default);


            // 3) Range 

            // if we to generate numbers from x to y
            // we usually using for loop and other methods 
            // but in linq there is method called Range(start , count)

            var numbers = Enumerable.Range(10, 20);

            foreach (var i in numbers) Console.Write(i + "  ");


            // 4) Repeat 

            var Car = "BMW 2019";
            var Cars = Enumerable.Repeat(Car, 5);

            var Element = "H2O";
            var Elements = Enumerable.Repeat(Element, 5);

            // by this method you Repeated the same element 
            // this method is used for making tests on the
            // same element such as in Chimestry or Mechanics

        }

        static void ElementOperations()
        {
            var emps = DataBase.GetAllEmployees();


            //1) ElementAt(n)

            var empAt5 = emps.ElementAt(5);
            Console.WriteLine(empAt5.ToString());

            // this method is good to get an element you want 
            // but there is a problem !
            // if you tried to get an element out of range it will gave you exception
            // so there is other method solved this problem : 

            //2) ElementAtOrDefault(n)

            var empAt500 = emps.ElementAtOrDefault(500);
            // if I tried to access an element out of range (Like : 500)
            // I will not get an exception ^_^

            if (empAt500 != null) Console.WriteLine(empAt500.ToString());

            // *-*-*-*

            //3) First()

            // by this method you can access to the first element in the Collection

            var FirstEmp = emps.First();
            Console.WriteLine(FirstEmp.ToString());

            // but if you want to get the first element It fulfills a certain condition
            // and this condition isn't met 
            // it will gave you an exception :(

            // so there is FirstOrDefault() method 

            //4) FirstOrDefault()

            var FirstEmpHasSalaryGreaterThan10K = emps.FirstOrDefault(e => e.Salary > 10000);

            // in the Data there is not any employee has Salary greater than 10k
            // so it will gave me null value 

            if (FirstEmpHasSalaryGreaterThan10K is null) Console.WriteLine("it is null :(");

            //5) Last()
            //6) LastOrDefault()
            // same as previous explanation


            //7) Single()
            //8) SingleOrDefault()

            //Single throws an InvalidOperationException if there is more
            //than one element or no elements at all.

            //SingleOrDefault throws an exception only if there is more than
            //one element, but it does not throw an exception if no elements exist;
            //instead, it returns the default value.


        }

    }  
}
