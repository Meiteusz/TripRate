namespace Models.BaseClasses
{
    public static class EntityBaseExtensions
    {
        public static int? ToLong(this int? value)
        {
            if (value == null || value < 1)
                return EntityConsts.Invalid_Id;
            return value;
        }

        public static bool IsValidId(this int value)
            => value != null && value > 0;
    }
}
