using Game.Customization;
using Game.Pools;
using Game.Units;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Game
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Арена для спарингов
		/// </summary>
		private readonly Arena m_Arena = new Arena();

		#region Коллекции элементов игры

		/// <summary>
		/// Коллекция классов людей
		/// </summary>
		private readonly ReadOnlyCollection<Human> c_Humans;

		/// <summary>
		/// Коллекция классов демонов
		/// </summary>
		private readonly ReadOnlyCollection<Demon> c_Demons;

		/// <summary>
		/// Коллекция оружия
		/// </summary>
		private readonly ReadOnlyCollection<Weapon> c_Weapons;

		/// <summary>
		/// Коллекция шлемов
		/// </summary>
		private readonly ReadOnlyCollection<Helmet> c_Helmets;

		/// <summary>
		/// Коллекция доспехов
		/// </summary>
		private readonly ReadOnlyCollection<Armour> c_Armours;

		/// <summary>
		/// Коллекция обуви
		/// </summary>
		private readonly ReadOnlyCollection<Shoes> c_Shoes;

		/// <summary>
		/// Коллекция брюк
		/// </summary>
		private readonly ReadOnlyCollection<Breeches> c_Breeches;

		/// <summary>
		/// Коллекция перчаток
		/// </summary>
		private readonly ReadOnlyCollection<Gloves> c_Gloves;

		#endregion

		/// <summary>
		/// Конструктор приложения
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();

			#region Сборка классов юнитов

			var humans = new List<Human>(3)
			{
				UnitPool.Marine,
				UnitPool.Saboteur,
				UnitPool.Agent
			};

			c_Humans = humans.AsReadOnly();

			var demons = new List<Demon>(5)
			{
				UnitPool.Minion,
				UnitPool.Scavenger,
				UnitPool.Hound,
				UnitPool.Marauder,
				UnitPool.MassiveAbsorber
			};

			c_Demons = demons.AsReadOnly();

			#endregion

			#region Сборка кастомизации

			var weapons = new List<Weapon>(8)
			{
				WeaponPool.IronSword,
				WeaponPool.IronAxe,
				WeaponPool.IronDagger,
				WeaponPool.IronMace,
				WeaponPool.SteelSword,
				WeaponPool.SteelAxe,
				WeaponPool.SteelDagger,
				WeaponPool.SteelMace
			};

			c_Weapons = weapons.AsReadOnly();

			var helmets = new List<Helmet>(3)
			{
				ArmorPool.IronHelmet,
				ArmorPool.SteelHelmet,
				ArmorPool.TitaniumHelmet
			};

			c_Helmets = helmets.AsReadOnly();

			var armours = new List<Armour>(3)
			{
				ArmorPool.IronArmour,
				ArmorPool.SteelArmour,
				ArmorPool.TitaniumArmour
			};

			c_Armours = armours.AsReadOnly();

			var shoes = new List<Shoes>(3)
			{
				ArmorPool.LeathernShoes,
				ArmorPool.RivetedShoes,
				ArmorPool.ScalyShoes
			};

			c_Shoes = shoes.AsReadOnly();

			var breeches = new List<Breeches>(2)
			{
				ArmorPool.LeathernBreeches,
				ArmorPool.RivetedBreeches,
			};

			c_Breeches = breeches.AsReadOnly();

			var gloves = new List<Gloves>(2)
			{
				ArmorPool.LeathernGloves,
				ArmorPool.RivetedGloves,
			};

			c_Gloves = gloves.AsReadOnly();

			#endregion

			BuildComboBoxes();

			//Подписка на выбор сценария
			m_ScreenplayComboBox.SelectionChanged += (q, qq) => { SelectScreenplay((Screenplay)m_ScreenplayComboBox.SelectedIndex); };
			//Растягивание панели по ширине окна
			SizeChanged += (q, qq) => { m_DockPanel.Width = Width; };
		}

		/// <summary>
		/// Сборка всех комбо боксов
		/// </summary>
		private void BuildComboBoxes()
		{
			//Класс для людей
			m_ClassHumanComboBox.ItemsSource = c_Humans.Select(t => t.ToString());
			m_ClassHumanComboBox.SelectedIndex = 0;

			//Класс для демонов
			m_ClassDemonComboBox.ItemsSource = c_Demons.Select(t => t.ToString());
			m_ClassDemonComboBox.SelectedIndex = 0;

			//Уровни для людей
			var collection = new List<string>(30);
			for (var i = 0; i < 30; i++) collection.Add((i + 1).ToString());
			m_LevelComboBox.ItemsSource = collection;
			m_ClassDemonComboBox.SelectedIndex = 0;

			//Оружие
			collection = new List<string>(9);
			collection.Add("Отсутствует");
			m_WeaponComboBox.ItemsSource = collection.Concat(c_Weapons.Select(t => t.ToString()));
			m_WeaponComboBox.SelectedIndex = 0;

			//Голова
			collection = new List<string>(4);
			collection.Add("Отсутствует");
			m_HeadComboBox.ItemsSource = collection.Concat(c_Helmets.Select(t => t.ToString()));
			m_HeadComboBox.SelectedIndex = 0;

			//Тело
			collection = new List<string>(4);
			collection.Add("Отсутствует");
			m_BodyComboBox.ItemsSource = collection.Concat(c_Armours.Select(t => t.ToString()));
			m_BodyComboBox.SelectedIndex = 0;

			//Ноги
			collection = new List<string>(4);
			collection.Add("Отсутствует");
			m_FootsComboBox.ItemsSource = collection.Concat(c_Shoes.Select(t => t.ToString()));
			m_FootsComboBox.SelectedIndex = 0;

			//Брюки
			collection = new List<string>(3);
			collection.Add("Отсутствует");
			m_LegsComboBox.ItemsSource = collection.Concat(c_Breeches.Select(t => t.ToString()));
			m_LegsComboBox.SelectedIndex = 0;

			//Руки
			collection = new List<string>(3);
			collection.Add("Отсутствует");
			m_GlovesComboBox.ItemsSource = collection.Concat(c_Gloves.Select(t => t.ToString()));
			m_GlovesComboBox.SelectedIndex = 0;

			#region Ручное заполнение

			//Сценарии
			collection = new List<string>(12);

			collection.Add("Слабый урон");
			collection.Add("Средний урон");
			collection.Add("Сильный урон");
			collection.Add("Слабая выживаемость");
			collection.Add("Средняя выживаемость");
			collection.Add("Сильная выживаемость");
			collection.Add("Слабая искусность");
			collection.Add("Средняя искусность");
			collection.Add("Сильная искусность");
			collection.Add("Слабая стандартная");
			collection.Add("Средняя стандартная");
			collection.Add("Сильная стандартная");

			m_ScreenplayComboBox.ItemsSource = collection;


			//Бонусы
			collection = new List<string>(5);
			collection.Add("Отсутствует");
			collection.Add("Скорость атаки");
			collection.Add("Множитель крита");
			collection.Add("Регенерация");
			collection.Add("Шанс промаха");
			m_GlovesComboBox.ItemsSource = collection;
			m_GlovesComboBox.SelectedIndex = 0;

			#endregion
		}

		/// <summary>
		/// Установка параметров боя на основе сценария
		/// </summary>
		/// <param name="screenplay">Выбранный сценарий</param>
		private void SelectScreenplay(Screenplay screenplay)
		{
			//Кол-во симуляций в сценариях фиксировано
			m_AmountSimulationTextBox.Text = 15.ToString();

			//Подстройка под выбранный сценарий
			switch (screenplay)
			{
				case Screenplay.LowLvlDamage:
					m_ClassHumanComboBox.SelectedIndex = 2;
					m_LevelComboBox.SelectedIndex = 9;
					c_Humans[2].SetDamageBuild(10);
					m_WeaponComboBox.SelectedIndex = 1;//Железный топор
					m_HeadComboBox.SelectedIndex = 1;//Железный шлем
					m_BodyComboBox.SelectedIndex = 1;//Железный доспех
					m_FootsComboBox.SelectedIndex = 1;//Кожанные берцы
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 0; //Без перчаток
					m_ClassDemonComboBox.SelectedIndex = 0;//Миньон
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.MediumLvlDamage:
					m_ClassHumanComboBox.SelectedIndex = 2;
					m_LevelComboBox.SelectedIndex = 19;
					c_Humans[2].SetDamageBuild(20);
					m_WeaponComboBox.SelectedIndex = 1;//Железный топор
					m_HeadComboBox.SelectedIndex = 2;//Стальной шлем
					m_BodyComboBox.SelectedIndex = 2;//Стальной доспех
					m_FootsComboBox.SelectedIndex = 2;//Клепанные сапоги
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 1; //Кожанные перчатки
					m_ClassDemonComboBox.SelectedIndex = 2;//Гончий
					m_AdaptationCheckBox.IsChecked = true;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.HighLvlDamage:
					m_ClassHumanComboBox.SelectedIndex = 2;
					m_LevelComboBox.SelectedIndex = 29;
					c_Humans[2].SetDamageBuild(30);
					m_WeaponComboBox.SelectedIndex = 5;//Стальной топор
					m_HeadComboBox.SelectedIndex = 3;//Титановый шлем
					m_BodyComboBox.SelectedIndex = 3;//Титановый доспех
					m_FootsComboBox.SelectedIndex = 3;//Чашуйчатые ботинки
					m_LegsComboBox.SelectedIndex = 2;//Чашуйчатые штаны
					m_GlovesComboBox.SelectedIndex = 2; //Чашуйчатые перчатки
					m_ClassDemonComboBox.SelectedIndex = 3;//Мародер
					m_AdaptationCheckBox.IsChecked = true;
					m_AdditionalOrgansCheckBox.IsChecked = true;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.LowLvlSurvival:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 9;
					c_Humans[0].SetDamageBuild(10);
					m_WeaponComboBox.SelectedIndex = 3;//Железная булава
					m_HeadComboBox.SelectedIndex = 1;//Железный шлем
					m_BodyComboBox.SelectedIndex = 1;//Железный доспех
					m_FootsComboBox.SelectedIndex = 1;//Кожанные берцы
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 0; //Без перчаток
					m_ClassDemonComboBox.SelectedIndex = 0;//Миньон
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.MediumLvlSurvival:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 19;
					c_Humans[0].SetDamageBuild(20);
					m_WeaponComboBox.SelectedIndex = 3;//Железная булава
					m_HeadComboBox.SelectedIndex = 2;//Стальной шлем
					m_BodyComboBox.SelectedIndex = 2;//Стальной доспех
					m_FootsComboBox.SelectedIndex = 2;//Клепанные сапоги
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 1; //Кожанные перчатки
					m_ClassDemonComboBox.SelectedIndex = 2;//Гончий
					m_BurningClawsCheckBox.IsChecked = true;
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.HighLvlSurvival:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 29;
					c_Humans[0].SetDamageBuild(30);
					m_WeaponComboBox.SelectedIndex = 7;//Стальная булава
					m_HeadComboBox.SelectedIndex = 3;//Титановый шлем
					m_BodyComboBox.SelectedIndex = 3;//Титановый доспех
					m_FootsComboBox.SelectedIndex = 3;//Чашуйчатые ботинки
					m_LegsComboBox.SelectedIndex = 2;//Чашуйчатые штаны
					m_GlovesComboBox.SelectedIndex = 2; //Чашуйчатые перчатки
					m_ClassDemonComboBox.SelectedIndex = 3;//Мародер
					m_BurningClawsCheckBox.IsChecked = true;
					m_SpikeClawsCheckBox.IsChecked = true;
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.LowLvlAdroitness:
					m_ClassHumanComboBox.SelectedIndex = 1;
					m_LevelComboBox.SelectedIndex = 9;
					c_Humans[1].SetDamageBuild(10);
					m_WeaponComboBox.SelectedIndex = 2;//Железный кинжал
					m_HeadComboBox.SelectedIndex = 1;//Железный шлем
					m_BodyComboBox.SelectedIndex = 1;//Железный доспех
					m_FootsComboBox.SelectedIndex = 1;//Кожанные берцы
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 0; //Без перчаток
					m_ClassDemonComboBox.SelectedIndex = 0;//Миньон
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.MediumLvlAdroitness:
					m_ClassHumanComboBox.SelectedIndex = 1;
					m_LevelComboBox.SelectedIndex = 19;
					c_Humans[1].SetDamageBuild(20);
					m_WeaponComboBox.SelectedIndex = 2;//Железный кинжал
					m_HeadComboBox.SelectedIndex = 2;//Стальной шлем
					m_BodyComboBox.SelectedIndex = 2;//Стальной доспех
					m_FootsComboBox.SelectedIndex = 2;//Клепанные сапоги
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 1; //Кожанные перчатки
					m_ClassDemonComboBox.SelectedIndex = 2;//Гончий
					m_BurningClawsCheckBox.IsChecked = true;
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.HighLvlAdroitness:
					m_ClassHumanComboBox.SelectedIndex = 1;
					m_LevelComboBox.SelectedIndex = 29;
					c_Humans[1].SetDamageBuild(30);
					m_WeaponComboBox.SelectedIndex = 6;//Стальной кинжал
					m_HeadComboBox.SelectedIndex = 3;//Титановый шлем
					m_BodyComboBox.SelectedIndex = 3;//Титановый доспех
					m_FootsComboBox.SelectedIndex = 3;//Чашуйчатые ботинки
					m_LegsComboBox.SelectedIndex = 2;//Чашуйчатые штаны
					m_GlovesComboBox.SelectedIndex = 2; //Чашуйчатые перчатки
					m_ClassDemonComboBox.SelectedIndex = 3;//Мародер
					m_BurningClawsCheckBox.IsChecked = true;
					m_AdditionalOrgansCheckBox.IsChecked = true;
					m_AdaptationCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.LowLvlDefault:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 9;
					c_Humans[0].SetDamageBuild(10);
					m_WeaponComboBox.SelectedIndex = 0;//Железный меч
					m_HeadComboBox.SelectedIndex = 1;//Железный шлем
					m_BodyComboBox.SelectedIndex = 1;//Железный доспех
					m_FootsComboBox.SelectedIndex = 1;//Кожанные берцы
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 0; //Без перчаток
					m_ClassDemonComboBox.SelectedIndex = 0;//Миньон
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.MediumLvlDefault:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 19;
					c_Humans[0].SetDamageBuild(20);
					m_WeaponComboBox.SelectedIndex = 0;//Железный меч
					m_HeadComboBox.SelectedIndex = 2;//Стальной шлем
					m_BodyComboBox.SelectedIndex = 2;//Стальной доспех
					m_FootsComboBox.SelectedIndex = 2;//Клепанные сапоги
					m_LegsComboBox.SelectedIndex = 1;//Кожанные штаны
					m_GlovesComboBox.SelectedIndex = 1; //Кожанные перчатки
					m_ClassDemonComboBox.SelectedIndex = 2;//Гончий
					m_AdaptationCheckBox.IsChecked = true;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_BurningClawsCheckBox.IsChecked = false;
					m_SpikeClawsCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
				case Screenplay.HighLvlDefault:
					m_ClassHumanComboBox.SelectedIndex = 0;
					m_LevelComboBox.SelectedIndex = 29;
					c_Humans[0].SetDamageBuild(30);
					m_WeaponComboBox.SelectedIndex = 4;//Стальной меч
					m_HeadComboBox.SelectedIndex = 3;//Титановый шлем
					m_BodyComboBox.SelectedIndex = 3;//Титановый доспех
					m_FootsComboBox.SelectedIndex = 3;//Чашуйчатые ботинки
					m_LegsComboBox.SelectedIndex = 2;//Чашуйчатые штаны
					m_GlovesComboBox.SelectedIndex = 2; //Чашуйчатые перчатки
					m_ClassDemonComboBox.SelectedIndex = 3;//Мародер
					m_BurningClawsCheckBox.IsChecked = true;
					m_SpikeClawsCheckBox.IsChecked = true;
					m_AdaptationCheckBox.IsChecked = false;
					m_AdditionalOrgansCheckBox.IsChecked = false;
					m_ExtraSpeedAttackCheckBox.IsChecked = false;
					m_ExtraRegenCheckBox.IsChecked = false;
					m_ExtraCriticalDamageCheckBox.IsChecked = false;
					m_ExtraChanceSlipCheckBox.IsChecked = false;
					break;
			}

			SetParamsFight();

			m_Arena.StartBattle();
			CheckResults();
		}

		/// <summary>
		/// Запуск симуляции
		/// </summary>
		/// <param name="sender">объект</param>
		/// <param name="e">событие</param>
		private void OnStartSimulationButton_Click(object sender, RoutedEventArgs e)
		{
			SetParamsFight();

			//Прокачка персонажа до указанного уровня
			m_Arena.Player.Level = Convert.ToInt32(m_LevelComboBox.SelectedItem);
			//System.Windows.Controls.ListBox
			m_Arena.StartBattle();

			CheckResults();
		}

		/// <summary>
		/// Показывает бой, под указанным номером
		/// </summary>
		/// <param name="sender">Объект</param>
		/// <param name="e">Событие</param>
		private void OnShowFightButton_Click(object sender, RoutedEventArgs e)
		{
			int index;
			try
			{
				index = Convert.ToInt32(m_NumFightTextBox.Text) - 1;
			}
			catch { return; }

			var massString = m_Arena.Replays[index];

			var stackPanel = new StackPanel() { Orientation = Orientation.Vertical };
			foreach (var String in massString)
			{
				stackPanel.Children.Add(new Label() { FontSize = 16, Content = String });
			}
			m_Scroll.Content = stackPanel;
		}

		/// <summary>
		/// Устанавливаем основные параметры для боя
		/// </summary>
		private void SetParamsFight()
		{
			try
			{
				//Кол-во симуляций
				m_Arena.AmountFights = Convert.ToInt32(m_AmountSimulationTextBox.Text);

				var human = c_Humans[m_ClassHumanComboBox.SelectedIndex];
				//Вооружение персонажа
				var index = m_WeaponComboBox.SelectedIndex - 1;
				human.Weapon = index == -1 ? null : c_Weapons[index];
				//Одеваем персонажа
				index = m_HeadComboBox.SelectedIndex - 1;
				human.Head = index == -1 ? null : c_Helmets[index];
				index = m_BodyComboBox.SelectedIndex - 1;
				human.Body = index == -1 ? null : c_Armours[index];
				index = m_FootsComboBox.SelectedIndex - 1;
				human.Foots = index == -1 ? null : c_Shoes[index];
				index = m_LegsComboBox.SelectedIndex - 1;
				human.Legs = index == -1 ? null : c_Breeches[index];
				index = m_GlovesComboBox.SelectedIndex - 1;
				human.Gloves = index == -1 ? null : c_Gloves[index];
				m_Arena.Player = human;

				var enemies = c_Demons[m_ClassDemonComboBox.SelectedIndex];
				//Установка модификаций
				ModificationDemon modification = ModificationDemon.None;
				if (m_AdaptationCheckBox.IsChecked == true) modification |= ModificationDemon.Adaptation;
				if (m_BurningClawsCheckBox.IsChecked == true) modification |= ModificationDemon.BurningClaws;
				if (m_SpikeClawsCheckBox.IsChecked == true) modification |= ModificationDemon.SpikeClaws;
				if (m_AdditionalOrgansCheckBox.IsChecked == true) modification |= ModificationDemon.AdditionalOrgans;
				enemies.Modification = modification;
				m_Arena.Enemies = enemies;
				Extra extra = Extra.None;
				if (m_ExtraSpeedAttackCheckBox.IsChecked == true) extra |= Extra.SpeedAttack;
				if (m_ExtraRegenCheckBox.IsChecked == true) extra |= Extra.Regen;
				if (m_ExtraCriticalDamageCheckBox.IsChecked == true) extra |= Extra.CriticalDamage;
				if (m_ExtraChanceSlipCheckBox.IsChecked == true) extra |= Extra.ChanceSlip;
			}
			catch (Exception ex)
			{
				var type = ex.GetType();
				var message = ex.Message;
				return;
			}
		}

		/// <summary>
		/// Вывод результатов боя
		/// </summary>
		private void CheckResults()
		{
			#region Параметры человека

			var list = new LinkedList<string>();

			list.AddLast("");
			list.AddLast("----------------Персональные параметры----------------");
			list.AddLast("Сила:   " + Math.Round(m_Arena.Player.Strength));
			list.AddLast("Ловкость:   " + Math.Round(m_Arena.Player.Agility));
			list.AddLast("Урон:   " + Math.Round(m_Arena.Player.Damage));
			list.AddLast("Критический урон:   " + Math.Round(m_Arena.Player.CriticalDamage));
			list.AddLast("");
			list.AddLast("----------------Общие параметры----------------");
			list.AddLast("Здоровье:   " + Math.Round(m_Arena.Player.HitPoints));
			list.AddLast("Регенерация здоровья:   " + Math.Round(m_Arena.Player.RegenHP));
			list.AddLast("Скорость атаки в сек:   " + Math.Round(m_Arena.Player.SpeedAttack));
			list.AddLast("Шанс критического урона в %:   " + Math.Round(m_Arena.Player.ChanceCriticalDamage * 100, 2));
			list.AddLast("Шанс промаха в %:   " + Math.Round(m_Arena.Player.ChanceSlip * 100, 2));
			list.AddLast("Шанс уклонения в %:   " + Math.Round(m_Arena.Player.ChanceEvasion * 100, 2));
			list.AddLast("Броня:   " + Math.Round(m_Arena.Player.Armor));

			m_ParamsHumanListBox.ItemsSource = list;

			#endregion

			#region Параметры демонов

			list = new LinkedList<string>();

			list.AddLast("");
			list.AddLast("----------------Персональные параметры----------------");
			list.AddLast("Похищение жизней:   " + Math.Round(m_Arena.Enemies.LifeSteal));
			list.AddLast("Урон в %:   " + Math.Round(m_Arena.Enemies.PercentDamage * 100, 2));
			list.AddLast("Критический урон в %:   " + Math.Round(m_Arena.Enemies.PercentCriticalDamage * 100, 2));
			list.AddLast("");
			list.AddLast("----------------Общие параметры----------------");
			list.AddLast("Здоровье:   " + Math.Round(m_Arena.Enemies.HitPoints));
			list.AddLast("Регенерация здоровья:   " + Math.Round(m_Arena.Enemies.RegenHP));
			list.AddLast("Скорость атаки в сек:   " + Math.Round(m_Arena.Enemies.SpeedAttack));
			list.AddLast("Шанс критического урона в %:   " + Math.Round(m_Arena.Enemies.ChanceCriticalDamage * 100, 2));
			list.AddLast("Шанс промаха в %:   " + Math.Round(m_Arena.Enemies.ChanceSlip * 100, 2));
			list.AddLast("Шанс уклонения в %:   " + Math.Round(m_Arena.Enemies.ChanceEvasion * 100, 2));
			list.AddLast("Броня:   " + Math.Round(m_Arena.Enemies.Armor));

			m_ParamsDemonsListBox.ItemsSource = list;

			#endregion

			m_ResultsListBox.ItemsSource = m_Arena.Results;

			var massString = m_Arena.Replays[Convert.ToInt32(m_NumFightTextBox.Text) - 1];

			var stackPanel = new StackPanel() { Orientation = Orientation.Vertical };
			foreach(var String in massString)
			{
				stackPanel.Children.Add(new Label() { FontSize = 16, Content = String });
			}
			m_Scroll.Content = stackPanel;
		}

		/// <summary>
		/// Перечисление различных сценариев
		/// </summary>
		private enum Screenplay : int
		{
			/// <summary>
			/// Агент- Урон/Шанс критов/Крит урон 10 уровень
			/// </summary>
			LowLvlDamage = 0,

			/// <summary>
			/// Агент- Урон/Шанс критов/Крит урон 20 уровень
			/// </summary>
			MediumLvlDamage = 1,

			/// <summary>
			/// Агент- Урон/Шанс критов/Крит урон 30 уровень
			/// </summary>
			HighLvlDamage = 2,

			/// <summary>
			/// Морпех- Здоровье/Реген/Броня 10 уровень
			/// </summary>
			LowLvlSurvival = 3,

			/// <summary>
			/// Морпех- Здоровье/Реген/Броня 20 уровень
			/// </summary>
			MediumLvlSurvival = 4,

			/// <summary>
			/// Морпех- Здоровье/Реген/Броня 30 уровень
			/// </summary>
			HighLvlSurvival = 5,

			/// <summary>
			/// Диверсант- Шанс уклонения/Шанс критов/криты 10 уровень
			/// </summary>
			LowLvlAdroitness = 6,

			/// <summary>
			/// Диверсант- Шанс уклонения/Шанс критов/криты 20 уровень
			/// </summary>
			MediumLvlAdroitness = 7,

			/// <summary>
			/// Диверсант- Шанс уклонения/Шанс критов/криты 30 уровень
			/// </summary>
			HighLvlAdroitness = 8,

			/// <summary>
			/// Морпех- Урон/Шанс промаха/Здоровье 10 уровень
			/// </summary>
			LowLvlDefault = 9,

			/// <summary>
			/// Морпех- Урон/Шанс промаха/Здоровье 20 уровень
			/// </summary>
			MediumLvlDefault = 10,

			/// <summary>
			/// Морпех- Урон/Шанс промаха/Здоровье 30 уровень
			/// </summary>
			HighLvlDefault = 11,
		}
	}
}
