
[System.Serializable]
public class BaseAttack : BaseStat {

	public BaseAttack()
	{
		StatName = "Attack";
		StatDescription = "Directly modifies player's Attack";
		StatType = StatTypes.ATTACK;
		StatBaseValue = 0;
		StatModifiedValue = 0;
	}

}

