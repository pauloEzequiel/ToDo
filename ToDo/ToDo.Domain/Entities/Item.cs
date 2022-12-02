using System.Reflection.Metadata.Ecma335;
using ToDo.Domain.Extensions;

namespace ToDo.Domain.Entities
{
    public class Item
    {
        /// <summary>
        /// Put it after
        /// </summary>
        private Item()
        {

        }
        public Item(string task)
        {
            Id = Guid.NewGuid();
            Done = false;
            Description = task;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public void MarkAsDoneOrUnDone() => Done = !Done;


    }
}
