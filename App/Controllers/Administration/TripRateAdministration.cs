using Models;

namespace Controllers.Administration
{
    public abstract class TripRateAdministration
    {
        public static User CurrentUserLogged { get; private set; }

        public static void SetCurrentUserLogged(User user) 
            => CurrentUserLogged = user;

        public static bool ExistsUserLogged()
            => CurrentUserLogged != null;
    }
}
