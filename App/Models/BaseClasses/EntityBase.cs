namespace Models
{
    public abstract class EntityBase<T>
    {
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
