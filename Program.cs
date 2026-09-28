/********************************
Ma sinh vien: 202418855
Ho ten: Do Van Chung
********************************/

using System;
public class Program
{
    // Tao team 2 trong mot ham rieng.
    // Khi ham ket thuc, team2 khong con duoc tham chieu.
    static void createSecondTeam(Employee employee)
    {
        Console.WriteLine();
        Console.WriteLine(
            "===== 13. CREATE SECOND TEAM ====="
        );

        ProjectTeam team2 = new ProjectTeam(
            "P002",
            "Mobile Application"
        );

        team2.addMember(employee);

        team2.displayTeam();

        Console.WriteLine(
            "Leaving createSecondTeam()..."
        );
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(
            "=============================================="
        );
        Console.WriteLine(
            "          OOP LAB 03-04"
        );
        Console.WriteLine(
            "=============================================="
        );

        // =================================================
        // 1. Tao hai Employee bang hai constructor khac nhau
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 1. CREATE EMPLOYEES ====="
        );

        Employee employee1 = new Employee(
            "E001",
            "Nguyen Van An"
        );

        Employee employee2 = new Employee(
            "E002",
            "Tran Minh Binh",
            15000000
        );

        employee1.displayInfo();
        employee2.displayInfo();

        // =================================================
        // 2. Tao hai SoftwareEngineer
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 2. CREATE SOFTWARE ENGINEERS ====="
        );

        SoftwareEngineer engineer1 =
            new SoftwareEngineer(
                "SE001",
                "Le Quang Huy",
                "C#"
            );

        SoftwareEngineer engineer2 =
            new SoftwareEngineer(
                "SE002",
                "Pham Duc Minh",
                20000000,
                "Python",
                3000000
            );

        engineer1.displayInfo();
        engineer2.displayInfo();

        // =================================================
        // 3. Tang luong bang so tien co dinh
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 3. FIXED SALARY INCREASE ====="
        );

        employee1.increaseSalary(2000000);

        employee1.displayInfo();

        // =================================================
        // 4. Tang luong theo phan tram
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 4. PERCENTAGE SALARY INCREASE ====="
        );

        employee2.increaseSalary(10, true);

        employee2.displayInfo();

        // =================================================
        // 5. Tao team chua co leader
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 5. CREATE PROJECT TEAM ====="
        );

        ProjectTeam team1 = new ProjectTeam(
            "P001",
            "Management System"
        );

        team1.displayTeam();

        // =================================================
        // 6. Them mot Employee
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 6. ADD EMPLOYEE ====="
        );

        team1.addMember(employee1);

        // =================================================
        // 7. Them engineer va dat lam leader
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 7. ADD ENGINEER AND MAKE LEADER ====="
        );

        team1.addMember(engineer1, true);

        // Them hai thanh vien nua de test
        team1.addMember(employee2);
        team1.addMember(engineer2);

        team1.displayTeam();

        // =================================================
        // 8. Thu them thanh vien trung
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 8. DUPLICATE MEMBER TEST ====="
        );

        bool duplicateResult =
            team1.addMember(employee1);

        Console.WriteLine(
            $"Add duplicate result: {duplicateResult}"
        );

        // =================================================
        // 9. Hien thi bang loi goi da hinh
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 9. POLYMORPHISM TEST ====="
        );

        team1.displayTeam();

        // =================================================
        // 10. Tinh tong chi phi hang thang
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 10. TOTAL MONTHLY COST ====="
        );

        double totalCost =
            team1.calculateTotalMonthlyCost();

        Console.WriteLine(
            $"Total monthly personnel cost: " +
            $"{totalCost:N0}"
        );

        // =================================================
        // 11. Thu xoa leader hien tai
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 11. REMOVE CURRENT LEADER ====="
        );

        bool removeLeaderResult =
            team1.removeMember(engineer1.getId());

        Console.WriteLine(
            $"Remove current leader result: " +
            $"{removeLeaderResult}"
        );

        // =================================================
        // 12. Doi leader roi xoa leader cu
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 12. CHANGE LEADER ====="
        );

        team1.changeLeader(employee2);

        Console.WriteLine(
            $"New leader: " +
            $"{employee2.getFullName()}"
        );

        bool removeOldLeaderResult =
            team1.removeMember(engineer1.getId());

        Console.WriteLine(
            $"Remove former leader result: " +
            $"{removeOldLeaderResult}"
        );

        team1.displayTeam();

        // =================================================
        // 13. Tao nhom thu hai
        // =================================================

        createSecondTeam(employee1);

        // =================================================
        // 14. Thu gom Team 2
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 14. GARBAGE COLLECTION ====="
        );

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine(
            "Garbage collection completed."
        );

        // =================================================
        // 15. Employee van ton tai
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== 15. EMPLOYEE STILL EXISTS ====="
        );

        employee1.displayInfo();

        Console.WriteLine();
        Console.WriteLine(
            "Employee E001 still exists after " +
            "the second ProjectTeam is finalized."
        );

        Console.WriteLine();
        Console.WriteLine(
            "=============================================="
        );
        Console.WriteLine(
            "              END OF PROGRAM"
        );
        Console.WriteLine(
            "=============================================="
        );
    }
}