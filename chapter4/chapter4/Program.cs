var sum = 0;
for (var num = 0; num <= 100; num++)
{
    sum = sum + num;
}
Console.WriteLine(sum);


for (var text = 1; text < 100; text++)
{
    Console.WriteLine("Строка" + text);
}

for (var num = 0; num < 100; num++)
{
    if (num >= 10 && num <= 20)
    {
        Console.WriteLine(num);
    }
    if (num >= 40 && num <= 50)
    {
        Console.WriteLine(num);
    }
}

for (var num = 0; num < 100; num = num + 2)
{
    Console.WriteLine(num);
}

var task4 = 0;
for (var num = 0; num < 1000000; num++)
{
    task4 = task4 + num;
    if (task4 > 100000)
    {
        Console.WriteLine(num);
        break;
    }
}
Console.WriteLine(task4);