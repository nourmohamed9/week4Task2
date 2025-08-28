namespace week4Task1
{
  public  class Acount
    {
        public string name;
        public double balance;

        public Acount(string name="unnamed acount", double balance=0)
        {
            this.name = name;
            this.balance = balance;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Balance
        {
            get { return balance; }
         private  set { balance = value; }
        }
        public virtual bool Deposite(double amount)
        {
            if (amount < 0)
                return false;
            balance += amount;
            return true;
        }
        public virtual bool Withdraw(double amount)
        {
            if (amount > balance)
                return false;
            balance -= amount;
            return true;
        }
        public virtual double GetBalance()
        {
            return balance;
        }
        public virtual String Details()
        {
            return "[Acount :" +name + ":" + balance;
        }
        public override string ToString()
        {
            return Details();
        }
    }
   public class SavingAcount : Acount
    {
        public SavingAcount(string name = "unnamed acount", double balance = 0, double intersetRate=0.02):base(name,balance)
        {
            this.intersetRate = intersetRate;
        }

        public double intersetRate { get;private set; }
        public override bool Withdraw(double amount)
        {
            if (amount > balance)
                return false;
            balance -= amount;
            return true;
        }
        public override bool Deposite(double amount)
        {
            if (amount < 0)
                return false;
            balance += amount;
            return true;
        }
        public override String Details()
        {
            return "[Acount :" + name + ":" + balance + "intersetRate:" + intersetRate;
        }
    }
   public class CheckingAcount : Acount
    {
        public CheckingAcount(string name = "unnamed acount", double balance = 0, double fees=1.50): base(name, balance)
        {
            this.fees = fees;
        }

        public double fees { get; set; }
        public override bool Withdraw(double amount)
        {
            if (amount > balance)
                return false;
            balance -= (amount + fees);
            return true;
        }
        public override String Details()
        {
            return "[Acount :" + name + ":" + balance + "fees" + fees;
                }
    }
  public  class TrustAcount : SavingAcount
    {
        public TrustAcount(string name = "unnamed acount", double balance = 0, double intersetRate = 0.02) : base(name, balance, intersetRate) { }
        public override bool Deposite(double amount)
        {
            if (amount < 0)
                return false;
            if (amount >= 5000.00)
            {
                double bonus = 50.00;

                balance += amount + bonus;//
            }
            else
            {
                balance += amount;//
            }
            return true;
        }
        int withdrawCount = 0;//
        public override bool Withdraw(double amount)
        {
            int Count = default;
            if (amount > balance)
                return false;
            if (withdrawCount >= 3)   // مسموح 3 مرات سحب فقط
                return false;
            if (amount > 0.20 * balance)//
                return false;
            if (amount < 0.20 * balance)
            {
                balance -= amount;
                Count++;
                withdrawCount++;//
            }
            return true;

        }
        public override String Details()
        {
            return "[Acount :" + name + ":" + balance + "intersetRate:" + intersetRate;
        }



    }
   public static class AcountUtil
    {
       public  static  void  Display(List<Acount> acounts)
        {
            Console.WriteLine("\n ===Acounts================");
            foreach(var acc in acounts)
            {
                Console.WriteLine(acc);
            }
        }
      public   static void Deposit (List<Acount> acounts , double amount)
        {
            Console.WriteLine("\n ===deposite  Acounts================");
            foreach (var acc in acounts)
            {
                if (acc.Deposite(amount))
                {
                    Console.WriteLine("withdraw" + amount + "from" + acc);
                }
                else
                {
                    Console.WriteLine("failed deposite of " + amount + "to" + acc);
                }
            }
        }
       public  static void withdraw(List<Acount> acounts, double amount)
        {
            Console.WriteLine("\n ===withdraw  Acounts================");
            foreach (var acc in acounts)
            {
                if (acc.Withdraw(amount))
                {
                    Console.WriteLine("withdraw" + amount + "from" + acc);
                }
                else
                {
                    Console.WriteLine("failed withdraw of " + amount + "to" + acc);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Acount acount1 = new Acount("larry");
            Acount acount2 = new Acount("Moe", 2000);
            Acount acount3 = new Acount("Curly", 2000);
            List<Acount> acounts = new List<Acount>();
            acounts.Add(acount1);
            acounts.Add(acount2);
            acounts.Add(acount3);
            AcountUtil.Display(acounts);
            AcountUtil.Deposit(acounts, 1000);
            AcountUtil.withdraw(acounts, 500);
        }
    }
}
task search:
1:
class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter integers separated by spaces:");
            string input = Console.ReadLine();

          
            string[] parts = input.Split(' ');
            List<int> numbers = new List<int>();

            for (int i = 0; i < parts.Length; i++)
            {
                int num = int.Parse(parts[i]);
                numbers.Add(num);
            }

          
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        throw new Exception($"Duplicate number found: {numbers[i]}");
                    }
                }
            }

            Console.WriteLine("Numbers entered successfully without duplicates.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

2:
class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            CheckVowels(input);

            Console.WriteLine("The string contains at least one vowel.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Method to check vowels manually
    static void CheckVowels(string text)
    {
        bool hasVowel = false;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

           
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                hasVowel = true;
                break;
            }
        }

        if (!hasVowel)
        {
            throw new Exception("The string does not contain any vowels.");
        }
    }
}
