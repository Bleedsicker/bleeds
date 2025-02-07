int суммаПокупок(int first, int second, int third)
{
    return first + second + third;
}

Console.WriteLine("Введите стоимость первой покупки");
var price1_text = Console.ReadLine();
var price1 = int.Parse(price1_text);
Console.WriteLine("Введите стоимость второй покупки");
var price2_text = Console.ReadLine();
var price2 = int.Parse(price2_text);
Console.WriteLine("Введите стоимость третьей покупки");
var price3_text = Console.ReadLine();
var price3 = int.Parse(price3_text);
var mainprice = суммаПокупок(price1,price2,price3);


string daughtersName(string first , string second, string third)
{
    return first + " " + second + " " + third;
}
Console.WriteLine("Как зовут вашу первую дочь?");
var name1 = Console.ReadLine();
Console.WriteLine("Как зовут вашу вторую дочь?");
var name2 = Console.ReadLine();
Console.WriteLine("Как зовут вашу третью дочь?");
    var name3 = Console.ReadLine();
var names = daughtersName(name1, name2, name3);
var allnames = "Ваших дочерей зовут " + names;


int spaceShip(int distance, int speed)
{
    return distance / speed;
}
Console.WriteLine("Введите расстояние до планеты");
var distance_text = Console.ReadLine();
var distance = int.Parse(distance_text);
var speed = 8;
var time = spaceShip(distance, speed);


int daytime()
{
    var time_text = Console.ReadLine();
    var time1 = int.Parse(time_text);
    if (time1 > 3 && time1 < 12)
    {
        Console.WriteLine("Доброе утро");
    }

    else if (time1 > 12 && time1 < 18)
    {
        Console.WriteLine("Добрый день");
    }
    else if (time1 > 18 && time1 < 24)
    {
        Console.WriteLine("Добрый вечер");
    }
    else if (time1 >= 00 && time1 <= 3)
    {
        Console.WriteLine("Доброй ночи");
    }
    return time1;
}
Console.WriteLine("Какой сейчас час?");
var hello = daytime();
Console.WriteLine(hello);

int swimmingPool(int length, int wide, int height)
{
    return length * wide * height;
}
Console.WriteLine("Введите длину");
var length_text = Console.ReadLine();
var length = int.Parse(length_text);
Console.WriteLine("Введите ширину");
var wide_text = Console.ReadLine();
var wide = int.Parse(wide_text);
Console.WriteLine("Введите высоту");
var height_text = Console.ReadLine();
var height = int.Parse(height_text);
var pool = swimmingPool(length, wide, height);
Console.WriteLine(pool);


