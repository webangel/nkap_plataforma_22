using System;

using System.Web;
using System.Web.Security;

namespace Common
{
  public  class UserSessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
            DeleteTipo();
        }


        public static void AddTipeUser(string type)
        {
            HttpCookie tipo = new HttpCookie("Typeuser", type);
            tipo.Expires = DateTime.Now.AddMonths(3);
            HttpContext.Current.Response.Cookies.Add(tipo);
        }


        public static void DeleteTipo()
        {
            var p = new HttpCookie("Typeuser");
            p.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(p);

        }
        public static int GetUser()
        {
            int user_id = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    user_id = Convert.ToInt32(ticket.UserData);
                }
            }
            return user_id;
        }
        public static void AddUserToSession(string id)
        {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usernkap28Tse*", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(3);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
