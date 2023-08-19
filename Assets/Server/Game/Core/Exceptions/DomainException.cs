using System;

namespace Game.Core.Exceptions {

public class DomainException : Exception {
  public DomainException() {}

  public DomainException(string message) : base(message) {}

  public DomainException(string message, Exception cause)
      : base(message, cause) {}
}

}  // namespace Game.Core.Exceptions
