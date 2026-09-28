/********************************
Ma sinh vien: 202418855
Ho ten: Do Van Chung
********************************/
using System;

public class Employee
{
    private string id;
    private string fullName;
    protected double baseSalary;

    // Constructor 1: khong tham so
    public Employee()
    {
        id = "UNKNOWN";
        fullName = "Unnamed employee";
        baseSalary = 0;
    }

    // Constructor 2: id + fullName
    public Employee(string id, string fullName)
        : this(id, fullName, 0)
    {
    }

    // Constructor 3: day du thong tin
    public Employee(
        string id,
        string fullName,
        double baseSalary)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException(
                "Employee id must not be empty."
            );
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException(
                "Employee full name must not be empty."
            );
        }

        if (baseSalary < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(baseSalary),
                "Base salary must not be negative."
            );
        }

        this.id = id;
        this.fullName = fullName;
        this.baseSalary = baseSalary;
    }

    // Getter
    public string getId()
    {
        return id;
    }

    public string getFullName()
    {
        return fullName;
    }

    public double getBaseSalary()
    {
        return baseSalary;
    }

    // Nap chong phuong thuc:
    // Tang luong bang mot so tien co dinh
    public void increaseSalary(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Salary increase must be positive."
            );
        }

        baseSalary += amount;
    }

    // Tang luong theo phan tram hoac so tien co dinh
    public void increaseSalary(
        double value,
        bool byPercentage)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Salary increase must be positive."
            );
        }

        if (byPercentage)
        {
            baseSalary += baseSalary * value / 100.0;
        }
        else
        {
            baseSalary += value;
        }
    }

    // Phuong thuc virtual de lop con override
    public virtual double calculateMonthlyCost()
    {
        return baseSalary;
    }

    public virtual void displayInfo()
    {
        Console.WriteLine(
            $"Employee | ID: {id} | " +
            $"Name: {fullName} | " +
            $"Base salary: {baseSalary:N0}"
        );
    }

    // Finalizer de quan sat vong doi doi tuong
    ~Employee()
    {
        Console.WriteLine(
            $"Employee {id} is being finalized."
        );
    }
}