using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 2.(Создать студента из вашей группы (фамилия, имя, год рождения, с каким экзаменом поступил, баллы). Создать словарь для студентов из вашей группы)");
            string filePath = "student.txt";
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            ReadStudentsFromFile(filePath, students);
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("a. Новый студент");
                Console.WriteLine("b. Удалить");
                Console.WriteLine("c. Сортировать");
                Console.WriteLine("q. Выход");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();
                if (choice == "a")
                {
                    Console.Write("Введите фамилию(после нажмите enter): ");
                    string lastName = Console.ReadLine();
                    Console.Write("Введите имя(после нажмите enter): ");
                    string firstName = Console.ReadLine();
                    Console.Write("Введите год рождения(после нажмите enter): ");
                    int birthYear = int.Parse(Console.ReadLine());
                    Console.Write("Введите экзамен, на котором поступил студент(после нажмите enter): ");
                    string exam = Console.ReadLine();
                    Console.Write("Введите баллы(после нажмите enter): ");
                    int score = int.Parse(Console.ReadLine());
                    Student newStudent = new Student(lastName, firstName, birthYear, exam, score);
                    students.Add(newStudent.FullName, newStudent);
                    Console.WriteLine("Студент успешно добавлен.");
                    Console.WriteLine();
                }
                else if (choice == "b")
                {
                    Console.Write("Введите фамилию студента, которого хотите удалить(после нажмите enter): ");
                    string lastName = Console.ReadLine();
                    Console.Write("Введите имя студента, которого хотите удалить(после нажмите enter): ");
                    string firstName = Console.ReadLine();
                    string fullName = lastName + " " + firstName;
                    if (students.ContainsKey(fullName))
                    {
                        students.Remove(fullName);
                        Console.WriteLine("Студент успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine("Студент не найден.");
                    }
                    Console.WriteLine();
                }
                else if (choice == "c")
                {
                    List<Student> sortedStudents = SortStudentsByScore(students);
                    Console.WriteLine("Студенты, отсортированные по баллам (по возрастанию):");
                    foreach (Student student in sortedStudents)
                    {
                        Console.WriteLine(student.FullName + " - " + student.Score);
                    }
                    Console.WriteLine();
                }
                else if (choice == "q")
                {
                    SaveStudentsToFile(filePath, students);
                    break;
                }
            }
        }
        static void ReadStudentsFromFile(string filePath, Dictionary<string, Student> students)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        string lastName = parts[0];
                        string firstName = parts[1];
                        int birthYear = int.Parse(parts[2]);
                        string exam = parts[3];
                        int score = int.Parse(parts[4]);

                        Student student = new Student(lastName, firstName, birthYear, exam, score);
                        students.Add(student.FullName, student);
                    }
                }
            }
        }
        static void SaveStudentsToFile(string filePath, Dictionary<string, Student> students)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Student student in students.Values)
                {
                    writer.WriteLine(student.LastName + "," + student.FirstName + "," + student.BirthYear + "," + student.Exam + "," + student.Score);
                }
            }
        }
        static List<Student> SortStudentsByScore(Dictionary<string, Student> students)
        {
            List<Student> sortedStudents = new List<Student>(students.Values);
            sortedStudents.Sort((x, y) => x.Score.CompareTo(y.Score));

            return sortedStudents;
        }
    }
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int BirthYear { get; set; }
        public string Exam { get; set; }
        public int Score { get; set; }

        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }
        public Student(string lastName, string firstName, int birthYear, string exam, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthYear = birthYear;
            Exam = exam;
            Score = score;
        }
    }
}
