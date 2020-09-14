using System;
class Program
{
    static void Main(string[] args)
    {
        int yob;
        int mob;
        int dob;
        Console.WriteLine("Enter the year of your birth:");
        yob = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the month of your birth:");
        mob = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the day of your birth:");
        dob = Convert.ToInt32(Console.ReadLine());
        int rCode = CheckTheBirthDate(yob, mob, dob);
        switch (rCode)
        {
            case -1:
                Console.WriteLine("You are born in this year");
                break;
            case 0:
                Console.WriteLine("You are born today.Welcome!!!");
                break;
            case 1:
                Console.WriteLine("You have entered a future date");
                break;
            case 2:
                Console.WriteLine("You are lucky to have lived >=135");
                break;
            default:
                Console.WriteLine("Age of the use is" + rCode);
                if (TodayBirthday(mob, dob))
                {
                    Console.WriteLine("Happy Birthday!!!");
                }
                break;
        }
        Console.ReadLine();

    }
    private static bool TodayBirthday(int mob,int dob)
    {
        DateTime tdy = DateTime.Today;
        if (mob == tdy.Month && dob == tdy.Day)
           return true;
        else
            return false;
    }

    private static int CheckTheBirthDate(int yob, int mob, int dob)
    {
        DateTime bDate = new DateTime(yob, mob, dob);
        DateTime tdate = DateTime.Today;
        DateTime.Compare(bDate, DateTime.Now);
        int rvalue = CheckTheBirthDate(yob, mob, dob);
        if (rvalue < 0)
        {
            if ((tdate.Year - bDate.Year) >= 135)
                return 2;
            else if ((tdate.Year - bDate.Year) == 0)
                return -1;
            else
                return (tdate.Year - bDate.Year);
        }
        else if (rvalue > 0)
            return 1;
        else
            return 0;
    }
}

