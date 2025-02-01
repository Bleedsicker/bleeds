
Console.WriteLine("Введите имя пользователя");
var userName = Console.ReadLine();
if (userName == "admin")
{
    Console.WriteLine("Вы администратор?");
}

Console.WriteLine("Вы женщина или мужчина?");
var gender = Console.ReadLine();
var answer = "";
var answer2 = "";
if (gender == "мужчина")
{
    Console.WriteLine("Вы женаты?");
    answer = Console.ReadLine();
}
else if (gender == "женщина")
{
    Console.WriteLine("Вы замужем?");
    answer = Console.ReadLine();
}


if (answer == "да")
{
    Console.WriteLine("вы женаты");
}
else if (answer2 == "да")
{
    Console.WriteLine("Вы замужем");
}


Console.WriteLine("Сколько вам лет?");
var ageAsString = Console.ReadLine();
var age = int.Parse(ageAsString);
if (age < 18)
{
    Console.WriteLine("Доступ запрещен");
}
else if (age >= 18)
{
    Console.WriteLine("Доступ разрешен");
}

Console.WriteLine("В какой стране вы живете?");
var country = Console.ReadLine();
if (country == "Россия")
{
    Console.WriteLine("Вы живете в России");
}
else if (country == "Китай")
{
    Console.WriteLine("Вы живете в китае");
}
else if (country == "Турция")
{
    Console.WriteLine("Вы живете в турции");
}
else
{
    Console.WriteLine("Вы живете в египте");
}