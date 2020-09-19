using System;
using System.Collections.Generic;
using System.Text;


namespace TestProperties
{
   class Person
    {
        private String FirstName;
        private string LastName;
        private string Email;
        private DateTime Dob;

        public string SetfirstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }
        public string SetLastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }


        public string SetEmail
        {
            set
            {
                Email = value;
            }
        }
        public DateTime SetDob
        {
            set
            {
                Dob = value;
            }
        }
        public Person(String First, String Last, String email, DateTime DOfB)
        {
            FirstName = First;
            LastName = Last;
            Email = email;
            Dob = DOfB;
        }

        public Person(String First, String Last, String email)
        {
            FirstName = First;
            LastName = Last;
            Email = email;
        }

        public Person(String First, String Last, DateTime DOfB)
        {
            FirstName = First;
            LastName = Last;
            Dob = DOfB;
        }

        public int age(DateTime dtDOB)
        {
            TimeSpan ts = DateTime.Now.Subtract(dtDOB);
            int years = ts.Days / 365;
            return years;

        }

        public string ZodiacSign(DateTime DateOfBirth)
        {
            string returnString = string.Empty;
            string[] dateAndMonth = DateOfBirth.ToLongDateString().Split(new char[] { ',' });
            string[] ckhString = dateAndMonth[1].ToString().Split(new char[] { ' ' });
            if (ckhString[1].ToString() == "March")
            {
                if (Convert.ToInt32(ckhString[2]) <= 20)
                {
                    returnString = "Pisces";
                }
                else
                {
                    returnString = "Aries";
                }
            }
            else if (ckhString[1].ToString() == "April")
            {
                if (Convert.ToInt32(ckhString[2]) <= 19)
                {
                    returnString = "Aries";
                }
                else
                {
                    returnString = "Taurus";
                }
            }
            return returnString;
        }

        public bool IsAdult
        {
            get
            {
                if (age(this.Dob) >= 18)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isBirthdayToday
        {
            get
            {
                if ((this.Dob.Day == DateTime.Now.Day) && (this.Dob.Month == DateTime.Now.Month))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string GetSunSign
        {
            get
            {
                return (ZodiacSign(this.Dob));
            }
        }
    }
    class Program
    {
        private String getAdultString(Person obj)
        {
            if (obj.IsAdult)
            {
                return obj.SetfirstName + " Is Adult";
            }
            else
            {
                return obj.SetfirstName + " Is not Adult";
            }
        }
        private String getBdayString(Person obj)
        {
            if (obj.isBirthdayToday)
            {
                return "Today Is " + obj.SetfirstName + "'s B'day";
            }
            else
            {
                return "Today Is not " + obj.SetfirstName + "'s B'day";
            }
        }

        private String getSunSignString(Person obj)
        {
            return obj.SetfirstName + "'s Sun sign is " + obj.GetSunSign;
        }

        static void Main(string[] args)
        {
            Person p = new Person("Test1", "Test1", new DateTime(1984, 10, 30));
            Person p1 = new Person("Test2", "Test2", new DateTime(2010, 4, 30));
            Program objProgram = new Program();

            Console.WriteLine(objProgram.getAdultString(p));
            Console.WriteLine(objProgram.getBdayString(p));
            Console.WriteLine(objProgram.getSunSignString(p));
            Console.WriteLine();
            Console.WriteLine(objProgram.getAdultString(p1));
            Console.WriteLine(objProgram.getBdayString(p1));
            Console.WriteLine(objProgram.getSunSignString(p1));
            Console.ReadLine();
        }
    }
}
