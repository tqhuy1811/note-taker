namespace note_taker_server.Helpers
{
  public class Utils
  {
    public static int CalculateSkipItems(int? skipItems)
    {
      return skipItems.HasValue ? (int) skipItems : 0;
    }
  }
}