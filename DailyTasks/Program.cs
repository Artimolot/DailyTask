using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks
{
	class Program
	{
		static void Main(string[] args)
		{
			Task task = new Task();

			task.completeOperation += Show_Message;
			task.failOperation += Show_Message;

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Дневные задания"));
			Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

			do
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Список команд:");
				Console.WriteLine("add - добавить задание");
				Console.WriteLine("remove - удалить задание");
				Console.WriteLine("list - показать список заданий");
				Console.WriteLine();

				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write("Введите желаемую команду: ");
				string command = Console.ReadLine();

				switch (command)
				{
					case "add":
						Console.WriteLine("Добавление задания");
						Console.Write("Введите время задания: ");
						int timeAdd = Convert.ToInt32(Console.ReadLine());
						Console.Write("Введите название задания: ");
						string nameTask = Console.ReadLine();
						task.AddTask(timeAdd, nameTask);
						Console.WriteLine();
						break;
					case "remove":
						Console.WriteLine("Удаление задания");
						Console.WriteLine("Введите время задания которое хотите удалить: ");
						int timeRemove = Convert.ToInt32(Console.ReadLine());
						task.DeleteTask(timeRemove);
						Console.WriteLine();
						break;
					case "list":
						Console.WriteLine("Список заданий:");
						task.ShowListTask();
						Console.WriteLine();
						break;
					default:
						Console.WriteLine("Такой команды нет");
						Console.WriteLine();
						break;
				}
			}
			while (true);
		}

		private static void Show_Message(string message)
		{
			Console.WriteLine(message);
		}
	}
}
