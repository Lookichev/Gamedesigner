using Game.Customization;

namespace Game.Pools
{
	/// <summary>
	/// Оружейная
	/// </summary>
	public static class WeaponPool
	{
		/// <summary>
		/// Железный меч
		/// </summary>
		public static Sword IronSword = new Sword(10, 20, 0.02, 1, 1.35, "Железный меч");

		/// <summary>
		/// Стальной меч
		/// </summary>
		public static Sword SteelSword = new Sword(15, 30, 0.05, 1, 1.4, "Стальной меч");

		/// <summary>
		/// Железный топор
		/// </summary>
		public static Axe IronAxe = new Axe(10, 30, 0.1, 0.85, 1.2, "Железный топор");

		/// <summary>
		/// Стальной топор
		/// </summary>
		public static Axe SteelAxe = new Axe(15, 30, 0.13, 0.85, 1.35, "Стальной топор");

		/// <summary>
		/// Железный кинжал
		/// </summary>
		public static Dagger IronDagger = new Dagger(5, 0, 0.15, 1, 1.6, "Железный кинжал");

		/// <summary>
		/// Стальной кинжал
		/// </summary>
		public static Dagger SteelDagger = new Dagger(6, 10, 0.19, 0.95, 1.7, "Стальной кинжал");

		/// <summary>
		/// Железный булава
		/// </summary>
		public static Mace IronMace = new Mace(20, 25, 0, 0.85, 1, "Железная булава");

		/// <summary>
		/// Стальной булава
		/// </summary>
		public static Mace SteelMace = new Mace(25, 35, 0.01, 0.75, 1.1, "Стальная булава");
	}

	/// <summary>
	/// Меч
	/// </summary>
	public class Sword : Weapon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="damage">Урон</param>
		/// <param name="criticalDamage">Критический урон</param>
		/// <param name="chanceCriticalDamage">Шанс критического урона</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="factorSpeedAttack">Множитель скорости атаки</param>
		/// <param name="name">Имя оружия</param>
		public Sword(double damage, double criticalDamage, double chanceCriticalDamage,
			double mulctChanceEvasion, double FactorSpeedAttack, string name)
			: base(damage, criticalDamage, chanceCriticalDamage, mulctChanceEvasion, FactorSpeedAttack, name) { }
	}

	/// <summary>
	/// Топор
	/// </summary>
	public class Axe : Weapon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="damage">Урон</param>
		/// <param name="criticalDamage">Критический урон</param>
		/// <param name="chanceCriticalDamage">Шанс критического урона</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="factorSpeedAttack">Множитель скорости атаки</param>
		/// <param name="name">Имя оружия</param>
		public Axe(double damage, double criticalDamage, double chanceCriticalDamage,
			double mulctChanceEvasion, double FactorSpeedAttack, string name)
			: base(damage, criticalDamage, chanceCriticalDamage, mulctChanceEvasion, FactorSpeedAttack, name) { }
	}

	/// <summary>
	/// Кинжал
	/// </summary>
	public class Dagger : Weapon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="damage">Урон</param>
		/// <param name="criticalDamage">Критический урон</param>
		/// <param name="chanceCriticalDamage">Шанс критического урона</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="factorSpeedAttack">Множитель скорости атаки</param>
		/// <param name="name">Имя оружия</param>
		public Dagger(double damage, double criticalDamage, double chanceCriticalDamage,
			double mulctChanceEvasion, double FactorSpeedAttack, string name)
			: base(damage, criticalDamage, chanceCriticalDamage, mulctChanceEvasion, FactorSpeedAttack, name) { }
	}

	/// <summary>
	/// Булава
	/// </summary>
	public class Mace : Weapon
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="damage">Урон</param>
		/// <param name="criticalDamage">Критический урон</param>
		/// <param name="chanceCriticalDamage">Шанс критического урона</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="factorSpeedAttack">Множитель скорости атаки</param>
		/// <param name="name">Имя оружия</param>
		public Mace(double damage, double criticalDamage, double chanceCriticalDamage,
			double mulctChanceEvasion, double FactorSpeedAttack, string name)
			: base(damage, criticalDamage, chanceCriticalDamage, mulctChanceEvasion, FactorSpeedAttack, name) { }
	}
}
