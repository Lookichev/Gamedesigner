using Game.Units;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
	/// <summary>
	/// Арена для спарингов
	/// </summary>
	public class Arena
	{
		/// <summary>
		/// Генератор случайных чисел
		/// </summary>
		private readonly Random c_Random = new Random();

		#region Запись

		/// <summary>
		/// Время на симуляцию всех боев
		/// </summary>
		private int m_Sec;

		/// <summary>
		/// Кол-во нанесенного человеком урона
		/// </summary>
		private int m_ResultsAmountHumanDamage;

		/// <summary>
		/// Кол-во нанесенного демонами урона
		/// </summary>
		private int m_ResultsAmountDemonsDamage;

		/// <summary>
		/// Кол-во атак человека
		/// </summary>
		private int m_ResultsAmountHumanAttacks;

		/// <summary>
		/// Кол-во критических атак человека
		/// </summary>
		private int m_ResultsAmountHumanCriticalAttacks;

		/// <summary>
		/// Кол-во атак демонов
		/// </summary>
		private int m_ResultsAmountDemonsAttacks;

		/// <summary>
		/// Кол-во критческих атак демонов
		/// </summary>
		private int m_ResultsAmountDemonsCriticalAttacks;

		/// <summary>
		/// Кол-во выигранных матчей героем
		/// </summary>
		private int m_ResultsAmountHumanWins;

		/// <summary>
		/// Кол-во выигранных матчей демонами
		/// </summary>
		private int m_ResultsAmountDemonsWins;
		#endregion

		/// <summary>
		/// Кол-во здоровья у человека
		/// </summary>
		private int m_HPHuman;

		/// <summary>
		/// Кол-во здоровья у демона
		/// </summary>
		private int m_HPDemon;

		/// <summary>
		/// Атака человека
		/// </summary>
		private Timer TimerHumanAttack;

		/// <summary>
		/// Атака демона
		/// </summary>
		private Timer TimerDemonAttack;

		/// <summary>
		/// Регенерация
		/// </summary>
		private Timer TimerRegen;


		/// <summary>
		/// Результаты симуляции
		/// </summary>
		public IEnumerable<string> Results { get; private set; }

		/// <summary>
		/// Листинг каждого боя
		/// </summary>
		public List<LinkedList<string>> Replays { get; private set; }



		/// <summary>
		/// Кол-во боев
		/// </summary>
		public int AmountFights { get; set; }

		/// <summary>
		/// Игрок
		/// </summary>
		public Human Player { get; set; }

		/// <summary>
		/// Враги
		/// </summary>
		public Demon Enemies { get; set; }

		/// <summary>
		/// Бонусы людей
		/// </summary>
		public Extra Extra { get; set; }


		/// <summary>
		/// Запуск сражений
		/// </summary>
		public void StartBattle()
		{
			//Очистка журнала сражений и записей
			Replays = new List<LinkedList<string>>(AmountFights);
			Results = null;

			//Производится заданное количество симуляций боя
			for (var amountFights = 0; amountFights < AmountFights; amountFights++)
			{
				Replays.Add(new LinkedList<string>());

				//Генерация здоровья для каждого юнита
				m_HPHuman = (int)Player.HitPoints;
				m_HPDemon = (int)Enemies.HitPoints;

				var humanAttack = new TimerCallback(HumanAttack);
				var demonAttack = new TimerCallback(DemonAttack);
				var regen = new TimerCallback(Regen);

				var time = Player.SpeedAttack;
				if ((Extra & Extra.SpeedAttack) != 0) time *= Balance.ExtraSpeedAttack;

				TimerHumanAttack = new Timer(humanAttack, null, 0, (int)Math.Round(time * 10));
				TimerDemonAttack = new Timer(demonAttack, null, 0, (int)Math.Round(Enemies.SpeedAttack * 10));
				TimerRegen = new Timer(regen, null, 0, 10);

				//Пока : продолжается пока кто-то не погибнет
				while (TimerHumanAttack != null && TimerDemonAttack != null)
				{
					Thread.Sleep(1);
					m_Sec++;
				}

				if (m_HPHuman <= 0)
				{
					Replays[Replays.Count - 1].AddLast("------------------------------------Демон разорвал героя!------------------------------------");
					m_ResultsAmountDemonsWins++;
				}
				else if (m_HPDemon <= 0)
				{
					Replays[Replays.Count - 1].AddLast("------------------------------------Победа в битве за героем!------------------------------------");
					m_ResultsAmountHumanWins++;
				}
			}

			RecordResults();
		}

		/// <summary>
		/// Атака персонажа
		/// </summary>
		private void HumanAttack(object e)
		{
			var damage = (int)Player.Damage;
			var chanceCritical = false;
			string str;

			//Проверка критического урона
			if (Random(Player.ChanceCriticalDamage))
			{
				if ((Extra & Extra.CriticalDamage) != 0) damage += (int)(Player.CriticalDamage * Balance.ExtraCriticalDamage);
				damage += (int)Player.CriticalDamage;
				chanceCritical = true;
				str = "---> Герой наносит " + damage.ToString() + " критического урона";
			}
			else
			{
				str = "---> Герой наносит " + damage.ToString() + " урона";
			}
			
			var slip = Player.ChanceSlip;
			if ((Extra & Extra.ChanceSlip) != 0) slip *= Balance.ExtraChanceSlip;

			//Проверка попадания
			if (Random(slip + Enemies.ChanceEvasion))
			{
				str += "\n	Демон уклоняется от атаки";
				Replays[Replays.Count - 1].AddLast(str);
				return;
			}

			//Нанесение урона
			damage -=  (int)(damage * Enemies.Armor);

			m_ResultsAmountHumanDamage += damage;//Подсчет нанесенного урона
			if (chanceCritical) m_ResultsAmountHumanCriticalAttacks++;//Подсчет кол-ва атак
			else m_ResultsAmountHumanAttacks++;

			str += "\n	Демон получает урон " + m_HPDemon + " - " + damage;
			m_HPDemon -= damage;

			//Проверка смерти
			if (m_HPDemon <= 0)
			{
				try
				{
					TimerDemonAttack.Dispose();
					TimerDemonAttack = null;
					TimerHumanAttack.Dispose();
					TimerHumanAttack = null;
					TimerRegen.Dispose();
					TimerRegen = null;
				}
				catch { }
			}

			Replays[Replays.Count - 1].AddLast(str);
		}

		/// <summary>
		/// Атака демона
		/// </summary>
		private void DemonAttack(object e)
		{
			var damage = Enemies.PercentDamage;
			var chanceCritical = false;
			string str;

			//Проверка критического урона
			if (Random(Enemies.ChanceCriticalDamage))
			{
				damage += Enemies.PercentCriticalDamage;
				chanceCritical = true;
				damage = (int)(damage * Player.HitPoints);//Проценты переводятся в абсолютный урон
				str = "---> Демон наносит " + damage.ToString() + " критического урона";
			}
			else
			{
				damage = (int)(damage * Player.HitPoints);
				str = "---> Демон наносит " + damage.ToString() + " урона";
			}

			//Проверка попадания
			if (Random(Enemies.ChanceSlip + Player.ChanceEvasion))
			{
				str += "\n	Герой уклоняется от атаки";
				Replays[Replays.Count - 1].AddLast(str);
				return;
			}

			//Нанесение урона
			damage -= (int)(damage * Player.Armor);

			//Пожирание плоти врагами
			var steal = m_HPDemon;
			steal = steal >= Enemies.LifeSteal ? (int)Enemies.LifeSteal : steal;
			if (steal != 0)
			{
				str += "\n	Демон крадет " + steal + " здоровья";
				m_HPDemon += steal;
			}

			if (chanceCritical) m_ResultsAmountDemonsCriticalAttacks++;//Подсчет кол-ва атак
			else m_ResultsAmountDemonsAttacks++;

			//Если : урон отрицательный
			if (damage <= 0)
			{
				str += "\n	Герой полностью блокирует урон";
				Replays[Replays.Count - 1].AddLast(str);
				return;
			}

			m_ResultsAmountDemonsDamage += (int)damage;//Подсчет нанесенного урона

			str += "\n	Герой получает урон " + m_HPHuman + " - " + damage;
			m_HPHuman -= (int)damage;

			//Проверка смерти
			if (m_HPHuman <= 0)
			{
				try
				{
					TimerDemonAttack.Dispose();
					TimerDemonAttack = null;
					TimerHumanAttack.Dispose();
					TimerHumanAttack = null;
					TimerRegen.Dispose();
					TimerRegen = null;
				}
				catch { }
			}
			Replays[Replays.Count - 1].AddLast(str);
		}

		/// <summary>
		/// Регенерация
		/// </summary>
		private void Regen(object e)
		{
			if (m_HPHuman <= 0 || m_HPDemon <= 0) return;

			var heal = Player.HitPoints - m_HPHuman;
			heal = heal >= Player.RegenHP ? Player.RegenHP : heal;
			if (heal != 0)
			{
				m_HPHuman += (int)heal;
			}
			heal = Enemies.HitPoints - m_HPDemon;
			heal = heal >= Enemies.RegenHP ? Enemies.RegenHP : heal;
			if (heal != 0)
			{
				m_HPDemon += (int)heal;
			}
		}

		/// <summary>
		/// Запись результатов симуляции
		/// </summary>
		private void RecordResults()
		{
			var results = new LinkedList<string>();
			results.AddLast("Среднее значение времени на один бой: " + ConvertParams(m_Sec, AmountFights));
			results.AddLast("Кол-во нанесенного человеком урона: " + m_ResultsAmountHumanDamage);
			results.AddLast("Кол-во нанесенного демонами урона: " + m_ResultsAmountDemonsDamage);
			results.AddLast("Средний урон человека в бой: " + ConvertParams(m_ResultsAmountHumanDamage, AmountFights));
			results.AddLast("Средний урон демонов в бой: " + ConvertParams(m_ResultsAmountDemonsDamage, AmountFights));
			results.AddLast("Урон человека в секунду: " + ConvertParams(m_ResultsAmountHumanDamage, m_Sec));
			results.AddLast("Урон демона в секунду: " + ConvertParams(m_ResultsAmountDemonsDamage, m_Sec));
			results.AddLast("Отношение атак к критам человека: " + ConvertParams(m_ResultsAmountHumanAttacks, m_ResultsAmountHumanCriticalAttacks));
			results.AddLast("Отношение атак к критам демонов: " + ConvertParams(m_ResultsAmountDemonsAttacks, m_ResultsAmountDemonsCriticalAttacks));
			results.AddLast("Средний полученный человеком урон в бой: " + ConvertParams(m_ResultsAmountDemonsDamage, AmountFights));
			results.AddLast("Средний полученный человеком урон в секунду: " + ConvertParams(m_ResultsAmountDemonsDamage, m_Sec));
			results.AddLast("Средний полученный демоном урон в бой: " + ConvertParams(m_ResultsAmountHumanDamage, AmountFights));
			results.AddLast("Средний полученный демоном урон в секунду: " + ConvertParams(m_ResultsAmountHumanDamage, m_Sec));
			results.AddLast("Кол-во побед героя: " + m_ResultsAmountHumanWins);
			results.AddLast("Кол-во поражений героя: " + m_ResultsAmountDemonsWins);
			results.AddLast("Винрейт героя в %: " + Math.Round((double)m_ResultsAmountHumanWins / AmountFights * 100, 2));

			Results = results;


			ClearResults();
		}

		/// <summary>
		/// Очистка результатов
		/// </summary>
		private void ClearResults()
		{
			m_Sec = 0;
			m_ResultsAmountHumanDamage = 0;
			m_ResultsAmountDemonsDamage = 0;
			m_ResultsAmountHumanAttacks = 0;
			m_ResultsAmountHumanCriticalAttacks = 0;
			m_ResultsAmountDemonsAttacks = 0;
			m_ResultsAmountDemonsCriticalAttacks = 0;
			m_ResultsAmountHumanWins = 0;
			m_ResultsAmountDemonsWins = 0;
	}

		/// <summary>
		/// Возвращает бинарное решение вероятности
		/// </summary>
		/// <param name="percent">Шнас события</param>
		/// <returns>true- если событие произошло</returns>
		private bool Random(double percent)
		{
			return percent * 100 >= c_Random.Next(0, 101);
		}

		/// <summary>
		/// Преобразует параметры для статистики симуляции
		/// </summary>
		/// <param name="first">Делимое число</param>
		/// <param name="second">Делитель</param>
		/// <returns>Результат с округлением</returns>
		private double ConvertParams(double first, double second)
		{
			if (first == 0 || second == 0) return 0;
			return Math.Round(first / second, 2);
		}
	}
}
