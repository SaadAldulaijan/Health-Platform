namespace Health.Data.Models
{
    public abstract class BaseMode<T>
    {
        public T Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
    }
}
