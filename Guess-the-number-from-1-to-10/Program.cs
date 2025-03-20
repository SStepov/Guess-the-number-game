using System;

namespace Guess_the_number_from_1_to_10
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true; // Для того, чтобы игра все время крутилась, в случае какой-то ошибки начиналась заново
            Console.WriteLine("Добро пожаловать в Угадай число от 1 до 10!\n\n");

            while (isWork)
            {
                Console.WriteLine("Доступные команды:\n" +
                                  "Да - Запустить игру\n" +
                                  "Нет - Не запускать игру/выйти.");

                Console.Write("Сыграем? ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "да":
                        {
                            Console.Clear();
                            bool isOpen = true; // Для повторения уже самой игры внутри case "да"
                            bool isOpenMenu = true; // Для того чтобы после угадывания числа можно было вернуться в меню в случае неправильного ввода

                            while (isOpen)
                            {
                                int PlayerValue;
                                Random rand = new Random();
                                int value = rand.Next(1, 11);
                                Console.WriteLine("Генератор загадал число от 1 до 10!");
                                Console.Write("Введите это число: ");
                                PlayerValue = Convert.ToInt32(Console.ReadLine());

                                while (PlayerValue != value)
                                {
                                    if (PlayerValue > value)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Вы ввели {PlayerValue}");
                                        Console.WriteLine("Возьмите число меньше.");
                                    }
                                    else if (PlayerValue < value)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Вы ввели {PlayerValue}");
                                        Console.WriteLine("Возьмите число больше.");
                                    }

                                    Console.Write("Введите это число: ");
                                    PlayerValue = Convert.ToInt32(Console.ReadLine());
                                }

                                if (PlayerValue == value)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Вы отгадали число!");
                                    Console.ResetColor();
                                    Console.WriteLine($"Генератором загаданное число было {value}");

                                    while (isOpenMenu)
                                    {
                                        Console.WriteLine("Доступные команды:\n" +
                                                          "Да - вернуться в меню.\n" +
                                                          "Нет - выйти из игры.");
                                        Console.Write("Вернемся в меню? ");
                                        string menuInput = Console.ReadLine().ToLower();

                                        switch (menuInput)
                                        {
                                            case "да":
                                                {
                                                    Console.Clear();
                                                    isOpenMenu = false;
                                                    isOpen = false;
                                                }
                                                break;
                                            case "нет":
                                                {
                                                    ExitGame();
                                                    isWork = false; // Прекращает цикл, в котором находится
                                                    isOpenMenu = false;
                                                    isOpen = false;
                                                }
                                                break;
                                            default:
                                                {
                                                    WriteError("Я вас не понимаю, перепроверьте ваш ввод.");
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "нет":
                        {
                            ExitGame();
                            isWork = false; // Прекращает цикл, в котором находится
                        }
                        break;
                    default:
                        {
                            WriteError("Я вас не понял, проверьте ваш ввод.\n" +
                                      "Для того чтобы вернуться в начало, нажмите любую клавишу.");
                        }
                        break;
                }
            }
        }

        static void WriteError(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        static void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Рады были вас видеть!\nНадеюсь, вы к нам еще зайдете!");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Нажмите любую клавишу для выхода.");
            Console.ResetColor();
        }
    }
}