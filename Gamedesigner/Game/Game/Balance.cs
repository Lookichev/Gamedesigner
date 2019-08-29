
namespace Game
{
	/// <summary>
	/// Класс, хранящий множители и атрибуты баланса
	/// </summary>
	public static class Balance
	{
		/// <summary>
		/// Кол-во очков совершенствования за один уровень
		/// </summary>
		public static int AmountPoints { get; } = 3;

		/// <summary>
		/// Лимит очков совершенствования на один параметр
		/// </summary>
		public static int LimitPoints { get; } = 15;

		#region Приросты статов героев

		/// <summary>
		/// Морпех: Базовый прирост силы за уровень персонажа
		/// </summary>
		public static int MarineAdditionStrength { get; } = 4;

		/// <summary>
		/// Морпех: Базовый прирост ловкости за уровень персонажа
		/// </summary>
		public static int MarineAdditionAgility { get; } = 2;

		/// <summary>
		/// Диверсант: Базовый прирост силы за уровень персонажа
		/// </summary>
		public static int SaboteurAdditionStrength { get; } = 2;

		/// <summary>
		/// Диверсант: Базовый прирост ловкости за уровень персонажа
		/// </summary>
		public static int SaboteurAdditionAgility { get; } = 4;

		/// <summary>
		/// Агент: Базовый прирост силы за уровень персонажа
		/// </summary>
		public static int AgentAdditionStrength { get; } = 3;

		/// <summary>
		/// Агент: Базовый прирост ловкости за уровень персонажа
		/// </summary>
		public static int AgentAdditionAgility { get; } = 3;

		#endregion

		#region Множители силы и ловкости

		/// <summary>
		/// Множитель здоровья, за каждую единицу силы
		/// </summary>
		public static double MultiHitPoints { get; } = 2;

		/// <summary>
		/// Множитель критического урона, за каждую единицу силы
		/// </summary>
		public static double MultiCriticalDamage { get; } = 0.3;

		/// <summary>
		/// Множитель шанса уклонения, за каждую единицу ловкости
		/// </summary>
		public static double MultiChanceEvasion { get; } = 0.00125;

		/// <summary>
		/// Множитель скорости атаки, за каждую единицу ловкости
		/// </summary>
		public static double MultiSpeedAttack { get; } = 0.016;

		#endregion

		#region Множители очков совершенствования

		/// <summary>
		/// Множитель очков для урона
		/// </summary>
		public static double FactorDamage { get; } = 3;

		/// <summary>
		/// Множитель очков для критического урона
		/// </summary>
		public static double FactorCriticalDamage { get; } = 4;

		/// <summary>
		/// Множитель очков для здоровья
		/// </summary>
		public static double FactorHitPoints { get; } = 44;

		/// <summary>
		/// Множитель очков для регенерации здоровья
		/// </summary>
		public static double FactorRegenHP { get; } = 1.25;

		/// <summary>
		/// Множитель очков для скорости атаки
		/// </summary>
		public static double FactorSpeedAttack { get; } = 0.01;

		/// <summary>
		/// Множитель очков для шанса критического урона
		/// </summary>
		public static double FactorChanceCriticalDamage { get; } = 0.11;

		/// <summary>
		/// Множитель очков для шанса промаха
		/// </summary>
		public static double FactorChanceSlip { get; } = -0.063;

		/// <summary>
		/// Множитель очков для шанса уклонения
		/// </summary>
		public static double FactorChanceEvasion { get; } = 0.0135;

		/// <summary>
		/// Множитель очков для брони
		/// </summary>
		public static double FactorArmor { get; } = 0.019;

		#endregion

		#region Бонусы героев

		/// <summary>
		/// Бонус скорости атаки
		/// </summary>
		public static double ExtraSpeedAttack { get; } = 1.6;

		/// <summary>
		/// Бонус множителя критического урона
		/// </summary>
		public static double ExtraCriticalDamage { get; } = 1.72;

		/// <summary>
		/// Бонус регенерации
		/// </summary>
		public static double ExtraRegen { get; } = 2.53;

		/// <summary>
		/// Бонус шанса промаха
		/// </summary>
		public static double ExtraChanceSlip { get; } = 0.32;

		#endregion

		#region Модификация параметров демонов

		/// <summary>
		/// Модификация показателя жизней (AdditionalOrgans)
		/// </summary>
		public static double ModificationHitPoints { get; } = 2.1;

		/// <summary>
		/// Модификация скорости атаки (AdditionalOrgans)
		/// </summary>
		public static double ModificationSpeedAttack { get; } = 1.9;

		/// <summary>
		/// Модификация регенерации здоровья (Adaptation)
		/// </summary>
		public static double ModificationRegenHP { get; } = 2.55;

		/// <summary>
		/// Модификация урона (BurningClaws)
		/// </summary>
		public static double ModificationDamage { get; } = 1.6;

		/// <summary>
		/// Модификация шанса критического урона (SpikeClaws)
		/// </summary>
		public static double ModificationChanceCriticalDamage { get; } = 1.89;

		/// <summary>
		/// Модификация критического урона (SpikeClaws)
		/// </summary>
		public static double ModificationCriticalDamage { get; } = 1.73;

		#endregion
	}
}
