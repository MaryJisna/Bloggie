using Bloggie.Web.Data;
using Bloggie.Web.Models.Domin;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly BloggieDBContext bloggieDBContext;

        public AdminTagController(BloggieDBContext bloggieDBContext)
        {
            this.bloggieDBContext = bloggieDBContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag(AddTagReq addTagReq)
        {

            //var name=Request.Form["name"];
            //var displayname = Request.Form["displayname"];       Read incoming req. one by one.  no need for this model binding more usefull.
            
            //*** mapping AddTagRequest to tag domain model
            var tag = new Tag
            {
                Name = addTagReq.Name,
                DisplayName = addTagReq.DisplayName
            };
            bloggieDBContext.Tags.Add(tag);
            bloggieDBContext.SaveChanges();
            //var name=addTagReq.Name;
            //var displayname = addTagReq.DisplayName;
            return View("Add");
        }
    }
}
