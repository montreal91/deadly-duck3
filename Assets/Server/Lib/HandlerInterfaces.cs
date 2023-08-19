
namespace Lib {

public interface CommandHandler<CmdType, ResType> {
  public ResType Handle(CmdType command);
}

public interface QueryHandler<QueryType, ResType> {
  public ResType Handle(QueryType query);
}

}  // namespace Lib
