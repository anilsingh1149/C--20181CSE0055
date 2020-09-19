using System;

class person 
{
    
    string _firstname;
    string _lastname;
    string _email;
    DateTime _dateofbirth;

    public string firstname
    {
        get { return _firstname; }
        set { _firstname = value; }
    }

    public string lastname
    {
        get { return _lastname; }
        set { _lastname = value; }
    }

    public string email
    {
        get { return _email; }
        set
        {
            string[] items = value.Split('@'); 
            if (items.Length != 2) 
            {
                throw new ArgumentException("Invalid email address");
            }
            _email = value;
        }
    }

    public DateTime dateofbirth
    {
        get { return _dateofbirth; }
        set
        {
            if (value > DateTime.Today) 
            {
                throw new ArgumentException("Date of birth can't be in the future");
            }
            _dateofbirth = value;
        }
    }

    public person(string first, string last, string email, DateTime dateofbirth)
    {
        this.firstname = first;
        this.lastname = last;

        try
        {
            this.email = email;
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }

        try
        {
            this.dateofbirth = dateofbirth;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }
    }

    public bool Adult
    {
        get
        {
            DateTime eighteen = _dateofbirth.AddYears(18);
            if (DateTime.Today >= eighteen) return true;
            return false;
        }
    }

    public bool birthday
    {
        get
        {
            DateTime today = DateTime.Today;
            if (today.Month == _dateofbirth.Month && today.Day == _dateofbirth.Day)
            {
                return true;
            }
            return false;
        }
    }
}

class Test
{
    static void Main()
    {
        Console.WriteLine("Enter details for a person\n");
        Console.Write(" First name : ");
        string first = Console.ReadLine();
        Console.Write(" Last name : ");
        string last = Console.ReadLine();
        Console.Write(" Email address : ");
        string email = Console.ReadLine();
        Console.Write(" Date of birth : ");
        string dob = Console.ReadLine();
        DateTime dateofbirth = DateTime.Parse(dob);
        person p = new person(first, last, email, dateofbirth);
        Console.WriteLine();
        Console.WriteLine("The person entered is : {0} {1}", p.firstname, p.lastname);
        Console.WriteLine("Email address is: {0}", p.email);
        Console.WriteLine("Date of birth is: {0}", p.dateofbirth.ToShortDateString());
        Console.WriteLine("Adult : {0}", p.Adult);
        Console.WriteLine("Birthday today : {0}", p.birthday);
        Console.ReadKey();
    }
}
