using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGSM
{
    internal static class Extention
    {
        public static Task WaitForExitAsync(this Process p)
        {
            p.EnableRaisingEvents = true;
            var tcs = new TaskCompletionSource<object>();
            p.Exited += (s, e) => tcs.TrySetResult(null);
            if (p.HasExited)
                tcs.TrySetResult(null);
            return tcs.Task;
        }
    }
}
