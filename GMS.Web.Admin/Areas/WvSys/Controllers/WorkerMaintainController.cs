using System.Data.Entity;
using System.Linq;
using System.Web.Http.Results;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class WorkerMaintainController : Controller
    {
        private PrdAppDbContext db = new PrdAppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvWorkers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<peAppWvWorker> peappwvworkers = db.peAppWvWorkers;
            DataSourceResult result = peappwvworkers.ToDataSourceResult(request, peAppWvWorker => new {
                Id = peAppWvWorker.Id,
                factory = peAppWvWorker.factory,
                name = peAppWvWorker.name,
                cardno = peAppWvWorker.cardno,
                _class = peAppWvWorker._class,
                classdes = peAppWvWorker.classdes,
                jobs = peAppWvWorker.jobs,
                Audit = peAppWvWorker.Audit,
                WorkerType = peAppWvWorker.WorkerType,
                GroupName = peAppWvWorker.GroupName,
                Remark = peAppWvWorker.Remark
                
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvWorkers_Create([DataSourceRequest]DataSourceRequest request, peAppWvWorker peAppWvWorker)
        {
            var checkIfExisted=db.peAppWvWorkers.FirstOrDefault(w => w.cardno.Equals(peAppWvWorker.cardno)&&w.name.Equals(peAppWvWorker.name));
            if (checkIfExisted!=null)
            {
                return Json(new DataSourceResult
                {
                    Errors = "不能插入重复的数据！"
                });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var entity = new peAppWvWorker
                    {
                        factory = peAppWvWorker.factory,
                        name = peAppWvWorker.name,
                        cardno = peAppWvWorker.cardno,
                        _class = peAppWvWorker._class,
                        classdes = peAppWvWorker.classdes,
                        jobs = peAppWvWorker.jobs,
                        Audit = peAppWvWorker.Audit,
                        WorkerType = peAppWvWorker.WorkerType,
                        GroupName = peAppWvWorker.GroupName,
                        Remark = peAppWvWorker.Remark
                    };

                    db.peAppWvWorkers.Add(entity);
                    db.SaveChanges();
                    peAppWvWorker.Id = entity.Id;
                }

                return Json(new[] { peAppWvWorker }.ToDataSourceResult(request, ModelState));
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvWorkers_Update([DataSourceRequest]DataSourceRequest request, peAppWvWorker peAppWvWorker)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvWorker
                {
                    Id = peAppWvWorker.Id,
                    factory = peAppWvWorker.factory,
                    name = peAppWvWorker.name,
                    cardno = peAppWvWorker.cardno,
                    _class = peAppWvWorker._class,
                    classdes = peAppWvWorker.classdes,
                    jobs = peAppWvWorker.jobs,
                    Audit = peAppWvWorker.Audit,
                    WorkerType = peAppWvWorker.WorkerType,
                    GroupName = peAppWvWorker.GroupName,
                    Remark = peAppWvWorker.Remark
                };
                //// 联动修改所有工人的工种备注
                //if (peAppWvWorker.Remark.Length > 0)
                //{
                //    db.peAppWvWorkers.Where(w => w.cardno.Equals(peAppWvWorker.cardno)).Update(w => new peAppWvWorker
                //    {
                //        Remark = peAppWvWorker.Remark
                //    });
                //}
                db.peAppWvWorkers.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { peAppWvWorker }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvWorkers_Destroy([DataSourceRequest]DataSourceRequest request, peAppWvWorker peAppWvWorker)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvWorker
                {
                    Id = peAppWvWorker.Id,
                    factory = peAppWvWorker.factory,
                    name = peAppWvWorker.name,
                    cardno = peAppWvWorker.cardno,
                    _class = peAppWvWorker._class,
                    classdes = peAppWvWorker.classdes,
                    jobs = peAppWvWorker.jobs,
                    Audit = peAppWvWorker.Audit,
                    WorkerType = peAppWvWorker.WorkerType,
                    GroupName = peAppWvWorker.GroupName,
                    Remark = peAppWvWorker.Remark
                };

                db.peAppWvWorkers.Attach(entity);
                db.peAppWvWorkers.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { peAppWvWorker }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
