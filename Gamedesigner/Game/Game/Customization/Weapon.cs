
namespace Game.Customization
{
	/// <summary>
	/// Оружие для персонажей
	/// </summary>
	public class Weapon
	{
		/// <summary>
		/// Имя оружия
		/// </summary>
		private readonly string c_Name;



		/// <summary>
		/// Урон
		/// </summary>
		public double Damage { get; }

		/// <summary>
		/// Критический урон
		/// </summary>
		public double CriticalDamage { get; }

		/// <summary>
		/// Шанс критического урона
		/// </summary>
		public double ChanceCriticalDamage { get; }

		/// <summary>
		/// Штраф шанса уклонения
		/// </summary>
		public double MulctChanceEvasion { get; }

		/// <summary>
		/// Множитель скорости атаки
		/// </summary>
		public double FactorSpeedAttack { get; }



		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="damage">Урон</param>
		/// <param name="criticalDamage">Критический урон</param>
		/// <param name="chanceCriticalDamage">Шанс критического урона</param>
		/// <param name="mulctChanceEvasion">Штраф шанса уклонения</param>
		/// <param name="factorSpeedAttack">Множитель скорости атаки</param>
		/// <param name="name">Имя оружия</param>
		public Weapon(double damage, double criticalDamage, double chanceCriticalDamage,
			double mulctChanceEvasion, double factorSpeedAttack, string name)
		{
			Damage = damage;
			CriticalDamage = criticalDamage;
			ChanceCriticalDamage = chanceCriticalDamage;
			MulctChanceEvasion = mulctChanceEvasion;
			FactorSpeedAttack = factorSpeedAttack;
			c_Name = name;
		}

		/// <summary>
		/// Возвращает урон, если есть оружие
		/// </summary>
		/// <param name="weapon">Оружие</param>
		/// <returns></returns>
		public static double GetDamage(Weapon weapon)
		{
			if (weapon != null) return weapon.Damage;
			else return 0;
		}

		/// <summary>
		/// Возвращает критический урон, если есть оружие
		/// </summary>
		/// <param name="weapon">Оружие</param>
		/// <returns></returns>
		public static double GetCriticalDamage(Weapon weapon)
		{
			if (weapon != null) return weapon.CriticalDamage;
			else return 0;
		}

		/// <summary>
		/// Возвращает шанс критического урона, если есть оружие
		/// </summary>
		/// <param name="weapon">Оружие</param>
		/// <returns></returns>
		public static double GetChanceCriticalDamage(Weapon weapon)
		{
			if (weapon != null) return weapon.ChanceCriticalDamage;
			else return 0;
		}

		/// <summary>
		/// Возвращает штраф на уклонение, если есть оружие
		/// </summary>
		/// <param name="weapon">Оружие</param>
		/// <returns></returns>
		public static double GetMulctChanceEvasion(Weapon weapon)
		{
			if (weapon != null) return weapon.MulctChanceEvasion;
			else return 1;
		}

		/// <summary>
		/// Возвращает множитель скорости атаки, если есть оружие
		/// </summary>
		/// <param name="weapon">Оружие</param>
		/// <returns></returns>
		public static double GetFactorSpeedAttack(Weapon weapon)
		{
			if (weapon != null) return weapon.FactorSpeedAttack;
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