
[System.Serializable]
public class BaseQuantity : BaseStat {

	public BaseQuantity()
	{
		StatName = "Quantity";
		StatDescription = "The amount of items in a slot.";
		StatType = StatTypes.QUANTITY;
		StatBaseValue = 1;
		StatModifiedValue = 0;
	}

}
