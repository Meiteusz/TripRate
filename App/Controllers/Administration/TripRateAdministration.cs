using Models;
using Models.BaseClasses;

namespace Controllers.Administration
{
    public static class TripRateAdministration
    {
        private static User CurrentUserLogged;

        public static User GetCurrentUserLogged()
            => CurrentUserLogged == null ? new User() : CurrentUserLogged;

        public static void SetCurrentUserLogged(User user) 
            => CurrentUserLogged = user;

        public static bool ExistsUserLogged()
            => CurrentUserLogged != null && CurrentUserLogged.Id.IsValidId();
    }
}
