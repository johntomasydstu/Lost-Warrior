
[System.Serializable]
public class BaseLevel : BaseStat {

	public BaseLevel()
	{
		StatName = "Level";
		StatDescription = "Directly modifies player's Level";
		StatType = StatTypes.LEVEL;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}

}
