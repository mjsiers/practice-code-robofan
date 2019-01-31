using System;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace RoboFan.Web.Filters
{
  public class DelayResponseFilter : IActionFilter
  {
    private static readonly ILogger _log = Log.ForContext<DelayResponseFilter>();
    private static readonly Random _rand = new Random();
    private static int _delayMin = 0;
    private static int _delayMax = 0;

    public static void SetResponseDelay(int min, int max)
    {
      _delayMin = min;
      _delayMax = max;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      // check to see if the delay is configured
      if ((_delayMin >= 0) && (_delayMax > 0)) {
        int delay;
        if (_delayMin == _delayMax)
        {
          // use the specified delay value
          delay = _delayMin;
        }
        else {
          delay = _rand.Next(_delayMin, _delayMax + 1);
        }

        // execute sleep to delay the response
        _log.Information("OnActionExecuted: Delay[{0}]", delay);
        Thread.Sleep(TimeSpan.FromSeconds(delay));
      }
    }
  }
}
