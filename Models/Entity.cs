namespace Test.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public Entity()
        {
        }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}