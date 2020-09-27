using System;

namespace Common.Models.Entities.Base {
    public class BaseEntity<T>
        where T : IEquatable<T> {
        public T Id { get; set; }
    }
}
