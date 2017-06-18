
[System.Serializable]
public class BaseHealth : BaseStat {

	public BaseHealth()
	{
		StatName = "Health";
		StatDescription = "Directly modifies player's Health";
		StatType = StatTypes.HEALTH;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}

}
