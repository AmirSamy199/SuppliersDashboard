using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SuppliersDashboard.Models.Employee
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }
        public virtual DbSet<AgentsLevels_tbl> AgentsLevels_tbl { get; set; }
        public virtual DbSet<Category_Tbl> Category_Tbl { get; set; }
        public virtual DbSet<collection_tbl> collection_tbl { get; set; }
        public virtual DbSet<Com_Tbl> Com_Tbl { get; set; }
        public virtual DbSet<Country_TBL> Country_TBL { get; set; }
        public virtual DbSet<Currency_Tbl> Currency_Tbl { get; set; }
        public virtual DbSet<Distributor_Group_Tbl> Distributor_Group_Tbl { get; set; }
        public virtual DbSet<EmployeeType_tbl> EmployeeType_tbl { get; set; }
        public virtual DbSet<ExpenseType_Tbl> ExpenseType_Tbl { get; set; }
        public virtual DbSet<HR_ComRules_tbl> HR_ComRules_tbl { get; set; }
        public virtual DbSet<HR_Deduction_Types> HR_Deduction_Types { get; set; }
        public virtual DbSet<HR_Education_Grade_Tbl> HR_Education_Grade_Tbl { get; set; }
        public virtual DbSet<HR_Employee_bonus> HR_Employee_bonus { get; set; }
        public virtual DbSet<HR_Excuses_Types> HR_Excuses_Types { get; set; }
        public virtual DbSet<HR_ExcusesActions> HR_ExcusesActions { get; set; }
        public virtual DbSet<HR_Insurance_TBL> HR_Insurance_TBL { get; set; }
        public virtual DbSet<HR_Jobs_Levels> HR_Jobs_Levels { get; set; }
        public virtual DbSet<HR_Jobs_Tbl> HR_Jobs_Tbl { get; set; }
        public virtual DbSet<HR_leave_type_tbl> HR_leave_type_tbl { get; set; }
        public virtual DbSet<HR_leaveBalance_tbl> HR_leaveBalance_tbl { get; set; }
        public virtual DbSet<HR_Military_Status_Tbl> HR_Military_Status_Tbl { get; set; }
        public virtual DbSet<HR_Missions_Types> HR_Missions_Types { get; set; }
        public virtual DbSet<HR_MissionsActions> HR_MissionsActions { get; set; }
        public virtual DbSet<HR_Monthly_Salary> HR_Monthly_Salary { get; set; }
        public virtual DbSet<HR_Payment_Methods> HR_Payment_Methods { get; set; }
        public virtual DbSet<HR_TerminationOfStaff> HR_TerminationOfStaff { get; set; }
        public virtual DbSet<HR_University_Tbl> HR_University_Tbl { get; set; }
        public virtual DbSet<HR_Vacation_Types> HR_Vacation_Types { get; set; }
        public virtual DbSet<Items_Tbl> Items_Tbl { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<HR_Degree_Tbl> HR_Degree_Tbl { get; set; }
        public virtual DbSet<HR_Employee_TBL> HR_Employee_TBL { get; set; }
        public virtual DbSet<HR_Location_Tbl> HR_Location_Tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.Old_RemainingAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.SalesAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.CollectionAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.ReturnAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.Amount_Required)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.RemainingAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.TotalPaymet)
                .HasPrecision(10, 2);

            modelBuilder.Entity<collection_tbl>()
                .Property(e => e.MoneyTakeFromBranch)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EmployeeType_tbl>()
                .Property(e => e.BaseSalary)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EmployeeType_tbl>()
                .Property(e => e.Commision)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EmployeeType_tbl>()
                .Property(e => e.TransportInstead)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Deduction_Types>()
                .Property(e => e.Deduction_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_ExcusesActions>()
                .Property(e => e.Deduction)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Insurance_TBL>()
                .Property(e => e.EmployeeSalary)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Insurance_TBL>()
                .Property(e => e.Insurance_Fee)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Insurance_TBL>()
                .Property(e => e.Worker_share)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Insurance_TBL>()
                .Property(e => e.Employers_share)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Insurance_TBL>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Jobs_Tbl>()
                .Property(e => e.budget)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Missions_Types>()
                .Property(e => e.Deduction_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_MissionsActions>()
                .Property(e => e.Deduction_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Monthly_Salary>()
                .Property(e => e.ExchangeAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Monthly_Salary>()
                .Property(e => e.Bouns_Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HR_Monthly_Salary>()
                .Property(e => e.Editor)
                .IsFixedLength();

            modelBuilder.Entity<HR_TerminationOfStaff>()
                .Property(e => e.Indemnity)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Items_Tbl>()
                .Property(e => e.size)
                .HasPrecision(10, 3);

            modelBuilder.Entity<HR_Employee_TBL>()
                .Property(e => e.EmployeeCode)
                .IsFixedLength();

            modelBuilder.Entity<HR_Employee_TBL>()
                .Property(e => e.EmployeeSalary)
                .HasPrecision(10, 2);
          
        }
    }
}
