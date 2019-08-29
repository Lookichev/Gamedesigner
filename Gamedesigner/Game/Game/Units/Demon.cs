using System;

namespace Game.Units
{
	/// <summary>
	/// Враждебные единицы, демоны
	/// </summary>
	public abstract class Demon : Unit, IUnitAttribute
	{
		/// <summary>
		/// Имя класса
		/// </summary>
		private readonly string c_Name;



		/// <summary>
		/// Усиление демона
		/// </summary>
		public ModificationDemon Modification { get; set; }

		#region Базовые для демонов параметры

		/// <summary>
		/// Базовое кол-во восстанавливаемого здоровья за удар
		/// </summary>
		protected double c_BaseLifeSteal;

		/// <summary>
		/// Базовый процент отнимаемых жизней
		/// </summary>
		protected double c_BasePercentDamage;

		/// <summary>
		/// Базовый процент отнимаемых критической атакой жизней
		/// </summary>
		protected double c_BasePercentCriticalDamage;

		#endregion

		#region Вывод индивидуальных для демонов параметров

		/// <summary>
		/// Суммарное кол-во отжираемых хп
		/// </summary>
		public double LifeSteal => c_BaseLifeSteal;

		/// <summary>
		/// Суммарный процент урона (базовый * модификация)
		/// </summary>
		public double PercentDamage => 
			(Modification & ModificationDemon.BurningClaws) != 0 
			? c_BasePercentDamage * Balance.ModificationDamage : c_BasePercentDamage;

		/// <summary>
		/// Суммарный процент критического урона
		/// </summary>
		public double PercentCriticalDamage =>
			(Modification & ModificationDemon.SpikeClaws) != 0
			? c_BasePercentCriticalDamage * Balance.ModificationCriticalDamage : c_BasePercentCriticalDamage;

		#endregion

		#region Вывод общих для всех юнитов атрибутов

		/// <summary>
		/// Суммарное здоровье (базовый * модификация)
		/// </summary>
		public double HitPoints => 
			(Modification & ModificationDemon.AdditionalOrgans) != 0
			? c_BaseHitPoints * Balance.ModificationHitPoints : c_BaseHitPoints;

		/// <summary>
		/// Суммарная регенерация здоровья (базовый * модификация)
		/// </summary>
		public double RegenHP =>
			(Modification & ModificationDemon.Adaptation) != 0
			? c_BaseRegenHP * Balance.ModificationRegenHP : c_BaseRegenHP;

		/// <summary>
		/// Суммарная скорость атаки (базовая * модификация)
		/// </summary>
		public double SpeedAttack => 
			(Modification & ModificationDemon.AdditionalOrgans) != 0
			? c_BaseSpeedAttack * Balance.ModificationSpeedAttack : c_BaseSpeedAttack;

		/// <summary>
		/// Суммарный шанс критического урона (базовый * модификация)
		/// </summary>
		public double ChanceCriticalDamage =>
			(Modification & ModificationDemon.SpikeClaws) != 0
			? c_BaseChanceCriticalDamage * Balance.ModificationChanceCriticalDamage : c_BaseChanceCriticalDamage;

		/// <summary>
		/// Суммарный шанс промаха
		/// </summary>
		public double ChanceSlip => c_BaseChanceSlip;

		/// <summary>
		/// Суммарный шанс уклонения
		/// </summary>
		public double ChanceEvasion => c_BaseChanceEvasion;

		/// <summary>
		/// Суммарная броня
		/// </summary>
		public double Armor => c_BaseArmor;

		#endregion



		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="lifeSteal">Кол-во восстанавливаемого здоровья за удар</param>
		/// <param name="percentDamage">Процент отнимаемых жизней</param>
		/// <param name="percentCriticalDamage">Процент отнимаемых критической атакой жизней</param>
		/// <param name="name">Имя класса</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="regenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Demon(double lifeSteal, double percentDamage, double percentCriticalDamage, 
			string name, double hitPoints, double regenHP, double speedAttack,
			double chanceCriticalDamage, double chanceSlip, double chanceEvasion, double armor) 
			: base(hitPoints, regenHP, speedAttack,
			chanceCriticalDamage, chanceSlip, chanceEvasion, armor)
		{
			c_BaseLifeSteal = lifeSteal;
			c_BasePercentDamage = percentDamage;
			c_BasePercentCriticalDamage = percentCriticalDamage;
			c_Name = name;
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

	/// <summary>
	/// Усиление демона
	/// </summary>
	[Flags]
	public enum ModificationDemon
	{
		None = 0x0,

		/// <summary>
		/// Адаптация, увеличивающая регенерацию
		/// </summary>
		Adaptation = 0x1,

		/// <summary>
		/// Горящие когти, увеличивающие урон
		/// </summary>
		BurningClaws = 0x2,

		/// <summary>
		/// Пронзающие когти, увеличивающие криты
		/// </summary>
		SpikeClaws = 0x4,

		/// <summary>
		/// Дополнительные органы, увеличивающие здоровье и скорость атаки
		/// </summary>
		AdditionalOrgans = 0x8
	}
}
