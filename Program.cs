using System;

public class WrongLoginException : Exception
{
    public WrongLoginException()
    {
    }

    public WrongLoginException(string message) : base(message)
    {
    }
}

public class WrongPasswordException : Exception
{
    public WrongPasswordException()
    {
    }

    public WrongPasswordException(string message) : base(message)
    {
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string login = "";

            while (true)
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();

                try
                {
                    ValidateLogin(login);
                    break; // Выход из цикла, если логин корректный
                }
                catch (WrongLoginException ex)
                {
                    Console.WriteLine("Ошибка валидации логина: " + ex.Message);
                }
            }

            string password = "";
            bool validPassword = false;

            while (!validPassword)
            {
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                try
                {
                    ValidatePassword(password);
                    validPassword = true; // Пароль корректный, выход из цикла
                }
                catch (WrongPasswordException ex)
                {
                    Console.WriteLine("Ошибка валидации пароля: " + ex.Message);
                }
            }

            string confirmPassword;

            do
            {
                Console.Write("Подтвердите пароль: ");
                confirmPassword = Console.ReadLine();

                if (password != confirmPassword)
                {
                    Console.WriteLine("Пароли не совпадают.");
                }
            } while (password != confirmPassword);

            Console.WriteLine("Регистрация прошла успешно.");
            Console.ReadLine();
        }

        static void ValidateLogin(string login)
        {
            if (login.Length >= 20 || !System.Text.RegularExpressions.Regex.IsMatch(login, "^[a-zA-Z0-9_]+$"))
            {
                throw new WrongLoginException("Неверный формат логина");
            }
        }

        static void ValidatePassword(string password)
        {
            if (password.Length >= 20 || !System.Text.RegularExpressions.Regex.IsMatch(password, "^[a-zA-Z0-9_]+$"))
            {
                throw new WrongPasswordException("Неверный формат пароля");
            }
        }
    }
}
