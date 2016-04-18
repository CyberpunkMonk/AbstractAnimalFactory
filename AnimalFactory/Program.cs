using System;

namespace AnimalFactory {
	/// <summary>
	/// MainApp startup class for Abstract Factory Design Pattern
	/// </summary>
	class MainApp {
		/// <summary>
		/// Entry point into comsole application
		/// </summary>
		public static void Main() {
			//Create and run the African animal world
			ContinentFactory africa = new AfricaFactory();
			AnimalWorld world = new AnimalWorld(africa);
			world.RunFoodChain();

			//Create and run the American animal world
			ContinentFactory america = new AmericaFactory();
			world = new AnimalWorld(america);
			world.RunFoodChain();
		}
	}

	/// <summary>
	/// The AbstractFactory" abstract class
	/// </summary>
	abstract class ContinentFactory {
		public abstract Herbivore CreateHerbivore();
		public abstract Carnivore CreateCarnivore();
	}


	/// <summary>
	/// The "AnimalFactory" class
	/// </summary>
	/// <seealso cref="AnimalFactory.ContinentFactory" />
	class AfricaFactory:ContinentFactory{
		public override Herbivore CreateHerbivore() {
			return new Wildebeest();
		}
		public override Carnivore CreateCarnivore() {
			return new Lion();
		}
	}

	/// <summary>
	/// The "AmericaFactory" class
	/// </summary>
	/// <seealso cref="AnimalFactory.ContinentFactory" />
	class AmericaFactory : ContinentFactory {
		public override Herbivore CreateHerbivore() {
			return new Bison();
		}
		public override Carnivore CreateCarnivore() {
			return new Wolf();
		}
	}

	/// <summary>
	/// The "Herbivore" abstract class
	/// </summary>
	abstract class Herbivore { }

	/// <summary>
	/// the "Carnivore" abstract class
	/// </summary>
	abstract class Carnivore {
		public abstract void Eat(Herbivore h);
	}

	/// <summary>
	/// The "Wildebeest" class
	/// </summary>
	/// <seealso cref="AnimalFactory.Herbivore" />
	class Wildebeest : Herbivore { }

	/// <summary>
	/// The "Lion" class
	/// </summary>
	/// <seealso cref="AnimalFactory.Carnivore" />
	class Lion : Carnivore {
		public override void Eat(Herbivore h) {
			Console.WriteLine(this.GetType().Name+" eats "+h.GetType().Name);
		}
	}

	/// <summary>
	/// The "Bison" class
	/// </summary>
	/// <seealso cref="AnimalFactory.Herbivore"/>
	class Bison : Herbivore {}

	/// <summary>
	/// The "Wolf" class
	/// </summary>
	/// <seealso cref="AnimalFactory.Carnivore"/>
	class Wolf : Carnivore {
		public override void Eat(Herbivore h) {
			Console.WriteLine(this.GetType().Name+" eats "+h.GetType().Name);
		}
	}

	/// <summary>
	/// The "AnimalWorld" class
	/// </summary>
	class AnimalWorld {
		private Herbivore _herbivore;
		private Carnivore _carnivore;

		//Constructor
		public AnimalWorld(ContinentFactory factory) {
			_carnivore = factory.CreateCarnivore();
			_herbivore = factory.CreateHerbivore();
		}

		public void RunFoodChain() {
			_carnivore.Eat(_herbivore);
		}
	}
}