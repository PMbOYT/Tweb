using BudgetBliss.Web.Models;
using System.Web.Mvc;
using System.Linq;         

public class AccountController : Controller
{
    private UserContext db = new UserContext();

    // GET: /Account/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModels model)
    {
        if (ModelState.IsValid)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                // Autentificare simplă (fără cookies/tokens aici)
                Session["UserId"] = user.Id;
                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login credentials.");
        }

        return View(model);
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login");
    }
}
