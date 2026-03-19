using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
  public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
  {
    Product? product = await session.LoadAsync<Product>(query.id);
    if (product == null) throw new ProductNotFoundException();

    return new GetProductByIdResult(product);
  }
}
