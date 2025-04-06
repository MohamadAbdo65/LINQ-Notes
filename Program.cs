using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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

        public Sale(int id, DateTime date, int amount)
        {
            this.SaleID = id;
            this.SaleDate = date;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return $"{SaleID} - {SaleDate.ToShortDateString()} - {Amount}";
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
            (this IEnumerable<Employee> source, Func<Employee, bool> condition)
        {
            foreach (Employee e in source)
            {
                if (condition(e))
                {
                    yield return e;
                }
            }
        }

        public static void Print(this IEnumerable<Employee> sourse, string Message)
        {
            Console.WriteLine($"\t {Message}");
            Console.WriteLine("---------------------------------------");
            foreach (Employee e in sourse)
            {
                Console.WriteLine(e.Id + "  " + e.FirstName + "  " + e.LastName + "  " + e.Salary + "  " + e.Age);
            }
        }

    }

    public static class ExtentionsSales
    {
        public static void Print(this IEnumerable<Sale> sourse, string Message)
        {
            Console.WriteLine($"\t {Message}");
            Console.WriteLine("---------------------------------------");
            foreach (Sale e in sourse)
            {
                Console.WriteLine(e.SaleID + "  " + e.SaleDate.ToString() + "  " + e.Amount);
            }
        }

        public static void PrintTotalSales(this IEnumerable<Sale> sourse, string Message)
        {
            Console.WriteLine(Message + " : " + sourse.Sum(s => s.Amount));
        }
    }


    //*-**-*

    public class clsPerson
    {

    }

    public class clsEmployee : clsPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        public clsEmployee(int id, string name, int salary, string department)
        {
            this.ID = id;
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Name} - {this.Salary} - {this.Department}";
        }

    }

    public static class DataBase2
    {
        public static IEnumerable<clsEmployee> AllEmployees = new List<clsEmployee>
        {
             new clsEmployee(1, "Ahmed", 10000, "HR"),
             new clsEmployee(2, "Ali", 12000, "IT"),
             new clsEmployee(3, "Sara", 15000, "Finance"),
             new clsEmployee(4, "Mohamed", 11000, "Marketing"),
             new clsEmployee(5, "Fatima", 13000, "Sales"),
             new clsEmployee(6, "Hassan", 14000, "HR"),
             new clsEmployee(7, "Khalid", 12500, "IT"),
             new clsEmployee(8, "Nour", 13500, "Finance"),
             new clsEmployee(9, "Omar", 14500, "Marketing"),
             new clsEmployee(10, "Layla", 15500, "Sales"),
             new clsEmployee(11, "Youssef", 11500, "HR"),
             new clsEmployee(12, "Mariam", 10500, "IT"),
             new clsEmployee(13, "Tariq", 16500, "Finance"),
             new clsEmployee(14, "Zainab", 17500, "Marketing"),
             new clsEmployee(15, "Huda", 18500, "Sales"),
             new clsEmployee(16, "Walid", 19500, "HR"),
             new clsEmployee(17, "Ayman", 20500, "IT"),
             new clsEmployee(18, "Rania", 21500, "Finance"),
             new clsEmployee(19, "Samir", 22500, "Marketing"),
             new clsEmployee(20, "Hisham", 23500, "Sales"),
             new clsEmployee(21, "Kareem", 24500, "HR"),
             new clsEmployee(22, "Sami", 25500, "IT"),
             new clsEmployee(23, "Lina", 26500, "Finance"),
             new clsEmployee(24, "Salma", 27500, "Marketing"),
             new clsEmployee(25, "Mustafa", 28500, "Sales"),
             new clsEmployee(26, "Nadia", 29500, "HR"),
             new clsEmployee(27, "Bilal", 30500, "IT"),
             new clsEmployee(28, "Amal", 31500, "Finance"),
             new clsEmployee(29, "Hatem", 32500, "Marketing"),
             new clsEmployee(30, "Rami", 33500, "Sales"),
             new clsEmployee(31, "Dina", 34500, "HR"),
             new clsEmployee(32, "Ibrahim", 35500, "IT"),
             new clsEmployee(33, "Jamal", 36500, "Finance"),
             new clsEmployee(34, "Shadia", 37500, "Marketing"),
             new clsEmployee(35, "Wael", 38500, "Sales"),
             new clsEmployee(36, "Aisha", 39500, "HR"),
             new clsEmployee(37, "Ziad", 40500, "IT"),
             new clsEmployee(38, "Farida", 41500, "Finance"),
             new clsEmployee(39, "Hani", 42500, "Marketing"),
             new clsEmployee(40, "Othman", 43500, "Sales"),
             new clsEmployee(41, "Bassam", 44500, "HR"),
             new clsEmployee(42, "Reem", 45500, "IT"),
             new clsEmployee(43, "Karim", 46500, "Finance"),
             new clsEmployee(44, "Ghada", 47500, "Marketing"),
             new clsEmployee(45, "Tamer", 48500, "Sales"),
             new clsEmployee(46, "Noor", 49500, "HR"),
             new clsEmployee(47, "Yasmin", 50500, "IT"),
             new clsEmployee(48, "Omar", 51500, "Finance"),
             new clsEmployee(49, "Hussein", 52500, "Marketing"),
             new clsEmployee(50, "Fadi", 53500, "Sales"),
             new clsEmployee(51, "Ibrahim", 33120, "Marketing"),
             new clsEmployee(52, "Nader", 25000, "HR"),
             new clsEmployee(53, "Rezk", 41200, "IT"),
             new clsEmployee(54, "Ramadan", 47000, "Finance"),
             new clsEmployee(55, "Reda", 66000, "Marketing")

        };

        public static void PrintEmployees(this IEnumerable<clsEmployee> source, string? Title = null)
        {
            if (Title != null)
                Console.WriteLine($"# {Title} #");

            foreach (clsEmployee e in source)
            {
                Console.WriteLine(e.ToString());
            }
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

        static void EqualityOperations()
        {
            // 1) SequenceEqual()

            List<int> Numbers1 = new List<int> { 1, 2, 3, 4 };
            List<int> Numbers2 = new List<int> { 1, 2, 3, 4 };

            var Result = Numbers1.SequenceEqual(Numbers2);

            // For the result to be correct, the two lists must have
            // the same number of elements and each element must be equal
            // to the other element.

            Console.WriteLine("Are the List1 and the List2 equal ? " + Result);

        }

        static void Concatenation()
        {
            // Concatenation 
            // it is the result of merging two Lists

            var emps1 = DataBase.GetAllEmployees().Where(e => e.Salary > 7000);
            var emps2 = DataBase.GetAllEmployees().Where(e => e.Salary < 5000);

            var emps3 = emps1.Concat(emps2);

            emps3.Print("Emps1 + Emps2");

            Console.WriteLine("\n");

            // you can merge specific elements

            var emps4 = emps1.Select(e => e.Salary).Concat(emps2.Select(e => e.Salary));

            foreach (var e in emps4)
                Console.WriteLine(e);

            // other method to merge elements

            var emps5 = new[] { emps1, emps2 }.SelectMany(e => e);

            emps5.Print("\n");

        }

        static void AggregateOperations()
        {
            // Aggregate operations are used to perform computations on collections of data,
            // such as sum, average, count, max, and min

            // 1) Strings Aggregation

            var Names = new[] { "Ahmed", "Ali", "Mohamad", "Moaaz", "Khaled" };

            var Result = Names.Aggregate((a, b) => $"{a} - {b}");

            Console.WriteLine("Result : " + Result);


            // 2) Numbers Aggregation

            List<double> Numbers = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            double TaxAmount = 1.14;

            var Total = Numbers.Aggregate(0.0, (a, b) => a + (b * TaxAmount));

            Console.WriteLine("Total : " + Total);

            // 3) Get Greatest Value

            var Emps = DataBase.GetAllEmployees();

            var GreatestSalary = Emps.First();

            GreatestSalary = Emps.Aggregate
            (
                GreatestSalary,
                (greatest, next) => greatest.Salary < next.Salary ? next : greatest,
                x => x
            );

            Console.WriteLine(GreatestSalary.ToString());

            // So you can customize the method as you want,
            // as in the three previous methods.

            // *-*-*-*-*-*


            // There are Standard methods

            var AllSales = DataBase.GetAllSales();

            // 1) Count 

            Console.WriteLine($"Total sales : {AllSales.Count()}");

            Console.WriteLine($"Total sales in and after 2019 : " +
                $"{AllSales.Count(s => s.SaleDate.Year >= 2019)}");

            Console.WriteLine($"Total sales in and after 2019 : " +
                $"{AllSales.Where(s => s.SaleDate.Year >= 2019).Count()}");

            // if the result greater than "int" data type 
            // there is LongCount() method !

            // 2) Max - Min

            Console.WriteLine($"Max sale : {AllSales.Max(s => s.Amount)}");

            Console.WriteLine($"Max sale in 2016 : " +
                $"{AllSales.Where(s => s.SaleDate.Year == 2016).Max(s => s.Amount)}");

            // to get more details about max value you can use MaxBy()

            Console.WriteLine($"Max sale : {AllSales.MaxBy(s => s.Amount)}");

            Console.WriteLine($"Max sale in 2016 : " +
                $"{AllSales.Where(s => s.SaleDate.Year == 2016).MaxBy(s => s.Amount)}");


            // 3) Sum 

            Console.WriteLine($"Sum sales : {AllSales.Sum(s => s.Amount)}$");

            Console.WriteLine($"Sum sales in 2016 :" +
                $" {AllSales.Where(s => s.SaleDate.Year == 2016).Sum(s => s.Amount)}$");


            // 4) Average

            Console.WriteLine($"Average sales : {(float)AllSales.Average(s => s.Amount)}");

            Console.WriteLine($"Average sales in 2016 : " +
                $"{(float)AllSales.Where(s => s.SaleDate.Year == 2016).Average(s => s.Amount)}");


        }

        static void SetsOperations()
        {
            // some data
            var EmpsWithSalaryGreaterThan25k = DataBase2.AllEmployees.Where(e => e.Salary >= 25000);

            // some data also 
            var EmpsWithDepartmentHR = DataBase2.AllEmployees.Where(e => e.Department == "HR");

            // concat these data 
            var Emps = EmpsWithSalaryGreaterThan25k.Concat(EmpsWithDepartmentHR);


            // # 1) Distinct #


            // to remove the repeated data you have 2 methods

            // 1) Distinct() - by this method you can remove the repeated data 
            // like (12 & 12)
            // but if there class and there many properties
            // you should use the next method 


            // 2) DistinctBy()

            // if we try to print our data 
            Emps.PrintEmployees();
            // we well find repeated Employees !

            var EmpsWithoutRepeated = Emps.DistinctBy(e => e.ID);
            // by this method we removed the repeated employees By ID :)

            // let's try to print them 

            EmpsWithoutRepeated.OrderBy(e => e.ID).ToList();
            EmpsWithoutRepeated.PrintEmployees();


            /* # 2) Except # */
            Console.WriteLine("\n\n");

            // The Except method in C# is used to return the difference
            // between two collections, removing elements from the first
            // collection that also exist in the second collection.

            var emps1 = EmpsWithSalaryGreaterThan25k.
                ExceptBy(EmpsWithDepartmentHR.Select(e => e.ID), e => e.ID);

            emps1.PrintEmployees();


            /* # 3) Intersect # */
            Console.WriteLine("\n\n");

            // The Intersect method in C# is used to return the same elements
            // between two collections, removing elements from the first
            // collection that also exist in the second collection.

            var emps2 = EmpsWithSalaryGreaterThan25k.
               IntersectBy(EmpsWithDepartmentHR.Select(e => e.ID), e => e.ID);

            emps2.PrintEmployees();


            /* # 4) Union # */
            Console.WriteLine("\n\n");

            var Emps10 = DataBase2.AllEmployees.Where(e => e.Salary <= 20000);
            var Emps11 = DataBase2.AllEmployees.Where(e => e.Salary <= 15000);

            var Emps10And11 = Emps10.Union(Emps11);

            Emps10And11.PrintEmployees();


            // Summary : 
            // Union → Combines two collections, removing duplicates.
            // Except → Returns elements from the first collection that are not in the second.
            // Distinct → Removes duplicate values from a collection.
            // Intersect → Returns common elements between two collections.


        }

        static void ExpressionTrees()
        {
            // Func 
            Func<int, bool> IsEven = num => num % 2 == 0;
            Console.WriteLine(IsEven(5));
            Console.WriteLine(IsEven.Invoke(5));

            // Expression
            Expression<Func<int, bool>> IsEvenExpression = num => num % 2 == 0;
            Func<int, bool> IsEvenV2 = IsEvenExpression.Compile();
            Console.WriteLine(IsEvenV2(5));

            // Parse Expression
            Expression<Func<int, bool>> IsNegative = num => num < 0;

            ParameterExpression parameter = IsNegative.Parameters[0];
            BinaryExpression operation = (BinaryExpression)IsNegative.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;


            Console.WriteLine
                ($"{parameter.Name} => {left.Name} {operation.NodeType} {right.Value}");


            // Create Expression  
            // dynamic method !! 


            // is the number integer ? 
            // (num) => num % 1 == 0  

            ParameterExpression numPar = Expression.Parameter(typeof(double), "num");

            ConstantExpression oneNum = Expression.Constant(1.0, typeof(double));
            ConstantExpression zeroNum = Expression.Constant(0.0, typeof(double));

            BinaryExpression ModuloBinary = Expression.Modulo(numPar, oneNum);
            BinaryExpression equalBinary = Expression.Equal(ModuloBinary, zeroNum);

            Expression<Func<double, bool>> IsIntegerExpression = Expression.Lambda
                <Func<double, bool>>(equalBinary, new ParameterExpression[] { numPar });

            var IsInteger = IsIntegerExpression.Compile();
            Console.WriteLine(IsInteger(2.23));
            Console.WriteLine(IsInteger(5));
        }

        static void IEnumerableVSIQueryable()
        {
            // IEnumerable<T> works in memory and is used for iterating over
            // collections like List < T > and Array.

            // IEnumerable < T > uses Func<T, TResult>, meaning filtering happens
            // in the application, not in the database.


            // IQueryable < T > works with databases and allows query translation
            // into SQL for execution on the server.

            // IQueryable < T > uses Expression<Func<T, TResult>>, allowing
            // queries to be analyzed and optimized before execution.
        }

        static void ConvertingDataTypes()
        {
            IEnumerable<clsEmployee> AllEmps = DataBase2.AllEmployees;

            // Executes the query in memory after retrieving data from the source (e.g., database).
            var AsEnumerable = DataBase2.AllEmployees.AsEnumerable();

            // Allows query execution at the source (e.g., SQL Server) before fetching data.
            var AsQueryable = DataBase2.AllEmployees.AsQueryable();

            // Converts all elements to the specified type but throws an exception if conversion is not possible.
            var CastMethod = DataBase2.AllEmployees.Cast<clsPerson>();

            // Filters elements that match the specified type and ignores others.
            var OfTypeMethod = DataBase2.AllEmployees.OfType<clsEmployee>();

            // Converts the data into an array, loading all elements into memory.
            var ToArrayMethod = DataBase2.AllEmployees.ToArray();

            // Converts the data into a list, loading all elements into memory.
            var ToListMethod = DataBase2.AllEmployees.ToList();

            // Converts the data into a dictionary using a unique key for each element.
            Dictionary<int, clsEmployee> EmpsAsDictionary = DataBase2
                .AllEmployees.ToDictionary(e => e.ID);

        }

        public static IEnumerable<Tsourse> Paginate<Tsourse>
            (this IEnumerable<Tsourse> sourses, int? Page, int? PageSize)
        {
            if (sourses == null)
                throw new ArgumentNullException($"{nameof(sourses)}");

            if (!Page.HasValue)
                Page = 1;

            if (!PageSize.HasValue)
                PageSize = 10;

            if (!sourses.Any())
                return Enumerable.Empty<Tsourse>();

            return sourses.Skip((Page.Value - 1) * PageSize.Value).Take(PageSize.Value);
        }

        static void CustomLINQExtensionMethod()
        {
            var AllEmps = DataBase2.AllEmployees;

            var Page1 = AllEmps.Paginate(1, 15);
            Page1.PrintEmployees("Page 1 [15 Emps]");

            Console.WriteLine("\n\n");

            var Page2 = AllEmps.Paginate(2, 15);
            Page2.PrintEmployees("Page 2 [15 Emps]");

            Console.WriteLine("\n\n");

            var Page3 = AllEmps.Paginate(3, 15);
            Page3.PrintEmployees("Page 3 [15 Emps]");

            Console.WriteLine("\n\n");

            var Page4 = AllEmps.Paginate(4, 15);
            Page4.PrintEmployees("Page 4 [10 Emps]");

        }


    }
}
