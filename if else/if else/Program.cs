
Console.WriteLine("Введите имя пользователя");
var userName = "admin";
if (userName == "admin") 
{
    Console.WriteLine("Вы администратор?");
}
Console.WriteLine("Вы женщина или мужчина?");
var gender = "женщина";
if (gender == "мужчина")
{
    Console.WriteLine("Вы женаты?");
}
else if (gender == "женщина")
{
    Console.WriteLine("Вы замужем?");
}
Console.WriteLine("вы замужем.");
Console.WriteLine("Сколько вам лет?");
var age = 20;
if (age < 18)
{
    Console.WriteLine("Доступ запрещен");
}
else if (age >= 18)
{
    Console.WriteLine("Доступ разрешен");
}
Console.WriteLine("В какой стране вы живете?");
var country = "Египет";
if (country == "РФ")
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