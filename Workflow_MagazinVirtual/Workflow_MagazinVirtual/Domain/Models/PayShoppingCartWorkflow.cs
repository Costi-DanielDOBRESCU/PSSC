using System;
using static Workflow_MagazinVirtual.Domain.Models.OrderProcessingEvent;
using static Workflow_MagazinVirtual.Domain.Models.StariCos;
namespace Workflow_MagazinVirtual.Domain.Models
{
    public class PayShoppingCartWorkflow
    {
        public IOrderProcessingEvent Execute(ProcesareComenzi command, Func<Cantitate_Produs, bool> checkProductExists, Func<Cantitate_Produs, bool> checkIfEnoughStock)
        {
            _CosCumparaturiNevalidate cos_nevalidat = new _CosCumparaturiNevalidate(command.InputCosCumparaturi);
            IntCosCumparaturi cart = ProduseValidate(checkProductExists, checkIfEnoughStock, unvalidatedCart);
            cart = CalculateTotalPrice(cart);
            cart = _CosPlatit(cart);

            return cart.Match(
                    whenEmptyShoppingCart: emptyCart => new OrderProcessingFailedEvent("Unexpected empty state") as IOrderProcessingEvent,
                    whenUnvalidatedShoppingCart: cos_nevalidat => new OrderProcessingFailedEvent("Unexpected unvalidated state"),
                    whenInvalidatedShoppingCart: invalidCart => new OrderProcessingFailedEvent(invalidCart.Reason),
                    whenValidatedShoppingCart: validatedCart => new OrderProcessingFailedEvent("Unexpected validated state"),
                    whenCalculatedShoppingCart: calculatedCart => new OrderProcessingFailedEvent("Unexpected calculated state"),
                    whenPaidShoppingCart: paidCart => new OrderProcessingSucceededEvent(paidCart.Csv, paidCart.PayDate)
                );
        }
    }
}

