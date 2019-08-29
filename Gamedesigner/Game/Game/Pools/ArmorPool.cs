using Game.Customization;

namespace Game.Pools
{
	/// <summary>
	/// Бронная
	/// </summary>
	public static class ArmorPool
	{
		/// <summary>
		/// Железный комбинезон
		/// </summary>
		public static Armour IronArmour = new Armour(50, 0.8, 0, 0.85, 1.31, 0.55, "Железный комбинезон");

		/// <summary>
		/// Стальной доспех
		/// </summary>
		public static Armour SteelArmour = new Armour(79, 0.79, 0.05, 0.8, 1.44, 0.69, "Стальной доспех");

		/// <summary>
		/// Титановый доспех
		/// </summary>
		public static Armour TitaniumArmour = new Armour(123, 0.79, 0.07, 0.78, 1.56, 0.78, "Титановый доспех");

		/// <summary>
		/// Железная каска
		/// </summary>
		public static Helmet IronHelmet = new Helmet(10, 0.9, 0.1, 0.75, 1.1, 0.9, "Железная каска");

		/// <summary>
		/// Стальной шлем
		/// </summary>
		public static Helmet SteelHelmet = new Helmet(23, 0.89, 0.12, 0.8, 1.2, 0.89, "Стальной шлем");

		/// <summary>
		/// Титановый шлем
		/// </summary>
		public static Helmet TitaniumHelmet = new Helmet(34, 0.88, 0.12, 0.89, 1.3, 0.93, "Титановый шлем");

		/// <summary>
		/// Кожанные берцы
		/// </summary>
		public static Shoes LeathernShoes = new Shoes(10, 1, 0, 1, 1.01, 1, "Кожанные берцы");

		/// <summary>
		/// Клепанные сапоги
		/// </summary>
		public static Shoes RivetedShoes = new Shoes(23, 1, 0, 1, 1.1, 1.05, "Клепанные сапоги");

		/// <summary>
		/// Чашуйчатые ботинки
		/// </summary>
		public static Shoes ScalyShoes = new Shoes(34, 1, 0, 1, 1.18, 1.1, "Чашуйчатые ботинки");

		/// <summary>
		/// Кожанные штаны
		/// </summary>
		public static Breeches LeathernBreeches = new Breeches(10, 1, 0, 1, 1.13, 1, "Кожанные штаны");

		/// <summary>
		/// Клепанные штаны
		/// </summary>
		public static Breeches RivetedBreeches = new Breeches(23, 1, 0, 1, 1.18, 1.1, "Клепанные штаны");

		/// <summary>
		/// Кожанные перчатки
		/// </summary>
		public static Gloves LeathernGloves = new Gloves(3, 1, -0.02, 1, 1.05, 1.1, "Кожанные перчатки");

		/// <summary>
		/// Клепанные перчатки
		/// </summary>
		public static Gloves RivetedGloves = new Gloves(20, 1, -0.12, 1, 1.1, 1.15, "Клепанные перчатки");
	}

	/// <summary>
	/// Доспехи
	/// </summary>
	public class Armour : ArmorSuit
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="mulctCriticalDamage">Штраф критического урона</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="armor">Броня</param>
		/// <param name="mulctSpeedAttack">Штраф скорости атаки</param>
		/// <param name="name">Имя доспеха</param>
		public Armour(double hitPoints, double mulctCriticalDamage, double chanceSlip,
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
			:base(hitPoints, mulctCriticalDamage, chanceSlip, mulctChanceEvasion, armor, mulctSpeedAttack, name)	{ }
	}

	/// <summary>
	/// Шлем
	/// </summary>
	public class Helmet : ArmorSuit
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="mulctCriticalDamage">Штраф критического урона</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="armor">Броня</param>
		/// <param name="mulctSpeedAttack">Штраф скорости атаки</param>
		/// <param name="name">Имя доспеха</param>
		public Helmet(double hitPoints, double mulctCriticalDamage, double chanceSlip,
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
			: base(hitPoints, mulctCriticalDamage, chanceSlip, mulctChanceEvasion, armor, mulctSpeedAttack, name) { }
	}

	/// <summary>
	/// Обувь
	/// </summary>
	public class Shoes : ArmorSuit
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="mulctCriticalDamage">Штраф критического урона</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="armor">Броня</param>
		/// <param name="mulctSpeedAttack">Штраф скорости атаки</param>
		/// <param name="name">Имя доспеха</param>
		public Shoes(double hitPoints, double mulctCriticalDamage, double chanceSlip,
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
			: base(hitPoints, mulctCriticalDamage, chanceSlip, mulctChanceEvasion, armor, mulctSpeedAttack, name) { }
	}

	/// <summary>
	/// Штаны
	/// </summary>
	public class Breeches : ArmorSuit
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="mulctCriticalDamage">Штраф критического урона</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="armor">Броня</param>
		/// <param name="mulctSpeedAttack">Штраф скорости атаки</param>
		/// <param name="name">Имя доспеха</param>
		public Breeches(double hitPoints, double mulctCriticalDamage, double chanceSlip,
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
			: base(hitPoints, mulctCriticalDamage, chanceSlip, mulctChanceEvasion, armor, mulctSpeedAttack, name) { }
	}

	/// <summary>
	/// Перчатки
	/// </summary>
	public class Gloves : ArmorSuit
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Здоровье</param>
		/// <param name="mulctCriticalDamage">Штраф критического урона</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="armor">Броня</param>
		/// <param name="mulctSpeedAttack">Штраф скорости атаки</param>
		/// <param name="name">Имя доспеха</param>
		public Gloves(double hitPoints, double mulctCriticalDamage, double chanceSlip,
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
			: base(hitPoints, mulctCriticalDamage, chanceSlip, mulctChanceEvasion, armor, mulctSpeedAttack, name) { }
	}
}
