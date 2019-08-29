using System;
using System.Collections.Generic;
using System.ComponentModel;
using Game.Customization;

namespace Game.Units
{
	/// <summary>
	/// Игровые персонажи людей
	/// </summary>
	public abstract class Human : Unit, IUnitAttribute
	{
		/// <summary>
		/// Имя класса
		/// </summary>
		private readonly string c_Name;

		/// <summary>
		/// Генератор случайных чисел
		/// </summary>
		private readonly Random c_Random = new Random();

		/// <summary>
		/// Уровень героя
		/// </summary>
		[DefaultValue(0)]
		private int m_Level = 1;

		#region Суммы бонусов снаряжения

		/// <summary>
		/// Возвращает суммарное здоровье за одетую броню
		/// </summary>
		private double GetSumHitPoints => ArmorSuit.GetHitPoints(Head) + ArmorSuit.GetHitPoints(Body)
			+ ArmorSuit.GetHitPoints(Foots) + ArmorSuit.GetHitPoints(Legs) + ArmorSuit.GetHitPoints(Gloves);

		/// <summary>
		/// Возвращает суммарный шанс критического урона за одетую броню
		/// </summary>
		private double GetSumMulctCriticalDamage => 1.0 * ArmorSuit.GetMulctCriticalDamage(Head)
			* ArmorSuit.GetMulctCriticalDamage(Body) * ArmorSuit.GetMulctCriticalDamage(Foots)
			* ArmorSuit.GetMulctCriticalDamage(Legs) * ArmorSuit.GetMulctCriticalDamage(Gloves);

		/// <summary>
		/// Возвращает суммарный шанс промаха за одетую броню
		/// </summary>
		private double GetSumChanceSlip => ArmorSuit.GetChanceSlip(Head) + ArmorSuit.GetChanceSlip(Body)
			+ ArmorSuit.GetChanceSlip(Foots) + ArmorSuit.GetChanceSlip(Legs) + ArmorSuit.GetChanceSlip(Gloves);

		/// <summary>
		/// Возвращает суммарный штраф шанса уклонения за одетую броню
		/// </summary>
		private double GetSumMulctChanceEvasion => 1.0 * ArmorSuit.GetMulctChanceEvasion(Head)
			* ArmorSuit.GetMulctChanceEvasion(Body) * ArmorSuit.GetMulctChanceEvasion(Foots)
			* ArmorSuit.GetMulctChanceEvasion(Legs) * ArmorSuit.GetMulctChanceEvasion(Gloves);

		/// <summary>
		/// Возвращает суммарную броню за одетую броню
		/// </summary>
		private double GetSumArmor => ArmorSuit.GetArmor(Head) * ArmorSuit.GetArmor(Body)
			* ArmorSuit.GetArmor(Foots) * ArmorSuit.GetArmor(Legs) * ArmorSuit.GetArmor(Gloves);

		/// <summary>
		/// Возвращает суммарный штраф регенерации выносливости за одетую броню
		/// </summary>
		private double GetSumMulctSpeedAttack => 1.0 * ArmorSuit.GetMulctSpeedAttack(Head)
			* ArmorSuit.GetMulctSpeedAttack(Body) * ArmorSuit.GetMulctSpeedAttack(Foots)
			* ArmorSuit.GetMulctSpeedAttack(Legs) * ArmorSuit.GetMulctSpeedAttack(Gloves);

		#endregion



		#region Базовые для людей параметры

		/// <summary>
		/// Прирост силы
		/// </summary>
		protected readonly double c_AdditionStrength;

		/// <summary>
		/// Прирост ловкости
		/// </summary>
		protected readonly double c_AdditionAgility;

		/// <summary>
		/// Базовый показатель силы
		/// </summary>
		protected readonly double c_BaseStrength;

		/// <summary>
		/// Базовый показатель ловкости
		/// </summary>
		protected readonly double c_BaseAgility;

		/// <summary>
		/// Базовый показатель урона
		/// </summary>
		protected readonly double c_BaseDamage;

		/// <summary>
		/// Базовый показатель критического урона
		/// </summary>
		protected readonly double c_BaseCriticalDamage;

		#endregion

		#region Бонусные атрибуты

		/// <summary>
		/// Бонусный показатель жизней
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusHitPoints = 0;

		/// <summary>
		/// Бонусный показатель регенерации здоровья
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusRegenHP = 0;

		/// <summary>
		/// Бонусная скорость атаки
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusSpeedAttack = 0;

		/// <summary>
		/// Бонусный показатель шанса критического урона
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusChanceCriticalDamage = 0;

		/// <summary>
		/// Бонусный показатель шанса промаха
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusChanceSlip = 0;

