using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Model;
using Core.Persistence;
using System.Transactions;

namespace Web.Areas.Knockout.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            return View();
        }

        public ActionResult Tags(int? id)
        {
            Session["Tag-ArticleId"] = id ?? 1;
            return View();
        } 

        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult Both()
        {
            return View();
        } 

        private int? articleId
        {
            get
            {
                var aid = Convert.ToInt32(Session["Tag-ArticleId"] ?? "1");
                return aid;
            }
        } 



        public JsonResult GetTags()
        {
            Thread.Sleep(300);
            var l = GetTagsFromDb();
            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<TagViewModel> GetTagsFromDb()
        {
            using (var context = new Context())
            {
                var list = (from t in _context.Tags
                            group t by new { t.Id, t.Name }
                                into grp
                                select new TagViewModel
                                {
                                    tagId = grp.Key.Id,
                                    name = grp.Key.Name,
                                    isInArticle = grp.Sum(t => _context.ArticleTags.Where(x => x.Article.Id == articleId).Where(x => x.Tag.Id == t.Id).Count()) > 0
                                });
                return list;
            }
        } 

        public JsonResult SaveTag(TagViewModel tag)
        {
            Thread.Sleep(300);
            using (var context = new Context())
            {
                var article = context.Articles.Find(articleId);
                var dbTag = context.Tags.Where(x => x.Name == tag.name).FirstOrDefault();
                if (dbTag == null)
                {
                    dbTag = context.Tags.Add(new Tag { Name = tag.name });
                }
                if (!context.ArticleTags.Any(x => x.Article.Id == articleId && x.Tag.Name == tag.name))
                {
                    context.ArticleTags.Add(new ArticleTag { Article = article, Tag = dbTag });
                }
                context.SaveChanges();
            }
            return Json(this.GetTagsFromDb(), JsonRequestBehavior.AllowGet); //Content(r);
        }

        public JsonResult RemoveTag(TagViewModel tag)
        {
            Thread.Sleep(300);
            string r = string.Format("removed '{0}' from article", tag.name);
            using (var context = new Context())
            {
                foreach (var at in context.ArticleTags.Where(x => x.Article.Id == articleId && x.Tag.Name == tag.name))
                {
                    context.ArticleTags.Remove(at);
                }
                context.SaveChanges();
                if (context.ArticleTags.Where(x => x.Tag.Name == tag.name).Count() == 0)
                {
                    context.Tags.Where(x => x.Name == tag.name).ToList().ForEach(y => context.Tags.Remove(y));
                    r = string.Format("removed tag '{0}' from article and tag '{0}'", tag.name);
                }
                context.SaveChanges();
            }
            return Json(this.GetTagsFromDb(), JsonRequestBehavior.AllowGet); //Content(r);
        } 




        private readonly Context _context = new Context();

        public JsonResult GetTasks()
        {
            //var l = new List<TaskViewModel>();
            //l.Add(new TaskViewModel { title = "Wire the money to Panama", isDone = false });
            //l.Add(new TaskViewModel { title = "Arrange for someone to look after the cat", isDone = true });
            //l.Add(new TaskViewModel { title = "Get hair dye, beard trimmer, dark glasses", isDone = false });
            //l.Add(new TaskViewModel { title = "Book taxi to airport", isDone = false });

            Thread.Sleep(300);
            
            var l = _context.Tasks.Select(x=> new TaskViewModel
                                                  {
                                                      title = x.Title,
                                                      isDone =   x.IsDone
                                                  });

            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(  l  , JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveTasks(TaskList list)
        {
            Thread.Sleep(500); 
            var numberTasks = 0;
            var numberDone = 0;
            foreach (var t in _context.Tasks)
            {
                _context.Tasks.Remove(t);
            } 
            foreach (var l in list.tasks)
            {
                _context.Tasks.Add(new Task { IsDone = l.isDone, Title = l.title });
                numberTasks++;
                if (l.isDone)
                {
                    numberDone++;
                }
            } 
            _context.SaveChanges(); 
            return Content(string.Format("the server got {0} tasks, {1} of which are done ", numberTasks, numberDone ));
        }



        public JsonResult GetCategories()
        { 
            Thread.Sleep(500); 
            var l = _context.Categories.Select(x => new CategoryViewModel 
            {
                name = x.Name 
            }); 
            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveCategories(CategoryList list)
        { 
            foreach (var t in _context.Categories)
            {
                _context.Categories.Remove(t);
            } 
            foreach (var l in list.categories)
            {
                _context.Categories.Add(new Category { Name = l.name }); 
            } 
            _context.SaveChanges(); 
            return Content(string.Format("the server got the categories "));
        }

    }

    public class TagList
    {
        public TagViewModel[] tags { get; set; }
    }
    public class TagViewModel
    {
        public int tagId { get; set; } 
        public string name { get; set; }
        public bool isInArticle { get; set; }
    }
    public class TaskList
    {
        public TaskViewModel[] tasks { get; set; }
    }
    public class TaskViewModel
    {
        public string title { get; set; }
        public bool isDone { get; set; }
    }
    public class CategoryList 
    {
        public CategoryViewModel[] categories { get; set; }
    }
    public class CategoryViewModel
    {
        public string name { get; set; } 
    }
}
