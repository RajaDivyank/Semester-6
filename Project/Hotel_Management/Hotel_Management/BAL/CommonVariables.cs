namespace Hotel_Management.BAL
{
    public class CommonVariables
    {
        private static IHttpContextAccessor _httpContextAccessor;
        static CommonVariables()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public static bool IsManager()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("IsManager") != null)
            {
                if (_httpContextAccessor.HttpContext.Session.GetString("IsManager") == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool IsAdmin()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("IsAdmin") != null)
            {
                if (_httpContextAccessor.HttpContext.Session.GetString("IsAdmin") == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static int? UserID()
        {
            //Initialize the UserID with null
            int? UserID = null;
            //check if session contains specified key?
            //if it contains then return the value contained by the key.
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID =
               Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID").ToString());
            }
            return UserID;
        }
        public static string? UserName()
        {
            string? UserName = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName =
               _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }

            return UserName;
        }
        public static string? UserEmail()
        {
            string? UserEmail = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("Email") != null)
            {
                UserEmail =
               _httpContextAccessor.HttpContext.Session.GetString("Email").ToString();
            }

            return UserEmail;
        }
        public static string? UserNumber()
        {
            string? UserNumber = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserNumber") != null)
            {
                UserNumber =
               _httpContextAccessor.HttpContext.Session.GetString("UserNumber").ToString();
            }

            return UserNumber;
        }

    }
}
