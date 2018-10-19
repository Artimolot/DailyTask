using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks
{
	public delegate void TaskHandler(string message);

	class Task
	{
		public event TaskHandler failOperation;
		public event TaskHandler completeOperation;

		public Dictionary<int, string> taskList { get; private set; }
		
		public Task()
		{
			taskList = new Dictionary<int, string>();
		}

		public void AddTask(int time, string nameTask)
		{
			if (taskList.Contains(new KeyValuePair<int, string>(time, nameTask)))
			{
				failOperation($"На {time}:00, уже есть задание");
			}
			else
			{
				completeOperation($"Задание добавлено на: {time}:00");
				taskList.Add(time, nameTask);
			}
		}

		public void DeleteTask(int time, string nameTask)
		{
			if (taskList.Contains(new KeyValuePair<int, string>(time, nameTask)))
			{
				completeOperation($"Задание на {time}:00, удалено");
				taskList.Remove(time);
			}
			else
			{
				failOperation("Невозможно удалить задание, на такое время нет задания");
			}
		}

		public void ShowListTask()
		{
			if(taskList.Keys.Count != 0)
			{
				foreach (KeyValuePair<int, string> list in taskList)
				{
					Console.WriteLine($"{list.Key}:00 - {list.Value}");
				}
			}
			else
			{
				Console.WriteLine("Пуст!");
			}
		}
	}
}