		/// <summary>
		/// Бонусный показатель шанса уклонения
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusChanceEvasion = 0;

		/// <summary>
		/// Бонусный показатель брони
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusArmor = 0;

		/// <summary>
		/// Бонусный показатель урона
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusDamage = 0;

		/// <summary>
		/// Бонусный показатель критического урона
		/// </summary>
		[DefaultValue(0)]
		protected double m_BonusCriticalDamage = 0;

		#endregion



		#region Вывод индивидуальных для людей атрибутов

		/// <summary>
		/// Уровень юнита
		/// </summary>
		public int Level
		{
			get => m_Level;
			set
			{
				//Ограничение значение в радиусе от 1 до 30 уровней
				if (value < 1) m_Level = 1;
				if (value > 30) m_Level = 30;

				m_Level = value;
				RebuildBonusPoints();
			}
		}

		/// <summary>
		/// Опыт юнита
		/// </summary>
		public double Experience { get; }//Симуляция не поддерживает получение опыта

		/// <summary>
		/// Суммарная сила (базовая + за уровни)
		/// </summary>
		public double Strength => c_BaseStrength + m_Level * c_AdditionStrength;

		/// <summary>
		/// Суммарная ловкость (базовая + за уровни)
		/// </summary>
		public double Agility => c_BaseAgility + m_Level * c_AdditionAgility;

		/// <summary>
		/// Суммарный урон (базовый + за оружие + за очки совершенствования)
		/// </summary>
		public double Damage => c_BaseDamage + m_BonusDamage + Weapon.GetDamage(Weapon);

		/// <summary>
		/// Суммарный показатель критического урона ((базовый + за очки совершенствования + очки силы) * штраф брони)
		/// </summary>
		public double CriticalDamage => 
			(c_BaseCriticalDamage + m_BonusCriticalDamage + Strength * Balance.MultiCriticalDamage) * GetSumMulctCriticalDamage;



		#endregion

		#region Вывод общих для всех юнитов атрибутов

		/// <summary>
		/// Суммарное здоровье (базовый + за броню + за очки совершенствования + очки силы)
		/// </summary>
		public double HitPoints => c_BaseHitPoints + GetSumHitPoints + m_BonusHitPoints + Strength * Balance.MultiHitPoints;

		/// <summary>
		/// Суммарная регенерация здоровья (базовый + за очки совершенствования)
		/// </summary>
		public double RegenHP => c_BaseRegenHP + m_BonusRegenHP;

		/// <summary>
		/// Суммарная скорость атаки ((базовый - за очки совершенствования - за ловкость) * множитель за оружие * штраф за броню)
		/// </summary>
		public double SpeedAttack => (c_BaseSpeedAttack - m_BonusSpeedAttack - Agility * Balance.MultiSpeedAttack)
			* Weapon.GetFactorSpeedAttack(Weapon) * GetSumMulctSpeedAttack;

		/// <summary>
		/// Суммарный шанс критического урона (базовый + за очки совершенствования + за оружие)
		/// </summary>
		public double ChanceCriticalDamage => c_BaseChanceCriticalDamage + m_BonusChanceCriticalDamage + Weapon.GetChanceCriticalDamage(Weapon);

		/// <summary>
		/// Суммарный шанс промаха (базовый + за броню + за очки совершенствования)
		/// </summary>
		public double ChanceSlip => c_BaseChanceSlip + GetSumChanceSlip + m_BonusChanceSlip;

		/// <summary>
		/// Суммарный шанс уклонения (базовый + за очки совершенствования + за ловкость) * штраф брони * штраф за оружие )
		/// </summary>
		public double ChanceEvasion => (c_BaseChanceEvasion + m_BonusChanceEvasion + Agility * Balance.MultiChanceEvasion)
			* Weapon.GetMulctChanceEvasion(Weapon) * GetSumMulctChanceEvasion;

		/// <summary>
		/// Суммарная броня (базовый + за очки совершенствования) * за броню)
		/// </summary>
		public double Armor => c_BaseArmor + m_BonusArmor * GetSumArmor;

		#endregion

		#region Кастомизация персонажа

		/// <summary>
		/// Оружие
		/// </summary>
		public Weapon Weapon { get; set; }

		/// <summary>
		/// Голова
		/// </summary>
		public ArmorSuit Head { get; set; }

		/// <summary>
		/// Тело
		/// </summary>
		public ArmorSuit Body { get; set; }

		/// <summary>
		/// Ноги
		/// </summary>
		public ArmorSuit Legs { get; set; }

		/// <summary>
		/// Ступни
		/// </summary>
		public ArmorSuit Foots { get; set; }

