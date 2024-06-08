namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

//public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
//{
//    public StoreBasketValidator()
//    {
//        RuleFor(x => x.Cart).NotEmpty().WithMessage("Cart is required");
//        RuleFor(x=>x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
//    }
//}

public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;

        var basket = await repository.StoreBasketAsync(cart, cancellationToken);

        return new StoreBasketResult(basket.UserName);
    }
}
