
[System.Serializable]
public class BaseDefence : BaseStat {

	public BaseDefence()
	{
		StatName = "Defence";
		StatDescription = "Directly modifies player's Defence";
		StatType = StatTypes.DEFENCE;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}

}

