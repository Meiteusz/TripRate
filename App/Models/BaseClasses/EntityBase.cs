namespace Models
{
    public abstract class EntityBase<T>
    {
        /// <summary>
        /// Save the any entity in a specific context
        /// </summary>
        /// <param name="context">specific context witch the entity is inserted</param>
        /// <returns>A Response Dto with Success and Message</returns>
        public virtual Response Save(TripRateContext context)
        {
            context.ValidateStateOfEntity(this);
            return context.ResponseSaveChangesAsync();
        }

        /// <summary>
        /// Save the any entity in a any context
        /// </summary>
        /// <returns>A Response Dto with Success and Message</returns>
        public virtual Response Save()
        {
            return new Response();
        }

        public virtual Response Validate()
        {
            return new Response();
        }

        public virtual Response Saved()
        {
            return new Response();
        }
    }
}