		/// <summary>
		/// Перчатки
		/// </summary>
		public ArmorSuit Gloves { get; set; }

		#endregion



		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="strength">Базовая сила персонажа</param>
		/// <param name="agility">Базовая ловкость персонажа</param>
		/// <param name="damage">Базовый урон персонажа</param>
		/// <param name="criticalDamage">Базовый критический урон</param>
		/// <param name="additionStrength">Базовый прирост силы за уровень персонажа</param>
		/// <param name="additionAgility">Базовый прирост ловкости за уровень персонажа</param>
		/// <param name="name">Имя класса</param>
		/// <param name="hitPoints">Кол-во здоровья</param>
		/// <param name="RegenHP">Регенерация здоровья в ход</param>
		/// <param name="speedAttack">Скорость атаки</param>
		/// <param name="chanceCriticalDamage">Шанс критического удара</param>
		/// <param name="chanceSlip">Шанс промаха</param>
		/// <param name="chanceEvasion">Шанс уклонения</param>
		/// <param name="armor">Броня</param>
		public Human(double strength, double agility, double damage, double criticalDamage, double additionStrength,
			double additionAgility, string name, double hitPoints, double RegenHP, double speedAttack,
			double chanceCriticalDamage, double chanceSlip, double chanceEvasion, double armor) 
			: base(hitPoints, RegenHP, speedAttack,
			chanceCriticalDamage, chanceSlip, chanceEvasion, armor)
		{
			c_BaseStrength = strength;
			c_BaseAgility = agility;
			c_BaseDamage = damage;
			c_BaseCriticalDamage = criticalDamage;
			c_AdditionStrength = additionStrength;
			c_AdditionAgility = additionAgility;
			c_Name = name;
		}

		/// <summary>
		/// Производит распределение очков акцентировано
		/// </summary>
		/// <param name="level">Уровень прокачки</param>
		/// <returns>Массив распределенных очков</returns>
		private List<int> Build(int level)
		{
			m_Level = level;
			int points = m_Level * Balance.AmountPoints;

			//Собираем массив для распределение очков по основным веткам
			var attribute = new List<int>();
			for (var i = 0; i < 3; i++) attribute.Add(0);

			int index;
			//Пока : не кончились очки совершенствования и пока основные ветки не вкачены до максимума
			while (points > 0 && attribute[0] < Balance.LimitPoints 
				&& attribute[1] < Balance.LimitPoints && attribute[2] < Balance.LimitPoints)
			{
				index = c_Random.Next(0, 3);

				//Если : достигнут лимит вложения очков в параметр
				if (attribute[index] == Balance.LimitPoints)
				{
					continue;
				}

				attribute[index]++;

				points--;
			}

			//Добираем массив
			for (var i = 0; i < 7; i++) attribute.Add(0);

			//Если : остались свободные очки совершенствования
			if (points != 0)
			{
				for (; points > 0; points--)
				{
					index = c_Random.Next(3, 10);

					//Если : достигнут лимит вложения очков в параметр
					if (attribute[index] == Balance.LimitPoints)
					{
						points++;
						continue;
					}

					attribute[index]++;
				}
			}

			return attribute;
		}

		/// <summary>
		/// Прокачка героя в урон
		/// </summary>
		/// <param name="level">Уровень прокачки</param>
		public void SetDamageBuild(int level)
		{
			var attribute = Build(level);

			//Домножение распределенных очков
			m_BonusDamage = attribute[0] * Balance.FactorDamage;
			m_BonusCriticalDamage = attribute[1] * Balance.FactorCriticalDamage;
			m_BonusHitPoints = attribute[3] * Balance.FactorHitPoints;
			m_BonusRegenHP = attribute[4] * Balance.FactorRegenHP;
			m_BonusSpeedAttack = attribute[2] * Balance.FactorSpeedAttack;
			m_BonusChanceCriticalDamage = attribute[5] * Balance.FactorChanceCriticalDamage;
			m_BonusChanceSlip = attribute[6] * Balance.FactorChanceSlip;
			m_BonusChanceEvasion = attribute[7] * Balance.FactorChanceEvasion;
			m_BonusArmor = attribute[8] * Balance.FactorArmor;
		}

