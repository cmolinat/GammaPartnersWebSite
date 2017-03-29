using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreMVC.Models;
using StoreMVC.CustomFilters;
using System.Net;
using StoreMVC.App_Start;
using System.IO;

namespace StoreMVC.Controllers
{

    public class StoreController : Controller
    {
        private StoreContext db = new StoreContext();

        //
        // GET: /Store/

        public ActionResult Index()
        {
           
            return View(db.Job.ToList());
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job product = db.Job
                .Include(p => p.Details)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult GetCommentsByJob(int JobId)
        {
            var CommentList = db.JobComments.Where(c => c.JobId == JobId)
                .ToList();
            return PartialView("_JobComments", CommentList);
        }
        [HttpPost]
        public ActionResult Comment(JobComment comment)
        {
            Resp resp = new Resp();
            JobComment inComment = new JobComment()
            {
                JobId = comment.JobId,
                SubmittedBy = comment.SubmittedBy,
                Comment = comment.Comment,
                DateSubmitted = DateTime.Now,
                Rating = comment.Rating
            };
            db.JobComments.Add(inComment);
            int res = db.SaveChanges();
            if (res > 0)
            {
                resp.Error = false;
                resp.Message = "Comment saved!";
                resp.ReturnUrl = "";
            }
            else
            {
                resp.Error = true;


            }
            return Json(resp);
         
        }
        public ActionResult NewRequest()
        {
            return View();
        }
        //
        // GET: /Store/Create
        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult NewRequest(JobRequest jobRequest, HttpPostedFileBase FileName)
        {
            Resp resp = new Resp();
            Resp isValidFile = CustomMethods.ValidateImage(FileName);
            if (!isValidFile.Error)
            {
                if (ModelState.IsValid)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(FileName.FileName));
                    FileName.SaveAs(path);
                    db.JobRequests.Add(new JobRequest
                    {
                        SubmittedBy = jobRequest.SubmittedBy,
                        Email = jobRequest.Email,
                        Phone = jobRequest.Phone,
                        Message = jobRequest.Message,
                        FileName = "~/Images/" + FileName.FileName,
                        DateSubmitted = DateTime.Now
                    });
                    if (db.SaveChanges() > 0)
                    {
                        resp.Error = false;
                        resp.Message = "Request saved!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        resp.Error = true;
                    }

                }
            }
            else
            {
                ModelState.AddModelError("ext_error",isValidFile.Message );
            }
            return View(jobRequest);

        }
        [CustomAuthorize(Roles ="Administrator")]
        public ActionResult ListRequests()
        {
           
            return View("Requests",db.JobRequests.ToList());
        }
        //
        // POST: /Store/Create

        [HttpPost]
        [CustomAuthorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        //
        // GET: /Store/Edit/5
        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        [CustomAuthorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", job.CategoryId);
            return View(job);
        }

        //
        // GET: /Store/Delete/5
        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Store/Delete/5
        [CustomAuthorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Job.Find(id);
            db.Job.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}