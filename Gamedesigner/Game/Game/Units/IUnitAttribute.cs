
namespace Game.Units
{
	/// <summary>
	/// Вывод общих для всех юнитов атрибутов
	/// </summary>
	interface IUnitAttribute
	{
		/// <summary>
		/// Суммарное здоровье
		/// </summary>
		double HitPoints { get; }

		/// <summary>
		/// Суммарная регенерация здоровья
		/// </summary>
		double RegenHP { get; }

		/// <summary>
		/// Суммарная скорость атаки
		/// </summary>
		double SpeedAttack { get; }

		/// <summary>
		/// Суммарный шанс критического урона
		/// </summary>
		double ChanceCriticalDamage { get; }

		/// <summary>
		/// Суммарный шанс промаха
		/// </summary>
		double ChanceSlip { get; }

		/// <summary>
		/// Суммарный шанс уклонения
		/// </summary>
		double ChanceEvasion { get; }

		/// <summary>
		/// Суммарная броня
		/// </summary>
		double Armor { get; }
	}
}
