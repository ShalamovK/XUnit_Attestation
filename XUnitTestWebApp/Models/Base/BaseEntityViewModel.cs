using System;

namespace XUnitTestWebApp.Models.Base {
    public class BaseEntityViewModel<T>
        where T : IEquatable<T> {

        public T Id { get; set; }
    }
}
