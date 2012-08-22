using System;
namespace Core.Model
{
	public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime ModifiedAt { get; set; }
	}
}
