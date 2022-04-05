using System.Threading.Tasks;

namespace Models
{
    public abstract class EntityBase<T>
    {
        /// <summary>
        /// Save the any entity in a specific context
        /// </summary>
        /// <param name="context">specific context witch the entity is inserted</param>
        /// <returns>A Response Dto with Success and Message</returns>
        public virtual async Task<Response> SaveAsync(TripRateContext context)
        {
            context.ValidateStateOfEntity(this);
            return await context.ResponseSaveChanges();
        }

        /// <summary>
        /// Save the any entity in a any context
        /// </summary>
        /// <returns>A Response Dto with Success and Message</returns>
        public async virtual Task<Response> SaveAsync()
        {
            return new Response();
        }

        public async virtual Task<Response> Validate()
        {
            return new Response();
        }

        public async virtual Task<Response> Saved()
        {
            return new Response();
        }
    }
}
