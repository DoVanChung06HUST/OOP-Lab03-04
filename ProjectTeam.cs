/********************************
Ma sinh vien: 202418855
Ho ten: Do Van Chung
********************************/

using System;
using System.Collections.Generic;

public class ProjectTeam
{
    private string projectCode;
    private string projectName;

    // Co the chua co truong nhom
    private Employee? leader;

    // Danh sach chi luu tham chieu den Employee
    private List<Employee> members;

    // Constructor 1: chua co leader
    public ProjectTeam(
        string projectCode,
        string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectCode))
        {
            throw new ArgumentException(
                "Project code must not be empty."
            );
        }

        if (string.IsNullOrWhiteSpace(projectName))
        {
            throw new ArgumentException(
                "Project name must not be empty."
            );
        }

        this.projectCode = projectCode;
        this.projectName = projectName;

        leader = null;
        members = new List<Employee>();
    }

    // Constructor 2: co leader
    public ProjectTeam(
        string projectCode,
        string projectName,
        Employee leader)
        : this(projectCode, projectName)
    {
        if (leader == null)
        {
            throw new ArgumentNullException(nameof(leader));
        }

        this.leader = leader;

        // Leader tu dong la mot thanh vien
        members.Add(leader);
    }

    // Kiem tra nhan su co trong nhom khong
    public bool contains(string employeeId)
    {
        foreach (Employee employee in members)
        {
            if (employee.getId() == employeeId)
            {
                return true;
            }
        }

        return false;
    }

    // Nap chong addMember:
    // Them thanh vien binh thuong
    public bool addMember(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (contains(employee.getId()))
        {
            Console.WriteLine(
                $"Cannot add {employee.getId()}: " +
                "employee already exists in the team."
            );

            return false;
        }

        members.Add(employee);
        return true;
    }

    // Them thanh vien va co the dat lam leader
    public bool addMember(
        Employee employee,
        bool makeLeader)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (contains(employee.getId()))
        {
            Console.WriteLine(
                $"Cannot add {employee.getId()}: " +
                "employee already exists in the team."
            );

            return false;
        }

        members.Add(employee);

        if (makeLeader)
        {
            leader = employee;
        }

        return true;
    }

    // Xoa thanh vien theo id
    public bool removeMember(string employeeId)
    {
        // Khong duoc xoa leader hien tai
        if (leader != null &&
            leader.getId() == employeeId)
        {
            Console.WriteLine(
                "Cannot remove the current leader."
            );

            return false;
        }

        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].getId() == employeeId)
            {
                members.RemoveAt(i);
                return true;
            }
        }

        Console.WriteLine(
            $"Employee {employeeId} was not found."
        );

        return false;
    }

    // Doi truong nhom
    public void changeLeader(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        // Neu chua co trong nhom thi tu dong them
        if (!contains(employee.getId()))
        {
            members.Add(employee);
        }

        leader = employee;
    }

    // Tinh tong chi phi
    public double calculateTotalMonthlyCost()
    {
        double total = 0;

        foreach (Employee employee in members)
        {
            // Goi da hinh
            total += employee.calculateMonthlyCost();
        }

        return total;
    }

    // Hien thi thong tin nhom
    public void displayTeam()
    {
        Console.WriteLine();
        Console.WriteLine(
            "=============================================="
        );

        Console.WriteLine(
            $"Project: {projectCode} - {projectName}"
        );

        if (leader == null)
        {
            Console.WriteLine("Leader: Not assigned");
        }
        else
        {
            Console.WriteLine(
                $"Leader: {leader.getId()} - " +
                $"{leader.getFullName()}"
            );
        }

        Console.WriteLine("Members:");

        foreach (Employee employee in members)
        {
            // Goi da hinh
            employee.displayInfo();
        }

        Console.WriteLine(
            $"Total monthly cost: " +
            $"{calculateTotalMonthlyCost():N0}"
        );

        Console.WriteLine(
            "=============================================="
        );
    }

    ~ProjectTeam()
    {
        Console.WriteLine(
            $"ProjectTeam {projectCode} " +
            $"is being finalized."
        );

        // Khong huy Employee.
        // C# Garbage Collector tu quan ly bo nho.
    }
}