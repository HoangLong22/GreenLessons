namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GreenLessonDbContext : DbContext
    {
        public GreenLessonDbContext()
            : base("name=GreenLessonDbContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<TypeMenu> TypeMenus { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<CategoryQuestion> CategoryQuestions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<New>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }

        //public System.Data.Entity.DbSet<GreenLesson.Models.LoginModel> LoginModels { get; set; }

        //public System.Data.Entity.DbSet<GreenLesson.Models.RegisterModel> RegisterModels { get; set; }
    }
}
