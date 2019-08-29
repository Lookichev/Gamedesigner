
namespace Game.Units
{
	/// <summary>
	/// Описывает базовые атрибуты персонажей
	/// </summary>
	public abstract class Unit
	{
		#region Базовые атрибуты

		/// <summary>
		/// Базовый показатель жизней
		/// </summary>
		protected readonly double c_BaseHitPoints;

		/// <summary>
		/// Базовый показатель регенерации здоровья
		/// </summary>
		protected readonly double c_BaseRegenHP;

		/// <summary>
		/// Базовый показатель скорости атаки
		/// </summary>
		protected readonly double c_BaseSpeedAttack;

		/// <summary>
		/// Базовый показатель шанса критического урона
		/// </summary>
		protected readonly double c_BaseChanceCriticalDamage;

		/// <summary>
		/// Базовый показатель шанса промаха
		/// </summary>
		protected readonly double c_BaseChanceSlip;

		/// <summary>
		/// Базовый показатель шанса уклонения
		/// </summary>
		protected readonly double c_BaseChanceEvasion;

		/// <summary>
		/// Базовый показатель брони
		/// </summary>
		protected readonly double c_BaseArmor;

		#endregion

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Unit(double hitPoints, double RegenHP, double speedAttack,
			double chanceCriticalDamage, double chanceSlip, double chanceEvasion, double armor)
		{
			c_BaseHitPoints = hitPoints;
			c_BaseRegenHP = RegenHP;
			c_BaseSpeedAttack = speedAttack;
			c_BaseChanceCriticalDamage = chanceCriticalDamage;
			c_BaseChanceSlip = chanceSlip;
			c_BaseChanceEvasion = chanceEvasion;
			c_BaseArmor = armor;
		}
	}
}
