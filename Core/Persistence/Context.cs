using System.Data.Entity;
using System.Data.Entity.Migrations;
using Core.Model;

namespace Core.Persistence
{
	public partial class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
//           Database.SetInitializer(new DropCreateDatabaseAlways<Context>()); 
		} 
	}




    /*

    public partial class Context
    {
        static Context()
        {
            Database.SetInitializer(new TestDataInitializer());
            //Database.Initialize(false);
        }


        private class TestDataInitializer :
            //CreateDatabaseIfNotExists<Context>
            //DropCreateDatabaseIfModelChanges<Context>
            //DropCreateDatabaseAlways<Context>
            MigrateDatabaseToLatestVersion<Context, Configuration>
            //DbMigrationsConfiguration<Context> // http://www.remondo.net/tag/entity-framework/
        {


            //protected override void Seed(Context context)
            //{
            //    var u = new User { Name = "alpha", EmailAddress = "a@test.com" };
            //    context.Users.Add(u);
            //    context.Users.Add(new User { Name = "bbb", EmailAddress = "bbbb@test.com" });
            //    context.Users.Add(new User { Name = "ccc", EmailAddress = "ccc@test.com" });
            //    context.SaveChanges();
            //}
        }
    } */
}
