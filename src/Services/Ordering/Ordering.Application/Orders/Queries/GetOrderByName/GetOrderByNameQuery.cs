namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrderByNameQuery(string OrderName)
    : IQuery<GetOrderByNameResult>;

public record GetOrderByNameResult(IEnumerable<OrderDto> Orders);
