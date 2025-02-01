using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace FacilityBlackout2
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public List<ZoneType> BlackoutZones { get; set; } = new List<ZoneType> { ZoneType.Entrance, ZoneType.LightContainment, ZoneType.HeavyContainment, ZoneType.Surface };

        [Description("Number of blackouts per round.")]
        public int BlackoutAmount { get; set; } = 5;

        [Description("The initial delay for the plugin itself. After this delay the plugin will use Min and Max delay.")]
        public int BlackoutRoundStartDelay { get; set; } = 150;

        [Description("Minimum delay until next blackout event.")]
        public int BlackoutMinimumDelay { get; set; } = 120;

        [Description("Maximum delay until next blackout event.")]
        public int BlackoutMaximumDelay { get; set; } = 180;

        [Description("Delay between each blackout event")]
        public int BlackoutDelayBetween { get; set; } = 60;

        [Description("Duration of each blackout.")]
        public int BlackoutDuration { get; set; } = 60;

        [Description("If an cassie announcement should be used or not")]
        public bool CassieEnabled { get; set; } = true;

        [Description("Text for cassie to say")]
        public string CassieText { get; set; } = "LIGHT SYSTEM MALFUNCTION . REPAIRING SYSTEMS";
    }
}
