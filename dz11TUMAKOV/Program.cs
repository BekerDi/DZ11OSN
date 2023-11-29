using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace dz11TUMAKOV
{
    internal class Program
    {
        static List<Student> ReadStudentsFromFile(string studentFilePath, string wishesFilePath)
        {
            var students = new List<Student>();
            try
            {
                var lines = File.ReadAllLines(studentFilePath);



                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length != 2) continue; // Пропустить строки с неверным форматом

                    students.Add(new Student(parts[0].Trim(), parts[1].Trim()));
                }
            }
            catch (Exception ex) { Console.WriteLine("Ошибка при чтении файла"); }

            // Отключаем загрузку пожеланий, если файла пожеланий не существует
            if (File.Exists(wishesFilePath))
            {
                var wishLines = File.ReadAllLines(wishesFilePath);
                foreach (var line in wishLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length != 2) continue; // Пропустить строки с неверным форматом

                    var studentName = parts[0].Trim();
                    var eventName = parts[1].Trim();

                    var student = students.FirstOrDefault(s => s.Name == studentName);
                    student?.AddWish(eventName);
                }
            }

            return students;
        }

        static void Main(string[] args)
        {
            // Указываем путь к файлам со студентами и пожеланиями
            var allStudents = ReadStudentsFromFile("../../StudentsList.txt", "C:../../wishes.txt");
            var groups = allStudents.GroupBy(s => s.Group).Select(g => g.Key).ToList();

            Console.WriteLine("Введите название события:");
            var eventName = Console.ReadLine();

            Console.WriteLine("Введите дату события (формат: dd.MM.yyyy):");
            var eventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество участников с каждой группы:");
            var participantsPerGroup = int.Parse(Console.ReadLine());

            Event eventObj = new Event(eventName, eventDate);

            foreach (var group in groups)
            {
                var wishingStudents = allStudents
                    .Where(s => s.Group == group && s.Wishes.Contains(eventName))
                    .ToList();

                var studentsInGroup = allStudents.Where(s => s.Group == group).ToList();
                Random random = new Random();

                // Если количество желающих меньше необходимых, тогда дополняем случайными участниками
                var participants = wishingStudents
                    .Concat(studentsInGroup.Except(wishingStudents).OrderBy(s => random.Next()))
                    .Take(participantsPerGroup)
                    .ToList();

                foreach (var student in participants)
                {
                    eventObj.AddParticipant(student);
                }
            }

            // Записываем информацию о мероприятии и его участниках в файл
            string eventFileName = "../../Events.txt";
            using (var writer = new StreamWriter(eventFileName, true)) // false чтобы перезаписывать файл если он существует
            {
                writer.WriteLine($"Событие: {eventName}, Дата: {eventDate:дд.мм.гггг}");
                foreach (var kvp in eventObj.PatrticipantsByGroup)
                {
                    writer.WriteLine($"Группа: {kvp.Key}");
                    foreach (var student in kvp.Value)
                    {
                        writer.WriteLine($"  {student.Name}");
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine($"Информация о предстоящем событии сохраняется в Events.txt");

            //Person и их увлечения 
            List<Person> people = new List<Person>()
        {
            new Person("Анна", "концерт"),
            new Person("Игорь", "выход новой серии"),
            new Person("Ольга", "математика"),
        };

            Console.WriteLine("Введите событие:");
            string событие = Console.ReadLine();

            // Проверяем, какие люди заинтересованы в данном событии
            foreach (Person person in people)
            {
                if (person.CheckHobby(событие))
                {
                    Console.WriteLine($"{person.Name} заинтересован(а) в событии '{событие}'.");
                    Console.WriteLine($"Реакция {person.Name} на событие: {person.GetReaction()}");
                }
            }
        
        Console.ReadKey();
        }
    }
}
    


