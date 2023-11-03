using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_MagazinVirtual.Domain.Models;
using static Workflow_MagazinVirtual.Domain.Models.StariCos;

namespace Workflow_MagazinVirtual.Domain.Models
{
    public static class ShoppingCartOperation
    {
        public static IntCosCumparaturi ValidateShoppingCart(Func<Cod_Produs, bool> verifica_exista_prod, Func<Cantitate_Produs, bool> verifica_stoc, _CosCumparaturiNevalidate shoppingCart)
        {
            List<ProduseValidate> cos_valid = new();
            bool isValidList = true;
            string invalidReason = string.Empty;

            foreach (var unvalidatedCart in shoppingCart.ListaProduse)
            {
                if (!Cod_Produs.TryParse(unvalidatedCart.Cod, out Cod_Produs? codeValidation) || !verifica_exista_prod(codeValidation))
                {
                    invalidReason = $"Invalid product code {unvalidatedCart.Cod}!";
                    isValidList = false;
                    break;
                }
                if (!Cantitate_Produs.TryParse(unvalidatedCart.Cantitate, out Cantitate_Produs? quantityValidation) || !verifica_stoc(quantityValidation))
                {
                    invalidReason = $"Invalid product quantity ({unvalidatedCart.Cod},{unvalidatedCart.Cantitate})";
                    isValidList = false;
                    break;
                }
                Pret_Produs Price = new Pret_Produs();
                ProduseValidate validProduct = new(codeValidation, quantityValidation, Price);
                cos_valid.Add(validProduct);
            }
            if (isValidList)
            {
                return new _CosCumparaturiValidate(cos_valid);
            }
            else
            {
                return new _CosCumparaturiInvalid(shoppingCart.ListaProduse, invalidReason);
            }
        }

        public static IntCosCumparaturi CalculateTotalPrice(IntCosCumparaturi cart) => cart.Match(
            when_CosCumparaturiGol: emptyCart => emptyCart,
            when_CosCumparaturiNevalidate: unvalidatedCart => unvalidatedCart,
            when_CosCumparaturiInvalid: invalidCart => invalidCart,
            when_CosCalculatTotal: calculatedCart => calculatedCart,
            when_CosPlatit: paidCart => paidCart,
            when_CosCumparaturiValidate: validCart =>
            {
                var calculateCart = validCart.ListaProduse.Select(validCart =>
                                            new PretCalculat(validCart.Cod,
                                                                      validCart.Cantitate,
                                                                      validCart.Pret,
                                                                      Math.Round(validCart.Cantitate.ReturnQuantity() * validCart.Pret.ReturnPrice(), 2)));

                return new _CosCalculatTotal(calculateCart.ToList().AsReadOnly());
            }
        );

        public static IntCosCumparaturi PayShoppingCart(IntCosCumparaturi cart)
        {
            return cart.Match(
            when_CosCumparaturiGol: emptyCart => emptyCart,
            when_CosCumparaturiNevalidate: unvalidatedCart => unvalidatedCart,
            when_CosCumparaturiInvalid: invalidCart => invalidCart,
            when_CosCumparaturiValidate: validatedCart => validatedCart,
            when_CosPlatit: paidCart => paidCart,
            when_CosCalculatTotal: calculatedCart =>
            {
                StringBuilder csv = new();
                calculatedCart.ListaProduse.Aggregate(csv, (export, cart) => export.AppendLine($"{cart.Cod.Value}, {cart.Cantitate.Value}, {cart.Pret.Value}, {cart.PretTotal}"));

                _CosPlatit paidShoppingCart = new(calculatedCart.ListaProduse, csv.ToString(), DateTime.Now);

                return paidShoppingCart;
            });
        }
    }
}
