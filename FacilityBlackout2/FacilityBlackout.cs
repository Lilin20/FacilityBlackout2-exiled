using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace FacilityBlackout2
{
    public class FacilityBlackout : Plugin<Config>
    {
        public static FacilityBlackout Instance;
        public override string Name { get; } = "FacilityBlackout V2";
        public override string Author { get; } = "Lilin";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override string Prefix { get; } = "FBv2";
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public EventHandlers EventHandlers = new EventHandlers();

        public override void OnEnabled()
        {
            Instance = this;

            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += EventHandlers.OnRoundEnd;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnd;

            Instance = null;
            base.OnDisabled();
        }
    }
}
