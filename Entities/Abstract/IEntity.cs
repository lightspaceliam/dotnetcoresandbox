using System;

namespace Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
    }
}
