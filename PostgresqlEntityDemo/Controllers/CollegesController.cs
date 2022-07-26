using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresqlEntityDemo.Data;
using PostgresqlEntityDemo.Models;
using System.Linq;

namespace PostgresqlEntityDemo.Controllers
{
    public class CollegesController : Controller
    {
        ApplicationDbContext _applicationDbContext;
        public CollegesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            IEnumerable<College> CollegeList = _applicationDbContext.Colleges.OrderByDescending(x => x.CollegeId);
            return View(CollegeList);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(College obj)
        {
            try
            {
                    _applicationDbContext.Colleges.Add(obj);
                    _applicationDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));  
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == 0 )
            {
                return NotFound();  
            }
            var collegeFormDb = _applicationDbContext.Colleges.Find(id);
            if(collegeFormDb == null)
            {
                return NotFound();
            }

            return View(collegeFormDb);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, College obj)
        {
            try
            {
                _applicationDbContext.Colleges.Update(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            if(id ==0 )
            {
                return NotFound();
            }
            var collegeDeleteDb = _applicationDbContext.Colleges.Find(id);  
            if(collegeDeleteDb == null) 
            { return NotFound(); }
            _applicationDbContext.Remove(collegeDeleteDb); 
            _applicationDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
