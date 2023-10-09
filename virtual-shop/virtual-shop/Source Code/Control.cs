using System;
using System.Reflection;

namespace virtual_shop.SourceCode
{
	public struct BoolInt
	{
		public bool ChosenOption = false;
		public int SelectorIndex = 0;

		public BoolInt(bool chosenOption, int selectorIndex)
		{
			ChosenOption = chosenOption;
			SelectorIndex = selectorIndex;
		}
	}

	public class Control
	{
        public Control()
		{
			Basket basket = new();
			App(basket);
		}

		private void App(Basket basket)
		{
			while (LoopSelector(Display.RunOptions) == 0)
				basket.ManageBasket();

			Display.Recipt(basket._Basket);
		}

		// keeps running Selector until an option has been chosen
		public static int LoopSelector(Action<int> displayOptions)
		{
			BoolInt boolInt = new();

			while (!boolInt.ChosenOption)
			{
				displayOptions(boolInt.SelectorIndex);

				boolInt = Selector(boolInt);
			}

			return boolInt.SelectorIndex;
		}

		// povides a user friedly way of going up and down 1 of a number
		public static BoolInt Selector(BoolInt boolInt)
		{
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    boolInt.SelectorIndex--;
                    break;
                case ConsoleKey.S:
                    boolInt.SelectorIndex++;
                    break;
                case ConsoleKey.UpArrow:
                    boolInt.SelectorIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    boolInt.SelectorIndex++;
                    break;
                case ConsoleKey.Enter:
                    boolInt.ChosenOption = true;
					break;
            }

			return boolInt;
        }
	}
}

