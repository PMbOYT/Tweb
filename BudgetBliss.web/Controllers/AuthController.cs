using System.Linq;
using System.Web.Mvc;
using BudgetBliss.web.Models;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace BudgetBliss.web.Controllers
{
    public class AuthController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Introdu username și parolă.";
                return View();
            }

            
            string hashedPassword = ComputeSha256Hash(password);

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Username sau parolă incorecte.";
            return View();
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
