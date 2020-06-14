using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Infra.Data
{
    public class LotteryContext
    {
        internal readonly string[] MockTitles = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        internal readonly string[] MockNames = new[]
        {
            "Creator A", "Creator B", "Creator C", "Creator D"
        };

        internal readonly string[] MockDescriptions = new[]
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu erat vehicula, pretium justo vitae, egestas libero. Suspendisse potenti. Donec interdum accumsan felis, vitae condimentum magna. Etiam sagittis, nulla in convallis molestie, dui est sollicitudin elit, ut sollicitudin metus risus eu urna. Vivamus at sagittis nunc. Duis euismod mattis nisi. Morbi rutrum nisl eu lacinia rutrum.",
            "Curabitur ullamcorper lacus sit amet sagittis rhoncus. Nullam varius tortor vitae lectus faucibus, et vestibulum justo congue. Cras sit amet ornare nunc, a blandit quam.",
            "Sed facilisis quis dui et ornare. Curabitur non pulvinar risus. Aenean mi dui, tempor volutpat consectetur hendrerit, tincidunt quis est. Duis aliquam malesuada felis. Proin nisi augue, tristique id purus vitae, suscipit ornare ipsum. Fusce ultricies neque mauris, et dapibus dui imperdiet quis. Integer laoreet laoreet sem, vitae cursus ligula finibus sed. Sed rutrum in sapien sed sodales."
        };
    }
}
