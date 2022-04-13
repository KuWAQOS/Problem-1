class Animal
{
    string name;
    string animalClass;
    int weight;
    public Animal() { }
    public Animal(string _name, string _animalclass, int _weight)
    {
        Name = _name;
        AnimalClass = _animalclass;
        Weight = _weight;
    }

    public void Show() 
    {
        Console.WriteLine("Наименование - "+Name);
        Console.WriteLine("Класс - " + AnimalClass);
        Console.WriteLine("Ср. вес - " + Weight);
    }

    public void ChangeData() 
    {
        Console.WriteLine("Изменить имя животного на:");
        Name = Console.ReadLine();
        Console.WriteLine("Изменить класс животного на:");
        AnimalClass = Console.ReadLine();
        Console.WriteLine("Изменить ср. вес животного на:");
        Weight =Convert.ToInt32(Console.ReadLine());
    }

    public void SaveData(string path) 
    {
        StreamWriter sw = new StreamWriter(path, true);
        sw.WriteLine("Наименование:"+ Name+"\nКласс животного: "+AnimalClass+"\nСредний вес: "+Weight);
        sw.Close();
    }


    public static Animal operator +(Animal obj1, Animal obj2)
    {
        Animal any = new Animal();
        any.Weight = obj1.Weight + obj2.Weight;
        any.Name = obj1.Name +" "+ obj2.Name;
        any.AnimalClass = obj1.AnimalClass +" "+ obj2.AnimalClass;
        return any;
    }

    public static bool operator <(Animal obj1, Animal obj2)
    {
        if (obj1.Weight < obj2.Weight)
        {
            return true;
        }
        return false;
    }

    public static bool operator >(Animal obj1, Animal obj2)
    {
        if (obj1.Weight > obj2.Weight)
        {
            return true;
        }
        return false;
    }


    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public string AnimalClass
    {
        get
        {
            return animalClass;
        }
        set
        {
            if (value =="лев")
            {
                Console.WriteLine("Арррргхх!");
            }
            if (value == "корова")
            {
                Console.WriteLine("Мууууу!");
            }
            animalClass = value;
        }
    }
    public int Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
            else
            {
                throw new Exception("Вес должен быть больше 0");
            }
        }
    }
}
    class Program 
{
    static void Main(string []args) 
    {
        string path = @"C:\Users\Maxim\Desktop\save.txt";
        Animal any1 = new Animal();     //Конструктор без параметров

        any1.ChangeData();
        any1.Show();
        any1.SaveData(path);

        string name = "Лев";
        string animalclass = "Кошачьи";
        int weight = 190;
        Console.WriteLine();

        Animal any2 = new Animal( name, animalclass, weight); //Конструктор с параметрами
        any2.Show();
        any2.ChangeData();
        any2.SaveData(path);

        Animal any3 = new Animal();                         //Конструктор без параметров
        any3 = any1 + any2;                                //Получает свои данные на основе сложения двух предыдущи обхектов
        any3.Show();                                         //Вывод данных
        
        Console.WriteLine("EleLion>Elephant?\n" + (any3 > any2));      //Перегрузка сравнения

    }
}