		/// <summary>
		/// Прокачка героя в выживаемость
		/// </summary>
		/// <param name="level">Уровень прокачки</param>
		public void SetSurvivalBuild(int level)
		{
			var attribute = Build(level);

			//Домножение распределенных очков
			m_BonusDamage = attribute[3] * Balance.FactorDamage;
			m_BonusCriticalDamage = attribute[4] * Balance.FactorCriticalDamage;
			m_BonusHitPoints = attribute[0] * Balance.FactorHitPoints;
			m_BonusRegenHP = attribute[1] * Balance.FactorRegenHP;
			m_BonusSpeedAttack = attribute[5] * Balance.FactorSpeedAttack;
			m_BonusChanceCriticalDamage = attribute[6] * Balance.FactorChanceCriticalDamage;
			m_BonusChanceSlip = attribute[7] * Balance.FactorChanceSlip;
			m_BonusChanceEvasion = attribute[8] * Balance.FactorChanceEvasion;
			m_BonusArmor = attribute[2] * Balance.FactorArmor;
		}

		/// <summary>
		/// Прокачка героя в искусность
		/// </summary>
		/// <param name="level">Уровень прокачки</param>
		public void SetAdroitnessBuild(int level)
		{
			var attribute = Build(level);

			//Домножение распределенных очков
			m_BonusDamage = attribute[3] * Balance.FactorDamage;
			m_BonusCriticalDamage = attribute[4] * Balance.FactorCriticalDamage;
			m_BonusHitPoints = attribute[5] * Balance.FactorHitPoints;
			m_BonusRegenHP = attribute[6] * Balance.FactorRegenHP;
			m_BonusSpeedAttack = attribute[2] * Balance.FactorSpeedAttack;
			m_BonusChanceCriticalDamage = attribute[1] * Balance.FactorChanceCriticalDamage;
			m_BonusChanceSlip = attribute[7] * Balance.FactorChanceSlip;
			m_BonusChanceEvasion = attribute[0] * Balance.FactorChanceEvasion;
			m_BonusArmor = attribute[8] * Balance.FactorArmor;
		}

		/// <summary>
		/// Прокачка героя прост)
		/// </summary>
		/// <param name="level">Уровень прокачки</param>
		public void SetDefaultBuild(int level)
		{
			var attribute = Build(level);

			//Домножение распределенных очков
			m_BonusDamage = attribute[0] * Balance.FactorDamage;
			m_BonusCriticalDamage = attribute[3] * Balance.FactorCriticalDamage;
			m_BonusHitPoints = attribute[2] * Balance.FactorHitPoints;
			m_BonusRegenHP = attribute[4] * Balance.FactorRegenHP;
			m_BonusSpeedAttack = attribute[5] * Balance.FactorSpeedAttack;
			m_BonusChanceCriticalDamage = attribute[6] * Balance.FactorChanceCriticalDamage;
			m_BonusChanceSlip = attribute[1] * Balance.FactorChanceSlip;
			m_BonusChanceEvasion = attribute[7] * Balance.FactorChanceEvasion;
			m_BonusArmor = attribute[8] * Balance.FactorArmor;
		}

		/// <summary>
		/// В случайном порядке распределяет очки совершенствования
		/// </summary>
		private void RebuildBonusPoints()
		{

			//Собираем массив для распределение очков
			var attribute = new List<int>();
			for (var i = 0; i < 10; i++) attribute.Add(0);

			//Распределение очков совершенствования
			for (int points = m_Level * Balance.AmountPoints, index; points > 0; points--)
			{
				index = c_Random.Next(0, 9);

				//Если : достигнут лимит вложения очков в параметр
				if (attribute[index] == Balance.LimitPoints)
				{
					points++;
					continue;
				}

				attribute[index]++;
			}

			//Домножение распределенных очков
			m_BonusDamage = attribute[0] * Balance.FactorDamage;
			m_BonusCriticalDamage = attribute[1] * Balance.FactorCriticalDamage;
			m_BonusHitPoints = attribute[2] * Balance.FactorHitPoints;
			m_BonusRegenHP = attribute[3] * Balance.FactorRegenHP;
			m_BonusSpeedAttack = attribute[4] * Balance.FactorSpeedAttack;
			m_BonusChanceCriticalDamage = attribute[5] * Balance.FactorChanceCriticalDamage;
			m_BonusChanceSlip = attribute[6] * Balance.FactorChanceSlip;
			m_BonusChanceEvasion = attribute[7] * Balance.FactorChanceEvasion;
			m_BonusArmor = attribute[8] * Balance.FactorArmor;
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
	/// Бонусы для людей
	/// </summary>
	[Flags]
	public enum Extra
	{
		None = 0x0,

		/// <summary>
		/// Скорость атаки
		/// </summary>
		SpeedAttack = 0x1,

		/// <summary>
		/// Множитель крита
		/// </summary>
		CriticalDamage = 0x2,

		/// <summary>
		/// Регенерация
		/// </summary>
		Regen = 0x4,

		/// <summary>
		/// Шанс промаха
		/// </summary>
		ChanceSlip = 0x8
	}
}
