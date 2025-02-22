namespace Class1;
class Ученик
{
    public string Имя;
    public int НомерКласса;
    public string Предмет;
    public string Answer;
    public void AnswerStudent()
    {
        Console.WriteLine("Нравится ли вам выбранный предмет?");
        var answer = Console.ReadLine();
        if (answer == "да")
        {
            Console.WriteLine("Урок начнется через час");
        }
        else if (answer == "нет")
        {
            Console.WriteLine("Какой предмет вам нравится больше?");
            var answer1 = Console.ReadLine();
            Answer = answer1;
        }
    }
}
