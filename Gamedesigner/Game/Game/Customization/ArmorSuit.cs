
namespace Game.Customization
{
	/// <summary>
	/// Броня для персонажей
	/// </summary>
	public class ArmorSuit
	{
		/// <summary>
		/// Имя доспеха
		/// </summary>
		private readonly string c_Name;



		/// <summary>
		/// Здоровье
		/// </summary>
		public double HitPoints { get; }

		/// <summary>
		/// Штраф критического урона
		/// </summary>
		public double MulctCriticalDamage { get; }

		/// <summary>
		/// Шанс промаха
		/// </summary>
		public double ChanceSlip { get; }

		/// <summary>
		/// Штраф шанса уклонения
		/// </summary>
		public double MulctChanceEvasion { get; }

		/// <summary>
		/// Броня
		/// </summary>
		public double Armor { get; }

		/// <summary>
		/// Штраф скорости атаки
		/// </summary>
		public double MulctSpeedAttack { get; }



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
		public ArmorSuit(double hitPoints, double mulctCriticalDamage, double chanceSlip, 
			double mulctChanceEvasion, double armor, double mulctSpeedAttack, string name)
		{
			HitPoints = hitPoints;
			MulctCriticalDamage = mulctCriticalDamage;
			ChanceSlip = chanceSlip;
			MulctChanceEvasion = mulctChanceEvasion;
			Armor = armor;
			MulctSpeedAttack = mulctSpeedAttack;
			c_Name = name;
		}

		/// <summary>
		/// Возвращает здоровье, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetHitPoints(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.HitPoints;
			else return 0;
		}

		/// <summary>
		/// Возвращает шанс критического урона, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetMulctCriticalDamage(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.MulctCriticalDamage;
			else return 1;
		}

		/// <summary>
		/// Возвращает шанс промаха, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetChanceSlip(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.ChanceSlip;
			else return 0;
		}

		/// <summary>
		/// Возвращает штраф шанса уклонения, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetMulctChanceEvasion(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.MulctChanceEvasion;
			else return 1;
		}

		/// <summary>
		/// Возвращает броню, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetArmor(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.Armor;
			else return 0;
		}

		/// <summary>
		/// Возвращает штраф скорости атаки, если есть броня
		/// </summary>
		/// <param name="armorSuit">Броня</param>
		/// <returns></returns>
		public static double GetMulctSpeedAttack(ArmorSuit armorSuit)
		{
			if (armorSuit != null) return armorSuit.MulctSpeedAttack;
			else return 1;
		}

		/// <summary>
		/// Возвращает текстовое представление объекта
		/// </summary>
		/// <returns>Строка</returns>
		public override string ToString()
		{
			return c_Name;
		}
	}
}
