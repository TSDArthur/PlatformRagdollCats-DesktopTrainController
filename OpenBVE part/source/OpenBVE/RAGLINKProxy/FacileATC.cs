using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using OpenBve;
using OpenBveApi.Runtime;
using System.Diagnostics;

namespace OpenBve
{
	class FacileATC
	{
		static public int GetSeconds(string currentTime, string targetTime)
		{
			int ret = 0;
			try
			{
				if (currentTime == "N/A" || targetTime == "N/A") return ret;
				string[] current = new string[3];
				string[] target = new string[3];
				current = currentTime.Split(':');
				target = targetTime.Split(':');
				int currentHour, currentMinute, currentSeconds;
				int targetHour, targetMinute, targetSecounds;
				if (current[0] == string.Empty) return ret;
				currentHour = Int32.Parse(current[0]);
				currentMinute = Int32.Parse(current[1]);
				currentSeconds = Int32.Parse(current[2]);
				targetHour = Int32.Parse(target[0]);
				targetMinute = Int32.Parse(target[1]);
				targetSecounds = Int32.Parse(target[2]);
				ret = (targetHour - currentHour) * 3600 + (targetMinute - currentMinute) * 60 + (targetSecounds - currentSeconds);
			}catch(Exception ex) { };
			return ret;
		}

		static public double ATCCalcError(int timeDelta, double currentSpeed, double distanceDelta)
		{
			double ret = Int32.MaxValue;
			try
			{
				ret = distanceDelta - 0.8;
				return ret;
			}catch (Exception ex) { };
			return ret;
		}

		static private double ATCError = 0;
		static private double LastATCError = 0;
		static private double kp = 0.08;
		static private double ki = 0;
		static private double kd = 0.1;
		static private double p = 0;
		static private double i = 0;
		static private double d = 0;

		static public double GetControlSpeedValue(string currentTime, string targetTime, double speedLimit, double currentSpeed, double DistanceDelta)
		{
			double ret = 0;
			ATCError = ATCCalcError(GetSeconds(currentTime, targetTime), currentSpeed, DistanceDelta);
			p = ATCError;
			i += p;
			d = ATCError - LastATCError;
			LastATCError = ATCError;
			//
			if(DistanceDelta > 2)ret = Math.Min(speedLimit, Math.Max(1.2, kp * p + ki * i + kd * d));
			else ret = Math.Min(speedLimit, Math.Max(0, kp * p + ki * i + kd * d));
			return ret;
		}
	}
}
