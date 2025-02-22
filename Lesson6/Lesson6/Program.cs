using System.Security.Cryptography.X509Certificates;

class Турист
{
    public string Имя;
    public int Возраст;
    public string Место;
    public string Билет()
    {
        return Имя + " " + Место;
    }
}


class ВерхняяОдежда
{
    public string Цвет;
    public string Размер;
    public int Цена;
    public string Категория;
    public void ShowText()
    {
        Console.WriteLine("Назовите категорию одежды");
        var answer = Console.ReadLine();
        Категория = answer;
        Console.WriteLine("Цвет:" + Цвет + " Размер:" + Размер + " Цена:" + Цена);
    }
}


class Ученик
{
    public string Имя;
    public int НомерКласса;
    public string Предмет;
    public void AnswerStudent()
    {
        Console.WriteLine("Нравится ли вам выбранный предмет?");
        var answer = Console.ReadLine();
        if (answer == "да")
        {
            Console.WriteLine("Урок начнется через час");
        }
        else
        {
            Console.WriteLine("Какой предмет вам нравится больше?");
        }
    }
}
