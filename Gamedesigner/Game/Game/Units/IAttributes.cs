
namespace Game.Units
{
	/// <summary>
	/// Интерфейс, предоставляющий свойства для вывода атрибутов юнитов
	/// </summary>
	public interface IAttributes
	{
		/// <summary>
		/// Здоровье
		/// </summary>
		int HitPoints { get; }

		/// <summary>
		/// Регенерация здоровья
		/// </summary>
		int RegenHP { get; }

		/// <summary>
		/// Выносливость
		/// </summary>
		int Endurance { get; }

		/// <summary>
		/// Регенерация выносливости
		/// </summary>
		int RegenEndurance { get; }

		/// <summary>
		/// Шанс критического урона
		/// </summary>
		int ChanceCriticalDamage { get; }

		/// <summary>
		/// Шанс промаха
		/// </summary>
		int ChanceSlip { get; }

		/// <summary>
		/// Шанс уклонения
		/// </summary>
		int ChanceEvasion { get; }

		/// <summary>
		/// Броня
		/// </summary>
		int Armor { get; }
	}
}
