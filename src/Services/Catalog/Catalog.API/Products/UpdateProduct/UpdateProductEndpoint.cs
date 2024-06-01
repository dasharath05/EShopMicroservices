namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(
 Guid Id,
 string Name,
 string Description,
 decimal Price,
 List<string> Category,
 string ImageFile) : ICommand<UpdateProductResult>;

public record UpdateProductCommandResponse(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductCommandResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .WithDescription("Update product")
            .WithSummary("Update product")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
