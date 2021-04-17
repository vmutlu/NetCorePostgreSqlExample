using PostgreSql.Core.Entities;
using System;

namespace PostgreSql.Entities.Concrate
{
    public class Example : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
