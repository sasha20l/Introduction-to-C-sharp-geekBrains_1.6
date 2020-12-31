using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekBrains_1._6
{
    class Program
    {   
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            ViewProcesses(processes);
            while (true)
            {
                processes = Process.GetProcesses();
                Console.WriteLine($"0 - Показать процессы 1 - Убить по ID 2 - Убить по имени 3 - Не трогать 4 - Exit");
                KillProcesses(processes, Choice(0, 4, "Введите корректное значение (0 - 4)"));
            }

        }

        static int Choice(int minChoice, int maxChoice, string text)
        {
            int nums;
            while (true)
            {
                try
                {
                    nums = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine($"Введите одно числовое значение!(от {minChoice} до {maxChoice})");
                    continue;
                }
                if (nums > (minChoice - 1) || nums < (maxChoice + 1)) break;
                else Console.WriteLine($"{text}");
            }
            return nums;
        }
        static void ViewProcesses(Process[] processes)
        {
            Console.WriteLine("Список Ваших процессов");
            foreach (Process proc in processes)
            {
                Console.WriteLine($"ID - {proc.Id}. Имя - {proc.ProcessName}");
            }
        }
        static void KillProcesses(Process[] processes, int choice)
        {
            string nameIdProcesses;

            Console.WriteLine(choice == 1? "Введите ID процесса.": choice == 2 ? "Введите Имя процесса.":"Нажмите любую кнопку");
            nameIdProcesses = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case 0:
                        {
                            ViewProcesses(processes);
                            break;
                        }
                    case 1:
                        foreach (Process proc in processes)
                        {
                            if (proc.Id == int.Parse(nameIdProcesses))
                            {
                                proc.Kill();
                                Console.WriteLine($"Процесс - {proc.ProcessName} Убит.");
                                return;
                            }
                            
                        }
                        Console.WriteLine($"Процесса с таким ID нету.");
                        break;
                    case 2:
                        foreach (Process proc in processes)
                        {
                            if (proc.ProcessName == nameIdProcesses)
                            {
                                proc.Kill();
                                Console.WriteLine($"Процесс - {proc.ProcessName} Убит.");
                                return;
                            }
                            
                        }
                        Console.WriteLine($"Процесса с таким Именем нету.");
                        break;
                    case 3:
                        foreach (Process proc in processes)
                        {
                            proc.Kill();
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Что-то пошло не так - {ex}. Введите данные корректно");
            }

        }
    }
}
