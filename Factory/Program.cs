Product product = new Product() { Name = "C300" };
IProductInspectorFactory factory = new CPUProdcutInspectorFactory();
var service = new InspectionService(factory);

service.Inspect(product);

class InspectionService
{
    private readonly IProductInspectorFactory _productInspectorFactory;
    public InspectionService(
        IProductInspectorFactory productInspectorFactory)
    {
        _productInspectorFactory = productInspectorFactory;
    }
    public void Inspect(Product product)
    {
       
        var result = _productInspectorFactory.CreateInpector().Inspect(product);
        Console.WriteLine("save result to db...");
        Console.WriteLine(result);
    }    
}




class Product
{
    public string Name { get; set; }
}

interface IProductInspector
{
    string Inspect(Product product);
}

class CPUProductInspector : IProductInspector
{
    public string Inspect(Product product)
    {
        return $"product name: {product.Name}, result by cpu";
    }
}
class GPUProductInspector : IProductInspector
{
    public string Inspect(Product product)
    {
        return $"product name: {product.Name}, result by gpu";
    }
}

interface IProductInspectorFactory
{
    IProductInspector CreateInpector();
}

class CPUProdcutInspectorFactory : IProductInspectorFactory
{
    public IProductInspector CreateInpector()
    {
        return new CPUProductInspector();
    }
}
class GPUProdcutInspectorFactory : IProductInspectorFactory
{
    public IProductInspector CreateInpector()
    {
        return new GPUProductInspector();
    }
}

