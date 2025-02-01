using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;

namespace FacilityBlackout2
{
    public class EventHandlers
    {
        List<ZoneType>availableZones = new List<ZoneType> ();
        private readonly Random random = new Random();
        private int _blackoutCount = 0;
        private bool _firstBlackoutFired = false;
        private CoroutineHandle _coroutineHandle;

        public void OnRoundStarted()
        {
            _blackoutCount = 0;
            _firstBlackoutFired = false;

            foreach (ZoneType zone in FacilityBlackout.Instance.Config.BlackoutZones)
            {
                availableZones.Add(zone);
            }

            Timing.CallDelayed(FacilityBlackout.Instance.Config.BlackoutRoundStartDelay, () =>
            {
                _coroutineHandle = Timing.RunCoroutine(BlackoutCoroutine());
            });
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines(_coroutineHandle);
            availableZones.Clear();
        }

        public ZoneType getRandomZone()
        {
            int zoneCount = availableZones.Count;
            if (zoneCount > 0)
            {
                int randomIndex = random.Next(zoneCount);
                ZoneType randomZone = availableZones[randomIndex];
                return randomZone;
            }
            return ZoneType.Unspecified;
        }

        public IEnumerator<float> BlackoutCoroutine()
        {
            while (_blackoutCount <= FacilityBlackout.Instance.Config.BlackoutAmount - 1)
            {
                int randomAdditionalDelay = random.Next(FacilityBlackout.Instance.Config.BlackoutMinimumDelay, FacilityBlackout.Instance.Config.BlackoutMaximumDelay);
                float cassieTime = Cassie.CalculateDuration(FacilityBlackout.Instance.Config.CassieText, false, 1);

                if (!_firstBlackoutFired)
                {
                    Log.Debug($"First Blackout: Additional Deilay - {randomAdditionalDelay} seconds until blackout.");
                    yield return Timing.WaitForSeconds(randomAdditionalDelay);

                    if (FacilityBlackout.Instance.Config.CassieEnabled)
                    {
                        Cassie.Message(FacilityBlackout.Instance.Config.CassieText, false, false, true);
                        yield return Timing.WaitForSeconds(cassieTime);
                    }

                    ZoneType selectedZone = getRandomZone();
                    Log.Debug($"Blackout Zone: {selectedZone}");
                    Map.TurnOffAllLights(FacilityBlackout.Instance.Config.BlackoutDuration, selectedZone);

                    _firstBlackoutFired = true;
                }
                else
                {
                    yield return Timing.WaitForSeconds(FacilityBlackout.Instance.Config.BlackoutDelayBetween);

                    Log.Debug($"Additional Blackouts: Additional Delay - {randomAdditionalDelay} seconds until blackout");
                    yield return Timing.WaitForSeconds(randomAdditionalDelay);

                    if (FacilityBlackout.Instance.Config.CassieEnabled)
                    {
                        Cassie.Message(FacilityBlackout.Instance.Config.CassieText, false, false, true);
                        yield return Timing.WaitForSeconds(cassieTime);
                    }

                    ZoneType selectedZone = getRandomZone();
                    Log.Debug($"Blackout Zone: {selectedZone}");
                    Map.TurnOffAllLights(FacilityBlackout.Instance.Config.BlackoutDuration, selectedZone);
                }
                _blackoutCount++;
            }
        }
    }
}
