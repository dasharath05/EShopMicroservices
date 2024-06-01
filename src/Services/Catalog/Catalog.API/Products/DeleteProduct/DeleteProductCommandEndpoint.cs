namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductCommandRequest(Guid Id)

public record DeleteProductCommandResponse(bool IsSuccess);

public class DeleteProductCommandEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(id));

            var response = result.Adapt<DeleteProductCommandResponse>();

            return Results.Ok(response);
        });
    }
}
