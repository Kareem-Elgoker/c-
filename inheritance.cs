using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Employee
    {
        protected static int MinimumHours = 176;
        protected static double OverTimeRate = 1.25;
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected int LoggedHours { get; set; }
        protected double Wage { get; set; }
        protected double BasicSalary {get; set; }
        protected double OverTime { get; set; }
        protected double NetSalary { get; set; }
        public Employee(int Id, string Name, int LoggedHours, double Wage)
        {
            this.Id = Id;
            this.Name = Name;
            this.LoggedHours = LoggedHours;
            this.Wage = Wage;
        }

        protected virtual void CalculateBaseSalary()
        {
            BasicSalary = Wage * MinimumHours;
        }
        protected void CalculateOverTime()
        {
            OverTime = (LoggedHours - MinimumHours) * OverTimeRate * Wage;
        }
        protected virtual void CalculateNetSalary()
        {
            NetSalary = BasicSalary + OverTime;
        }

        public virtual void DisplayData()
        {
            Console.WriteLine($"Id : {Id}\nName : {Name}\nLogged Hours : {LoggedHours}\n" +
                                $"Wage : {Wage}\nBasic Salary : {BasicSalary}\nOver Time : {OverTime}");
        }
        protected void DisplayNetSalary()
        {
            Console.WriteLine($"Net Salary : {NetSalary}\n");
        }
    }

    class Manager : Employee
    {
        static double AllowanceRate = 0.05;
        double Allowance { get; set; }

        public Manager(int Id, string Name, int LoggedHours, double Wage) : base(Id, Name, LoggedHours, Wage)
        {
            CalculateBaseSalary();
            CalculateOverTime();
            CalculateAllowance();
            CalculateNetSalary();
        }

        void CalculateAllowance()
        {
            Allowance = AllowanceRate * BasicSalary;
        }

        protected override void CalculateNetSalary()
        {
            base.CalculateNetSalary();
            NetSalary += Allowance;
        }

        public override void DisplayData()
        {
            Console.WriteLine("Manager\n..........\n");
            base.DisplayData();
            Console.WriteLine($"Allownace : {Allowance}");
            DisplayNetSalary();
        }
    }
    class Maintainance : Employee
    {
        static double HardShip = 100;

        public Maintainance(int Id, string Name, int LoggedHours, double Wage) : base(Id, Name, LoggedHours, Wage)
        {
            CalculateBaseSalary();
            CalculateOverTime();
            CalculateNetSalary();

        }
        protected override void CalculateNetSalary()
        {
            base.CalculateNetSalary();
            NetSalary += HardShip;
        }

        public override void DisplayData()
        {
            Console.WriteLine("Maintainance\n..........\n");
            base.DisplayData();
            Console.WriteLine($"HardShip : {HardShip}");
            DisplayNetSalary();
        }
    }
    class Sales : Employee
    {
        
        double SalesVolume { get; set; }
        double Commission { get; set; }
        double Bouns { get; set; }

        public Sales(int Id, string Name, int LoggedHours, double Wage, double SalesVolume, double Commission) : base(Id, Name, LoggedHours, Wage)
        {
            this.SalesVolume = SalesVolume;
            this.Commission = Commission;
            CalculateBaseSalary();
            CalculateOverTime();
            CalculateBouns();
            CalculateNetSalary();
        }

        protected override void CalculateNetSalary()
        {
            base.CalculateNetSalary();
            NetSalary += Bouns;
        }

        void CalculateBouns()
        {
            Bouns = SalesVolume * Commission;
        }

        public override void DisplayData()
        {
            Console.WriteLine("Sales\n..........\n");
            base.DisplayData();
            Console.WriteLine($"Sales : {SalesVolume}\nCommission :{Commission}\nBouns : {Bouns}");
            DisplayNetSalary();
        }
    }
    class Developer : Employee
    {
        static double BounseRate = 0.03;
 
        bool MissionCompleted { get; set; }
        double Bouns { get; set; }

        public Developer(int Id, string Name, int LoggedHours, double Wage, bool MissionCompleted) : base(Id, Name, LoggedHours, Wage)
        {
            this.MissionCompleted = MissionCompleted;
            CalculateBaseSalary();
            CalculateOverTime();
            CalculateBouns();
            CalculateNetSalary();
        }

        void CalculateBouns()
        {
            if (MissionCompleted) Bouns = BounseRate * BasicSalary;
            else Bouns = 0;
        }

        protected override void CalculateNetSalary()
        {
            base.CalculateNetSalary();
            NetSalary += Bouns;
        }

        public override void DisplayData()
        {
            Console.WriteLine("Developer\n..........\n");
            base.DisplayData();
            Console.WriteLine($"Task Completed : {(MissionCompleted?"Done":"Not Done")}\nBouns : {Bouns}");
            DisplayNetSalary();
        }
    }

    class Program
    {
        static void Main()
        {
            Employee E1 = new Manager(1000, "Ahmed A.", 176, 10);
            Employee E2 = new Maintainance(1001, "Salim M", 185, 9);
            Employee E3 = new Sales(1002, "Reem A.", 176, 8, 10000, 0.05);
            Employee E4 = new Developer(1003, "Reem A.", 180, 14, true);
            E1.DisplayData();
            E2.DisplayData();
            E3.DisplayData();
            E4.DisplayData();
            Console.ReadKey();
        }
    }
    
}
