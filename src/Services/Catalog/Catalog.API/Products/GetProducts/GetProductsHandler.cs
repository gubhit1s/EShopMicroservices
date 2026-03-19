namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery() : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product> Products);

public class GetProductsQueryHandler(IDocumentSession documentSession,
	ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductResult>
{
	public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		logger.LogInformation("GetProductsQueryHandler called with {@query}", query);

		var products = await documentSession.Query<Product>().ToListAsync(cancellationToken);

		return new GetProductResult(products);
	}
}
