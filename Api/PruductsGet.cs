using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Api;
// update the logic in the Run method to get your products. There's data access logic in the ProductData.cs file as a class called ProductData, which is available via Dependency Injection as the IProductData interface. The interface has a method on it called GetProducts, which returns a Task<IEnumerable<Product> that asynchronously returns a list of products.
public class ProductsGet
{
	private readonly IProductData productData;

	public ProductsGet(IProductData productData)
	{
		this.productData = productData;
	}

	[FunctionName("ProductsGet")]
	public async Task<IActionResult> Run(
					[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
	{
		var products = await productData.GetProducts();
		return new OkObjectResult(products);
	}
}