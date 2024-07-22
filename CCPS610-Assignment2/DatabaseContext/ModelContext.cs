using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CCPS610_Assignment2.DatabaseContext.Tables;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace CCPS610_Assignment2.DatabaseContext
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HrCountry> HrCountries { get; set; } = null!;
        public virtual DbSet<HrDepartment> HrDepartments { get; set; } = null!;
        public virtual DbSet<HrEmpDetailsView> HrEmpDetailsViews { get; set; } = null!;
        public virtual DbSet<HrEmployee> HrEmployees { get; set; } = null!;
        public virtual DbSet<HrJob> HrJobs { get; set; } = null!;
        public virtual DbSet<HrJobGrade> HrJobGrades { get; set; } = null!;
        public virtual DbSet<HrJobHistory> HrJobHistories { get; set; } = null!;
        public virtual DbSet<HrLocation> HrLocations { get; set; } = null!;
        public virtual DbSet<HrRegion> HrRegions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=SERVICE_ACCOUNT;Password=password;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREEPDB1)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SERVICE_ACCOUNT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<HrCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("COUNTRY_C_ID_PK");

                entity.ToTable("HR_COUNTRIES");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY_ID")
                    .IsFixedLength();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY_NAME");

                entity.Property(e => e.RegionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REGION_ID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.HrCountries)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("COUNTR_REG_FK");
            });

            modelBuilder.Entity<HrDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("DEPT_ID_PK");

                entity.ToTable("HR_DEPARTMENTS");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(4)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.LocationId)
                    .HasPrecision(4)
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.ManagerId)
                    .HasPrecision(6)
                    .HasColumnName("MANAGER_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.HrDepartments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("DEPT_LOC_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.HrDepartments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("DEPT_MGR_FK");
            });

            modelBuilder.Entity<HrEmpDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("HR_EMP_DETAILS_VIEW");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.CommissionPct)
                    .HasColumnType("NUMBER(2,2)")
                    .HasColumnName("COMMISSION_PCT");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY_ID")
                    .IsFixedLength();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY_NAME");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(4)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(6)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("JOB_ID");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LocationId)
                    .HasPrecision(4)
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.ManagerId)
                    .HasPrecision(6)
                    .HasColumnName("MANAGER_ID");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("REGION_NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(8,2)")
                    .HasColumnName("SALARY");

                entity.Property(e => e.StateProvince)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STATE_PROVINCE");
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EMP_EMP_ID_PK");

                entity.ToTable("HR_EMPLOYEES");

                entity.HasIndex(e => e.Email, "EMP_EMAIL_UK")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.CommissionPct)
                    .HasColumnType("NUMBER(2,2)")
                    .HasColumnName("COMMISSION_PCT");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(4)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.HireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HIRE_DATE");

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("JOB_ID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.ManagerId)
                    .HasPrecision(6)
                    .HasColumnName("MANAGER_ID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(8,2)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("EMP_DEPT_FK");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_JOB_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("EMP_MANAGER_FK");
            });

            modelBuilder.Entity<HrJob>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("JOB_ID_PK");

                entity.ToTable("HR_JOBS");

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("JOB_ID");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.MaxSalary)
                    .HasPrecision(6)
                    .HasColumnName("MAX_SALARY");

                entity.Property(e => e.MinSalary)
                    .HasPrecision(6)
                    .HasColumnName("MIN_SALARY");
            });

            modelBuilder.Entity<HrJobGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HR_JOB_GRADES");

                entity.Property(e => e.GradeLevel)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_LEVEL");

                entity.Property(e => e.HighestSal)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HIGHEST_SAL");

                entity.Property(e => e.LowestSal)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOWEST_SAL");
            });

            modelBuilder.Entity<HrJobHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.StartDate })
                    .HasName("JHIST_EMP_ID_ST_DATE_PK");

                entity.ToTable("HR_JOB_HISTORY");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(6)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(4)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.JobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("JOB_ID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.HrJobHistories)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("JHIST_DEPT_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HrJobHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_EMP_FK");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.HrJobHistories)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_JOB_FK");
            });

            modelBuilder.Entity<HrLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("LOC_ID_PK");

                entity.ToTable("HR_LOCATIONS");

                entity.Property(e => e.LocationId)
                    .HasPrecision(4)
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY_ID")
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("POSTAL_CODE");

                entity.Property(e => e.StateProvince)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STATE_PROVINCE");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.HrLocations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("LOC_C_ID_FK");
            });

            modelBuilder.Entity<HrRegion>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("REG_ID_PK");

                entity.ToTable("HR_REGIONS");

                entity.Property(e => e.RegionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REGION_ID");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("REGION_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public void HireEmployee(HrEmployee hrEmployee)
        {
            var p_first_name = new OracleParameter("p_first_name", hrEmployee.FirstName ?? (object)DBNull.Value);
            var p_last_name = new OracleParameter("p_last_name", hrEmployee.LastName);
            var p_email = new OracleParameter("p_email", hrEmployee.Email);
            var p_salary = new OracleParameter("p_salary", hrEmployee.Salary ?? (object)DBNull.Value);
            var p_hire_date = new OracleParameter("p_hire_date", hrEmployee.HireDate);
            var p_phone = new OracleParameter("p_phone", hrEmployee.PhoneNumber ?? (object)DBNull.Value);
            var p_job_id = new OracleParameter("p_job_id", hrEmployee.JobId);
            var p_manager_id = new OracleParameter("p_manager_id", hrEmployee.ManagerId ?? (object)DBNull.Value);
            var p_department_id = new OracleParameter("p_department_id", hrEmployee.DepartmentId ?? (object)DBNull.Value);

            Database.ExecuteSqlRaw("BEGIN EMPLOYEE_HIRE_SP(:p_first_name, :p_last_name, :p_email, :p_salary, :p_hire_date, :p_phone, :p_job_id, :p_manager_id, :p_department_id); END;",
                p_first_name, p_last_name, p_email, p_salary, p_hire_date, p_phone, p_job_id, p_manager_id, p_department_id);
        }
    }
}
