using System.Drawing;

string фамилияПользователя()
{
    Console.WriteLine("Какая ваша фамилия? ");
    var фамилия = Console.ReadLine();
    return фамилия;
}

string имяПользователя()
{
    Console.WriteLine("Как вас зовут ");
    var имя = Console.ReadLine();
    return имя;
}

int возрастПользователя()
{
    Console.WriteLine("Сколько вам лет?");
    var возраст_текст = Console.ReadLine();
    var возраст = int.Parse(возраст_текст);
    return возраст;
}

string полПользователя()
{
    Console.WriteLine("Вы женщина или мужчина?");
    var пол = Console.ReadLine();
    return пол;
}
bool положениеПользователя()
{
    Console.WriteLine("Вы состоите в браке?");
    var положение = Console.ReadLine();
    var брак = "Да";
    var положениеЧеловека = положение == брак;
    return положениеЧеловека;
        
}

bool любительКофе()
{
    Console.WriteLine("Вы любите кофе?");
    var кофе = Console.ReadLine();
    var люблю = "Да";
    var неЛюблю = "Нет";
    var Кофе1 = кофе == люблю;
    return Кофе1;
}
string аллергияПользователя()
{
    Console.WriteLine("У вас есть аллергия на продукты?");
    var аллергия = Console.ReadLine();
    if (аллергия == "Да")
    {
        Console.WriteLine("На какие именно продукты?");
    }
    var аллергияПродукты = Console.ReadLine();
    return аллергияПродукты;
}

int начальникПодчиненные()
{
    Console.WriteLine("Сколько человек в вашем коллективе ");
    var workers = Console.ReadLine();
    int workers_number = int.Parse(workers);
    if (workers_number == 1)
    {
        Console.WriteLine("1 человек поздравляет вас с юбилеем");
    }
    else if (workers_number >= 2 && workers_number <= 4)
    {
        Console.WriteLine(workers_number + " " + "поздравляют вас с юбилеем!");
    }
    else if (workers_number > 4)
    {
         Console.WriteLine("Все сотрудники поздравляют вас с юбилеем");
    }
    return workers_number;
}

string датаРождения()
{
    var датаРождения1 = "";
    while (датаРождения1 == "")
    {
        Console.WriteLine("Назовите вашу дату рождения");
        var birth_num = Console.ReadLine();
        var датаРождения12 = int.Parse(birth_num);
    }
 return датаРождения1;
}
Console.WriteLine(датаРождения());

string имяДевушки()
{
    Console.WriteLine("Как тебя зовут?");
    var name = Console.ReadLine();
    var newName = "Дорогая," + name + "," + "ты сегодня как всегда прекрасно выглядишь.";
    return newName;
}
Console.WriteLine(имяДевушки());
