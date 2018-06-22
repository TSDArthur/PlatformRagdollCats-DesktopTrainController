using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using OpenBve;
using OpenBveApi.Runtime;

namespace OpenBve
{
	public partial class TrainMethods
	{
		static private TrainManager.Train nowControl;
		//for autopilot
		static int constSpeed = 0;
		static int TimerTick = 500;
		private static int inTimer = 0;
		private static bool initTimer = false;
		private static double destSpeed = 0;
		private static System.Threading.Timer APTimer;
		//for master key
		private static bool MasterKey = false;
		//for main timer
		private static int inTimer_Main = 0;
		private static System.Threading.Timer MainTimer;
		//for emergenct
		private static bool Emergency = false;
		//for horn
		private static bool inHorn = false;
		//for signal
		private static bool inRedLight = false;
		/// <summary>
		/// setup ap timer
		/// </summary>
		static private void APAttachTimerInterrupt(int Tick)
		{
			try
			{
				initTimer = true;
				inTimer = 0;
				APTimer = new System.Threading.Timer(new System.Threading.TimerCallback(AutoPilotProcess),null, TimerTick, TimerTick);
			}
			catch (Exception ex){}
		}

		/// <summary>
		/// setup main timer
		/// </summary>
		static public void AttachMainTimerInterrupt(int Tick)
		{
			try
			{
				inTimer_Main = 0;
				MainTimer = new System.Threading.Timer(new System.Threading.TimerCallback(MainTimerProcess), null, TimerTick, TimerTick);
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// main timer interrupt
		/// </summary>
		static private void MainTimerProcess(object state)
		{
			if (Interlocked.Exchange(ref inTimer_Main, 1) == 0)
			{
				try
				{
					nowControl = TrainManager.PlayerTrain;
					//Master key
					if (!MasterKey)
					{
						SetAutoPilot(0);
						SetBrake(0);
						SetPower(0);
						ReverserNeutral();
					}

					//emergency
					if (Emergency)
					{
						SetAutoPilot(0);
						TrainManager.ApplyEmergencyBrake(nowControl);
					}
					else
					{
						TrainManager.UnapplyEmergencyBrake(nowControl);
					}

					//signal
					if (GetSignal() == 0) inRedLight = true;
					else
					{
						if (inRedLight)
						{
							SetBrake(nowControl.Handles.Brake.MaximumNotch);
							SetReverser(0);
							SetAutoPilot(0);
						}
						inRedLight = false;
					}
				}
				catch (Exception ex) { }
				Interlocked.Exchange(ref inTimer_Main, 0);
			}
		}

		/// <summary>
		/// power up
		/// </summary>
		static public void PowerUp()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				if (nowControl.Handles.EmergencyBrake.Actual) TrainManager.UnapplyEmergencyBrake(nowControl);
				if (currentBrake > 0) nowControl.ApplyNotch(0, true, -1, true);
				else nowControl.ApplyNotch(1, true, 0, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// power down
		/// </summary>
		static public void PowerDown()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				if (currretPower > 0) nowControl.ApplyNotch( -1, true, 0, true);
				else nowControl.ApplyNotch( 0, true, 1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set power
		/// </summary>
		static public void SetPower(int value)
		{
			try
			{
				nowControl.ApplyNotch( value < 0 ? 0 : value, false, 0, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set power
		/// </summary>
		static public void SetBrake(int value)
		{
			try
			{
				nowControl.ApplyNotch( 0, true, value < 0 ? 0 : value, false);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// reserver forward
		/// </summary>
		static public void ReverserForward()
		{
			try
			{
				TrainManager.ApplyReverser(nowControl, 1, true);
				TrainManager.ApplyReverser(nowControl, 1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// reserver neutral
		/// </summary>
		static public void ReverserNeutral()
		{
			try
			{
				TrainManager.ApplyReverser(nowControl, 1, true);
				TrainManager.ApplyReverser(nowControl, 1, true);
				TrainManager.ApplyReverser(nowControl, -1, true);
				return;
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// reserver backward
		/// </summary>
		static public void ReverserBackward()
		{
			try
			{
				TrainManager.ApplyReverser(nowControl, -1, true);
				TrainManager.ApplyReverser(nowControl, -1, true);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// set reverser
		/// </summary>
		static public void SetReverser(int value)
		{
			try
			{
				TrainManager.ApplyReverser(nowControl, value, false);
				return;
			}
			catch (Exception ex) { }
		}

		/// <summary>
		/// get now speed
		/// </summary>
		static public int GetSpeed()
		{
			try
			{
				int currentDriveCar = nowControl.DriverCar;
				return (int)(nowControl.Cars[currentDriveCar].Specs.CurrentSpeed * 3.6);
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now reserver state
		/// </summary>
		static public int GetReverser()
		{
			try
			{
				TrainManager.ReverserPosition ReverserPos = nowControl.Handles.Reverser.Driver;
				TrainManager.ReverserPosition Reverse = TrainManager.ReverserPosition.Reverse;
				TrainManager.ReverserPosition Neutral = TrainManager.ReverserPosition.Neutral;
				return ReverserPos == Reverse ? -1 : (ReverserPos == Neutral ? 0 : 1);
			}
			catch(Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now power notch
		/// </summary>
		static public int GetPower()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				return currretPower;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now brake notch
		/// </summary>
		static public int GetBrake()
		{
			try
			{
				int currretPower = nowControl.Handles.Power.Driver;
				int currentBrake = nowControl.Handles.Brake.Driver;
				return currentBrake;
			}
			catch (Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get now speed limit
		/// </summary>
		static public int GetSpeedLimit()
		{
			try
			{
				int ret = (int)Math.Min(Math.Abs(nowControl.CurrentSectionLimit * 3.6), Math.Abs(nowControl.CurrentRouteLimit * 3.6));
				if (ret > 350 || ret < 0) return 30;
				return ret;
			}
			catch(Exception ex) { }
			return 30;
		}

		/// <summary>
		/// get now signal aspect
		/// </summary>
		static public int GetSignal()
		{
			try
			{
				return Game.Sections[Game.Sections[nowControl.CurrentSectionIndex].NextSection].CurrentAspect;
			}
			catch(Exception ex) { }
			return 0;
		}

		/// <summary>
		/// get dis to next signal
		/// </summary>
		static public int GetSignalDis()
		{
			try
			{
				return (int)((Game.Sections[Game.Sections[nowControl.CurrentSectionIndex].NextSection].TrackPosition * 3.6 - nowControl.Cars[nowControl.DriverCar].FrontAxle.Follower.TrackPosition * 3.6));
			}
			catch(Exception ex) { }
			return 0;
		}

		/// <summary>
		/// horn start function
		/// </summary>
		static public void HornStart()
		{
			try
			{
				nowControl.Cars[nowControl.DriverCar].Horns[0].Play();
				return;
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// horn end function
		/// </summary>
		static public void HornStop()
		{
			try
			{
				nowControl.Cars[nowControl.DriverCar].Horns[0].Stop();
				return;
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// set horn
		/// </summary>
		static public void SetHorn(int value)
		{
			try
			{
				if (value == 0)
				{
					inHorn = false;
					HornStop();
				}
				else
				{
					if (!inHorn)
					{
						HornStart();
						inHorn = true;
					}
				}
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// set autopilot state
		/// </summary>
		static public void SetAutoPilot(int setSpeed)
		{
			try
			{
				constSpeed = setSpeed;
				if (setSpeed <= 0)
				{
					if (initTimer)
						APTimer.Change(Timeout.Infinite, Timeout.Infinite);
					destSpeed = 0;
				}
				else
				{
					if (!initTimer)
						APAttachTimerInterrupt(TimerTick);
					else
						APTimer.Change(TimerTick, TimerTick);
					destSpeed = constSpeed / 3.6;
				}
				return;
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// autopilot process
		/// </summary>
		static private void AutoPilotProcess(object state)
		{
			if (Interlocked.Exchange(ref inTimer, 1) == 0)
			{
				if (constSpeed > 0)
				{
					try
					{
						//PID const
						//set destSpeed
						destSpeed = Math.Min(GetSpeedLimit() / 3.6, constSpeed / 3.6);
						//get accurate speed
						int currentDriveCar = TrainManager.PlayerTrain.DriverCar;
						double currentSpeed = (TrainManager.PlayerTrain.Cars[currentDriveCar].Specs.CurrentSpeed);
						double accSpeed = TrainManager.PlayerTrain.Cars[currentDriveCar].Specs.CurrentAcceleration;
						//
						if (inRedLight)
						{
							if (GetSignalDis() / currentSpeed <= 15 && Math.Abs(currentSpeed / (Math.Abs(accSpeed) + 1e-5)) <= 30) destSpeed = 0;
							else destSpeed = Math.Min(30 / 3.6, destSpeed);
						}
						//
						double relativeSpeed = destSpeed - currentSpeed;
						double K1 = 0.8;
						//PID control
						if (relativeSpeed > 0)
						{
							SetBrake(0);
							if (accSpeed < 0) PowerUp();
							if (accSpeed > 0)
							{
								if (Math.Abs(relativeSpeed / accSpeed) <= K1) PowerDown();
								else PowerUp();
							}
						}
						else if (relativeSpeed < 0)
						{
							SetPower(0);
							if (accSpeed > 0) PowerDown();
							if (accSpeed < 0)
							{
								if (Math.Abs(relativeSpeed / accSpeed) <= K1) PowerUp();
								else PowerDown();
							}
						}
					}
					catch (Exception ex) { }
				}
				Interlocked.Exchange(ref inTimer, 0);
			}
		}

		static public int GetConstSpeed()
		{
			return (int)(destSpeed * 3.6);
		}

		static public int GetSetConstSpeed()
		{
			return (int)(constSpeed*3.6);
		}

		/// <summary>
		/// set master key
		/// </summary>
		static public void SetMasterKey(int value)
		{
			try
			{
				MasterKey = value == 0 ? false : true;
				if (!MasterKey)
				{
					SetAutoPilot(0);
					SetBrake(0);
					SetPower(0);
					ReverserNeutral();
				}
			}
			catch(Exception ex) { }
		}

		/// <summary>
		/// set emergency
		/// </summary>
		static public void SetEmergency(int value)
		{
			try
			{
				Emergency = value == 0 ? false : true;
				TrainManager.Train nowControl = TrainManager.PlayerTrain;
				if (Emergency)
				{
					TrainManager.ApplyEmergencyBrake(nowControl);
				}
				else
				{
					TrainManager.UnapplyEmergencyBrake(nowControl);
				}
			}
			catch(Exception ex) { }
		}

	}
}
