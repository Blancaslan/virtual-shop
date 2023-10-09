using System;
namespace virtual_shop.SourceCode
{
	public class Basket
	{
        public List<Product> _Basket = new();

        public void ManageBasket()
		{
			BoolInt boolInt = new();

			while (!boolInt.ChosenOption)
			{
                Display.BasketManagementOptions(boolInt.SelectorIndex);

				boolInt = Control.Selector(boolInt);
			}
			Options(boolInt.SelectorIndex);
		}

		private void Options(int index)
		{
			switch (index)
			{
				case 0:
					AddToBasket();
					break;
				case 1:
					SubFromBasket();
					break;
				case 2:
					Display.AllBasket(_Basket);
					break;
				case 3:
					break;
			}
		}

		private void AddToBasket()
		{
			int chosenProductsIndex = Control.LoopSelector(Display.ListProducts);
			List<Product> products = Gather.AllProducts();

			BoolInt boolInt = ProductInBasket(products[chosenProductsIndex]);

            if (boolInt.ChosenOption)
				_Basket[boolInt.SelectorIndex].Quantity++;
			else
			{
				Product newProduct = products[chosenProductsIndex];
				newProduct.Quantity = 1;
				_Basket.Add(newProduct);
			}
		}

		private void SubFromBasket()
		{
            int chosenProductsIndex = Control.LoopSelector(Display.ListProducts);
            List<Product> products = Gather.AllProducts();

			BoolInt boolInt = ProductInBasket(products[chosenProductsIndex]);

            if (boolInt.ChosenOption)
				RemoveProduct(boolInt.SelectorIndex);
        }

		private void RemoveProduct(int index)
		{
            if (_Basket[index].Quantity <= 1)
                _Basket.RemoveAt(index);
            else
                _Basket[index].Quantity--;
        }

		private BoolInt ProductInBasket(Product product)
		{
			for (int productIndex = 0; productIndex < _Basket.Count; productIndex++)
			{
				if (product.id == _Basket[productIndex].id)
				{
					return new BoolInt(true, productIndex);
				}
			}
			return new BoolInt(false, 0);
        }

		public static decimal BasketTotal(List<Product> products)
		{
			decimal Total = 0.00M;
			foreach (Product product in products)
			{
				Total += product.SellPrice * product.Quantity;
			}

			return Total;
		}
	}
}

