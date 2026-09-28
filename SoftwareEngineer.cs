/********************************
Ma sinh vien: 202418855
Ho ten: Do Van Chung
********************************/

using System;

public class SoftwareEngineer : Employee
{
    private string primaryLanguage;
    private double technicalAllowance;

    // Constructor 1
    public SoftwareEngineer(
        string id,
        string fullName,
        string primaryLanguage)
        : base(id, fullName)
    {
        if (string.IsNullOrWhiteSpace(primaryLanguage))
        {
            throw new ArgumentException(
                "Primary language must not be empty."
            );
        }

        this.primaryLanguage = primaryLanguage;
        technicalAllowance = 0;
    }

    // Constructor 2
    public SoftwareEngineer(
        string id,
        string fullName,
        double baseSalary,
        string primaryLanguage,
        double technicalAllowance)
        : base(id, fullName, baseSalary)
    {
        if (string.IsNullOrWhiteSpace(primaryLanguage))
        {
            throw new ArgumentException(
                "Primary language must not be empty."
            );
        }

        if (technicalAllowance < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(technicalAllowance),
                "Technical allowance must not be negative."
            );
        }

        this.primaryLanguage = primaryLanguage;
        this.technicalAllowance = technicalAllowance;
    }

    public string getPrimaryLanguage()
    {
        return primaryLanguage;
    }

    public double getTechnicalAllowance()
    {
        return technicalAllowance;
    }

    // Override chi phi hang thang
    public override double calculateMonthlyCost()
    {
        return base.calculateMonthlyCost()
               + technicalAllowance;
    }

    // Override hien thi
    public override void displayInfo()
    {
        Console.WriteLine(
            $"Software Engineer | " +
            $"ID: {getId()} | " +
            $"Name: {getFullName()} | " +
            $"Base salary: {getBaseSalary():N0} | " +
            $"Language: {primaryLanguage} | " +
            $"Allowance: {technicalAllowance:N0} | " +
            $"Monthly cost: {calculateMonthlyCost():N0}"
        );
    }

    ~SoftwareEngineer()
    {
        Console.WriteLine(
            $"SoftwareEngineer {getId()} " +
            $"is being finalized."
        );
    }
}