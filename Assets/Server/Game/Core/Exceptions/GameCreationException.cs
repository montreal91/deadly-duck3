using System;

namespace Game.Core.Exceptions {

public class GameCreationException : DomainException {
  public GameCreationException() {}

  public GameCreationException(string message) : base(message) {}

  public GameCreationException(string message, Exception cause)
      : base(message, cause) {}
}

}  // namespace Game.Core.Exceptions
