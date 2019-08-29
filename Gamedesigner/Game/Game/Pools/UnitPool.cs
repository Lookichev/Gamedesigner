using Game.Units;

namespace Game.Pools
{
	/// <summary>
	/// Казармы
	/// </summary>
	public static class UnitPool
	{
		/// <summary>
		/// Морпех
		/// </summary>
		public static Marine Marine = new Marine();

		/// <summary>
		/// Диверсант
		/// </summary>
		public static Saboteur Saboteur = new Saboteur();

		/// <summary>
		/// Агент
		/// </summary>
		public static Agent Agent = new Agent();

		/// <summary>
		/// Миньон
		/// </summary>
		public static Minion Minion = new Minion();

		/// <summary>
		/// Падальщик
		/// </summary>
		public static Scavenger Scavenger = new Scavenger();

		/// <summary>
		/// Гончий
		/// </summary>
		public static Hound Hound = new Hound();

		/// <summary>
		/// Мародер
		/// </summary>
		public static Marauder Marauder = new Marauder();

		/// <summary>
		/// Массивный поглотитель
		/// </summary>
		public static MassiveAbsorber MassiveAbsorber = new MassiveAbsorber();
	}

	/// <summary>
	/// Морпех, играбельный персонаж
	/// </summary>
	public class Marine : Human
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="strength">Базовая сила персонажа</param>
		/// <param name="agility">Базовая ловкость персонажа</param>
		/// <param name="damage">Базовый урон персонажа</param>
		/// <param name="criticalDamage">Базовый критический урон</param>
		/// <param name="AdditionStrength">Прирост силы за уровень</param>
		/// <param name="AdditionAgility">Прирост ловкости за уровень</param>
		/// <param name="name">Имя персонажа</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Marine()
			: base(strength: 3, agility: 6, damage: 30, criticalDamage: 19, Balance.MarineAdditionStrength, Balance.MarineAdditionAgility, "Морпех",
				  hitPoints: 120, RegenHP : 4, speedAttack: 2, chanceCriticalDamage: 0.17, chanceSlip: 0.32, chanceEvasion: 0.11, armor: 0.2){}
	}

	/// <summary>
	/// Диверсант, играбельный персонаж
	/// </summary>
	public class Saboteur : Human
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="strength">Базовая сила персонажа</param>
		/// <param name="agility">Базовая ловкость персонажа</param>
		/// <param name="damage">Базовый урон персонажа</param>
		/// <param name="criticalDamage">Базовый критический урон</param>
		/// <param name="AdditionStrength">Прирост силы за уровень</param>
		/// <param name="AdditionAgility">Прирост ловкости за уровень</param>
		/// <param name="name">Имя персонажа</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Saboteur()
			: base(strength: 5, agility: 4, damage: 24, criticalDamage: 10, Balance.SaboteurAdditionStrength, Balance.SaboteurAdditionAgility, "Диверсант",
				  hitPoints: 100, RegenHP: 1, speedAttack: 2.5, chanceCriticalDamage: 0.19, chanceSlip: 0.36, chanceEvasion: 0.12, armor: 0.1){}
	}

	/// <summary>
	/// Агент, играбельный персонаж
	/// </summary>
	public class Agent : Human
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="strength">Базовая сила персонажа</param>
		/// <param name="agility">Базовая ловкость персонажа</param>
		/// <param name="damage">Базовый урон персонажа</param>
		/// <param name="criticalDamage">Базовый критический урон</param>
		/// <param name="AdditionStrength">Прирост силы за уровень</param>
		/// <param name="AdditionAgility">Прирост ловкости за уровень</param>
		/// <param name="name">Имя персонажа</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Agent()
			: base(strength: 4, agility: 5, damage: 26, criticalDamage: 15, Balance.AgentAdditionStrength, Balance.AgentAdditionAgility, "Агент",
				  hitPoints: 95, RegenHP: 4, speedAttack: 2.3, chanceCriticalDamage: 0.22, chanceSlip: 0.34, chanceEvasion: 0.1, armor: 0.13){}
	}

	/// <summary>
	/// Миньон, младший демон
	/// </summary>
	public class Minion : Demon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="chanceSkipTurn">Шанс пропустить ход</param>
		/// <param name="name">Имя демона</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Minion()
			: base(lifeSteal: 0, percentDamage: 0.38, percentCriticalDamage: 0.12,
			"Миньон", hitPoints: 40, regenHP: 0, speedAttack: 5,
			chanceCriticalDamage: 0.3, chanceSlip: 0.37, chanceEvasion: 0, armor: 0.26)	{}
	}

	/// <summary>
	/// Падальщик, младший демон
	/// </summary>
	public class Scavenger : Demon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="chanceSkipTurn">Шанс пропустить ход</param>
		/// <param name="name">Имя демона</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Scavenger()
			: base(lifeSteal: 4, percentDamage: 0.42, percentCriticalDamage: 0.19,
			"Падальщик", hitPoints: 90, regenHP: 0, speedAttack: 4,
			chanceCriticalDamage: 0.35, chanceSlip: 0.29, chanceEvasion: 0.05, armor: 0.29)	{}
	}

	/// <summary>
	/// Гончий, демон
	/// </summary>
	public class Hound : Demon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="chanceSkipTurn">Шанс пропустить ход</param>
		/// <param name="name">Имя демона</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Hound()
			: base(lifeSteal: 8, percentDamage: 0.12, percentCriticalDamage: 0.51,
			"Гончий", hitPoints: 150, regenHP: 1, speedAttack: 0.54,
			chanceCriticalDamage: 0.22, chanceSlip: 0.01, chanceEvasion: 0.02, armor: 0.3)	{}
	}

	/// <summary>
	/// Мародер, демон
	/// </summary>
	public class Marauder : Demon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="chanceSkipTurn">Шанс пропустить ход</param>
		/// <param name="name">Имя демона</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Marauder()
			: base(lifeSteal: 6, percentDamage: 0.59, percentCriticalDamage: 0.25,
			"Мародер", hitPoints: 209, regenHP: 3, speedAttack: 1.7,
			chanceCriticalDamage: 0.2, chanceSlip: 0.1, chanceEvasion: 0.26, armor: 0.4)	{}
	}

	/// <summary>
	/// Массивный поглотитель, ультимативный демон
	/// </summary>
	public class MassiveAbsorber : Demon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="chanceSkipTurn">Шанс пропустить ход</param>
		/// <param name="name">Имя демона</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public MassiveAbsorber()
			: base(lifeSteal: 12, percentDamage: 0.72, percentCriticalDamage: 0.4,
			"Массивный поглотитель", hitPoints: 421, regenHP: 5, speedAttack: 1.5,
			chanceCriticalDamage: 0.21, chanceSlip: 0.12, chanceEvasion: 0, armor: 0.45)	{}
	}
}
