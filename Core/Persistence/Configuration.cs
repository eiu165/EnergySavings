using System.Data.Entity.Migrations;
using Core.Model;
using System.Collections.Generic;

namespace Core.Persistence
{
    public class Configuration :  DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(Context context)
        {
            var articles = new List<Article>();
            for (int i = 1; i < 4; i++)
            {
                articles.Add(new Article { Id = i,   Name = "TestArticle" + i,  Content = "lourm ipsum"  });
            }
            var tags = new List<Tag>();
            tags.Add(new Tag {  Name = "Personal" });
            tags.Add(new Tag {  Name = "Auto" });
            tags.Add(new Tag {  Name = "Family" });
            tags.Add(new Tag {  Name = "Home" }); 
            var articleTag = new List<ArticleTag>();
            for (int i = 1; i < 4; i++)
            {
                articleTag.Add(new ArticleTag { Id= i,  Article = articles[i-1], Tag = tags[i-1] });
            }
            context.Articles.AddOrUpdate(x => x.Name, articles.ToArray());
            context.Tags.AddOrUpdate( x=> x.Name, tags.ToArray());
            context.ArticleTags.AddOrUpdate(  articleTag.ToArray());

            var users = new List<User>();
            users.Add(new User { EmailAddress = "a@a.com", Name = "a", Phone = "555-555-5555" });
            context.Users.AddOrUpdate(x => x.Name, users.ToArray());

            context.SaveChanges();
        }
    }
}
