namespace Ordering.Application.Orders.Queries.GetOrderByName;
public class GetOrderByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
                        .Include(x => x.OrderItems)
                        .AsNoTracking()
                        .Where(x => x.OrderName.Value.Contains(query.OrderName))
                        .OrderBy(x => x.OrderName.Value)
                        .ToListAsync(cancellationToken);

        return new GetOrderByNameResult(orders.ToOrderDtoList());
    }
}
