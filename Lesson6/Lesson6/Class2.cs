namespace Class2;
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
