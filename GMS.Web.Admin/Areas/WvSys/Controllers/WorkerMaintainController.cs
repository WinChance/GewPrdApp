using System.Data.Entity;
using System.Linq;
using System.Web.Http.Results;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WMIS.DAL.WVMDB;
using Z.EntityFramework.Plus;


namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class WorkerMaintainController : Controller
    {
        private WvmDbContext wvmDb = new WvmDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvWorkers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<peAppWvWorker> peappwvworkers = wvmDb.peAppWvWorkers;
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

                    wvmDb.peAppWvWorkers.Add(entity);
                    wvmDb.SaveChanges();
                    peAppWvWorker.Id = entity.Id;
                }

                return Json(new[] { peAppWvWorker }.ToDataSourceResult(request, ModelState));
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
                wvmDb.peAppWvWorkers.Attach(entity);
                wvmDb.Entry(entity).State = EntityState.Modified;
                wvmDb.SaveChanges();
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

                wvmDb.peAppWvWorkers.Attach(entity);
                wvmDb.peAppWvWorkers.Remove(entity);
                wvmDb.SaveChanges();
            }

            return Json(new[] { peAppWvWorker }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            wvmDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
