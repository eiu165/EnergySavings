using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Core.Persistence;

namespace Web.Areas.Knockout.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Knockout/Articles/

        public ActionResult Index()
        {
            return View();
        }



        public JsonResult DeleteArticle(ArticleViewModel article)
        {
            Thread.Sleep(300);
            string r = string.Format("removed '{0}' from article", article.name);
            using (var context = new Context())
            {
                foreach (var at in context.ArticleTags.Where(x => x.Article.Id == article.id ))
                {
                    context.ArticleTags.Remove(at);
                }
                context.SaveChanges(); 
                context.Articles.Where(x => x.Id == article.id).ToList().ForEach(y => context.Articles.Remove(y)); 
                context.SaveChanges();
            }
            return Json(this.GetArticlesFromDb(), JsonRequestBehavior.AllowGet); //Content(r);
        } 




        public JsonResult GetArticles()
        {
            Thread.Sleep(300);
            var l = GetArticlesFromDb();
            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        private List<ArticleViewModel> GetArticlesFromDb()
        {
            using (var context = new Context())
            {
                var list = from x in context.Articles 
                            select new ArticleViewModel
                            {
                                id = x.Id,
                                name = x.Name
                            };
                return list.ToList();
            }
        } 

    }


    public class ArticleList
    {
        public ArticleViewModel[] articles { get; set; }
    }
    public class ArticleViewModel
    {
        public int id { get; set; }
        public string name { get; set; } 
    }

}
