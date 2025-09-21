
namespace Domain;

public class Product
{
    // TODO сделать Price(decimal), сделать Name и Description, сделать новую таблицу OrderProduct (почитать про Relanrionship ManyToMany)
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public long Id { get; set; }  

    public ICollection<OrderProduct> OrderProducts { get; set; }
}
