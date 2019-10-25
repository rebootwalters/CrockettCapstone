using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrockettWeb.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            try
            {
                List<UserBLL> users;
                using (ContextBLL ctx = new ContextBLL())
                {
                    users = ctx.UserGetAll(0, 100);
                    return View(users);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error",ex);
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                ViewBag.ListItems = items;
                UserBLL user;
                using (ContextBLL ctx = new ContextBLL())
                {
                    user = ctx.UserFindByID(id);
                    List<RoleBLL> roles = ctx.RoleGetAll(0, 100);

                    foreach (RoleBLL role in roles)
                    {
                        SelectListItem i = new SelectListItem();
                        i.Text = role.RoleName;
                        i.Value = role.RoleID.ToString();
                        items.Add(i);
                    }

                    return View(user);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL u)
        {
            try
            {
                
                using (ContextBLL ctx = new ContextBLL())
                {
                    u.UserID = id;
                    ctx.UserUpdateJust(u);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
