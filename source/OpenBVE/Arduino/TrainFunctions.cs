using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBve;
using OpenBveApi.Runtime;

namespace OpenBve
{
	public partial class TrainFunctions
	{
		/// <summary>
		/// power up
		/// </summary>
		static public void PowerUp()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			int currretPower = nowControl.Handles.Power.Actual;
			int currentBrake = nowControl.Handles.Brake.Actual;
			if (nowControl.Handles.EmergencyBrake.Actual) TrainManager.UnapplyEmergencyBrake(nowControl);
			if (currentBrake > 0) TrainManager.ApplyNotch(nowControl, 0, true, -1, true);
			else TrainManager.ApplyNotch(nowControl, 1, true, 0, true);
			return;
		}

		/// <summary>
		/// power down
		/// </summary>
		static public void PowerDown()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			int currretPower = nowControl.Handles.Power.Actual;
			int currentBrake = nowControl.Handles.Brake.Actual;
			if (currretPower > 0) TrainManager.ApplyNotch(nowControl, -1, true, 0, true);
			else TrainManager.ApplyNotch(nowControl, 0, true, 1, true);
			return;
		}

		/// <summary>
		/// reserver forward
		/// </summary>
		static public void ReverserForward()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			TrainManager.ApplyReverser(nowControl, 1, true);
			TrainManager.ApplyReverser(nowControl, 1, true);
			return;
		}

		/// <summary>
		/// reserver neutral
		/// </summary>
		static public void ReverserNeutral()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			TrainManager.ApplyReverser(nowControl, 1, true);
			TrainManager.ApplyReverser(nowControl, 1, true);
			TrainManager.ApplyReverser(nowControl, -1, true);
			return;
		}

		/// <summary>
		/// reserver backward
		/// </summary>
		static public void ReverserBackward()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			TrainManager.ApplyReverser(nowControl,-1, true);
			TrainManager.ApplyReverser(nowControl, -1, true);
			return;
		}

		/// <summary>
		/// get now speed
		/// </summary>
		static public int GetSpeed()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			int currentDriveCar = nowControl.DriverCar;
			return (int)(nowControl.Cars[currentDriveCar].Specs.CurrentSpeed * 3.6);
		}

		/// <summary>
		/// get now reserver state
		/// </summary>
		static public int GetReverser()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			return nowControl.Handles.Reverser.Actual == -1 ? 0 : (nowControl.Handles.Reverser.Actual == 0 ? 1 : 2);
		}

		/// <summary>
		/// get now power notch
		/// </summary>
		static public int GetPower()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl=TrainManager.PlayerTrain;
			int currretPower = nowControl.Handles.Power.Actual;
			int currentBrake = nowControl.Handles.Brake.Actual;
			if (currretPower > 0) return currretPower;
			else return -1 * currentBrake;
		}

		/// <summary>
		/// get now speed limit
		/// </summary>
		static public int GetSpeedLimit()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			int ret=(int)Math.Min(Math.Abs(nowControl.CurrentSectionLimit*3.6),Math .Abs (nowControl.CurrentRouteLimit * 3.6));
			if (ret > 350 || ret < 0) return 30;
			return ret;
		}

		/// <summary>
		/// get now signal aspect
		/// </summary>
		static public int GetSignal()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			return Game.Sections[Game.Sections[nowControl.CurrentSectionIndex].NextSection].CurrentAspect;
		}

		/// <summary>
		/// get dis to next signal
		/// </summary>
		static public int GetSignalDis()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			return (int)((Game.Sections[Game.Sections[nowControl.CurrentSectionIndex].NextSection].TrackPosition*3.6 - nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition * 3.6));
		}

		/// <summary>
		/// horn start function
		/// </summary>
		static public void HornStart()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			nowControl.Cars[nowControl.DriverCar].Horns[0].Play();
			return;
		}

		/// <summary>
		/// horn end function
		/// </summary>
		static public void HornStop()
		{
			TrainManager.Train nowControl = new TrainManager.Train();
			nowControl = TrainManager.PlayerTrain;
			nowControl.Cars[nowControl.DriverCar].Horns[0].Stop();
			return;
		}
	}
}
