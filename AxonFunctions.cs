using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace synapsesex
{
	// Token: 0x02000002 RID: 2
	internal class AxonFunctions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Inject()
		{
			try
			{
				AxonFunctions.LogMessage("=== INJECTION START ===");
				if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
				{
					AxonFunctions.LogMessage("Already injected - named pipe exists");
					MessageBox.Show("Already injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
				{
					AxonFunctions.LogMessage("Named pipe check failed - returning early");
				}
				else
				{
					bool is64BitProcess = Environment.Is64BitProcess;
					AxonFunctions.LogMessage(string.Format("Host process is 64-bit: {0}", is64BitProcess));
					ValueTuple<string, string, string, string, bool>[] array = new ValueTuple<string, string, string, string, bool>[]
					{
						new ValueTuple<string, string, string, string, bool>("", "2010", "", AxonFunctions.exploitdllname, true),
						new ValueTuple<string, string, string, string, bool>("", "2011", "", AxonFunctions.exploitdllname5, true),
						new ValueTuple<string, string, string, string, bool>("", "2012", "", AxonFunctions.exploitdllname2, true),
						new ValueTuple<string, string, string, string, bool>("", "2013", "", AxonFunctions.exploitdllname4, true),
						new ValueTuple<string, string, string, string, bool>("", "2014", "", AxonFunctions.exploitdllname3, true),
						new ValueTuple<string, string, string, string, bool>("", "RobloxApp_Client", "2010L", AxonFunctions.exploitdllname, true),
						new ValueTuple<string, string, string, string, bool>("", "Roblox", "2014M", AxonFunctions.exploitdllname6, true),
						new ValueTuple<string, string, string, string, bool>("", "Roblox", "2014E", AxonFunctions.exploitdllname7, true),
						new ValueTuple<string, string, string, string, bool>("", "SyntaxPlayerBeta", "Client2012", AxonFunctions.exploitdllname8, true),
						new ValueTuple<string, string, string, string, bool>("", "SyntaxPlayerBeta", "Client2014", AxonFunctions.exploitdllname9, true),
						new ValueTuple<string, string, string, string, bool>("", "BBPlayerBeta", "2020", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "CartiPlayerBeta", "2020", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "KornetPlayerBeta", "2020", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "BloxxiaPlayerBeta", "2020", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "SyntaxPlayerBeta", "Client2020", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "RobloxPlayerBeta", "2020L", AxonFunctions.exploitdllname10, true),
						new ValueTuple<string, string, string, string, bool>("", "Ferns", "", AxonFunctions.exploitdllname11, true),
						new ValueTuple<string, string, string, string, bool>("", "ProjectXPlayerBeta", "2021M", AxonFunctions.exploitdllname11, true),
						new ValueTuple<string, string, string, string, bool>("", "Polytoria Client", "", AxonFunctions.exploitdllname12, true)
					};
					AxonFunctions.LogMessage(string.Format("Total injection targets: {0}", array.Length));
					foreach (ValueTuple<string, string, string, string, bool> valueTuple in array)
					{
						AxonFunctions.LogMessage(string.Concat(new string[] { "\n--- Trying: ", valueTuple.Item2, " (DLL: ", valueTuple.Item4, ") ---" }));
						uint num = 0U;
						string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, valueTuple.Item4);
						AxonFunctions.LogMessage("DLL path: " + text);
						AxonFunctions.LogMessage(string.Format("DLL exists: {0}", File.Exists(text)));
						if (!File.Exists(text))
						{
							AxonFunctions.LogMessage("DLL not found, skipping...");
						}
						else
						{
							if (valueTuple.Item5)
							{
								AxonFunctions.LogMessage("Scanning for process: " + valueTuple.Item2);
								Process[] processesByName = Process.GetProcessesByName(valueTuple.Item2);
								AxonFunctions.LogMessage(string.Format("Found {0} process(es) with name {1}", processesByName.Length, valueTuple.Item2));
								if (processesByName.Length == 0)
								{
									AxonFunctions.LogMessage("No processes found, skipping...");
									goto IL_0649;
								}
								bool flag = false;
								foreach (Process process in processesByName)
								{
									try
									{
										string text2 = "";
										try
										{
											ProcessModule mainModule = process.MainModule;
											text2 = ((mainModule != null) ? mainModule.FileName : null) ?? "";
											bool flag2 = !AxonFunctions.Is32BitProcess(process);
											AxonFunctions.LogMessage("  Target process architecture: " + (flag2 ? "64-bit" : "32-bit"));
										}
										catch (Win32Exception ex)
										{
											AxonFunctions.LogMessage("  Cannot access module path: " + ex.Message);
											bool flag2 = !is64BitProcess;
											AxonFunctions.LogMessage("  Assuming target is 64-bit based on host architecture");
										}
										AxonFunctions.LogMessage(string.Format("  Process ID: {0}, Path: {1}", process.Id, text2));
										if (string.IsNullOrEmpty(valueTuple.Item3) || text2.Contains(valueTuple.Item3))
										{
											num = (uint)process.Id;
											flag = true;
											AxonFunctions.LogMessage(string.Format("  MATCHED! Using PID: {0}", num));
											break;
										}
										AxonFunctions.LogMessage("  No match (looking for: '" + valueTuple.Item3 + "' in path)");
									}
									catch (Exception ex2)
									{
										AxonFunctions.LogMessage("  Exception accessing process: " + ex2.Message);
									}
								}
								if (!flag)
								{
									AxonFunctions.LogMessage("No matching process found, skipping...");
									goto IL_0649;
								}
							}
							else
							{
								if (string.IsNullOrEmpty(valueTuple.Item1))
								{
									AxonFunctions.LogMessage("Direct PID is empty, skipping...");
									goto IL_0649;
								}
								if (!uint.TryParse(valueTuple.Item1, out num))
								{
									AxonFunctions.LogMessage("Failed to parse PID, skipping...");
									goto IL_0649;
								}
							}
							if (valueTuple.Item2 == "Polytoria Client")
							{
								AxonFunctions.LogMessage(string.Format("Calling InjectViaExecutable with PID {0} and DLL {1}", num, text));
								if (AxonFunctions.InjectViaExecutable(is64BitProcess, num, text))
								{
									AxonFunctions.LogMessage("Injection successful!");
									return;
								}
								AxonFunctions.LogMessage("Injection failed, trying next target...");
							}
							else
							{
								AxonFunctions.LogMessage(string.Format("Calling SXREInjector.Inject with PID {0} and DLL {1}", num, text));
								string text3;
								if (SXREInjector.Inject((int)num, text, out text3))
								{
									AxonFunctions.LogMessage("Injection successful!");
									return;
								}
								AxonFunctions.LogMessage("Injection failed: " + text3);
								AxonFunctions.LogMessage("Injection failed, trying next target...");
							}
						}
						IL_0649:;
					}
					AxonFunctions.LogMessage("=== INJECTION FAILED - No compatible process found ===");
					MessageBox.Show("Injection failed! No compatible process found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex3)
			{
				AxonFunctions.LogMessage("FATAL EXCEPTION: " + ex3.Message + "\n" + ex3.StackTrace);
				MessageBox.Show("Fatal error during injection: " + ex3.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002764 File Offset: 0x00000964
		private static bool InjectViaExecutable(bool isHost64Bit, uint processId, string dllPath)
		{
			bool flag;
			try
			{
				string text = "Injector.exe";
				if (Environment.Is64BitOperatingSystem && File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DLLs\\Injector64.exe")))
				{
					text = "Injector64.exe";
					AxonFunctions.LogMessage("Using 64-bit injector");
				}
				string text2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DLLs\\" + text);
				if (!File.Exists(text2))
				{
					AxonFunctions.LogMessage("ERROR: " + text + " not found at " + text2);
					flag = false;
				}
				else
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo
					{
						FileName = text2,
						Arguments = string.Format("{0} --dll \"{1}\"", processId, dllPath),
						UseShellExecute = false,
						RedirectStandardOutput = true,
						RedirectStandardError = true,
						CreateNoWindow = true
					};
					AxonFunctions.LogMessage("Starting injector: " + processStartInfo.FileName);
					AxonFunctions.LogMessage("Arguments: " + processStartInfo.Arguments);
					using (Process process = Process.Start(processStartInfo))
					{
						if (process == null)
						{
							AxonFunctions.LogMessage("ERROR: Injector process is null!");
							flag = false;
						}
						else
						{
							AxonFunctions.LogMessage(string.Format("Injector process started with ID: {0}", process.Id));
							string text3 = process.StandardOutput.ReadToEnd();
							string text4 = process.StandardError.ReadToEnd();
							process.WaitForExit(10000);
							AxonFunctions.LogMessage(string.Format("Injector exit code: {0}", process.ExitCode));
							if (!string.IsNullOrEmpty(text3))
							{
								AxonFunctions.LogMessage("[INJECTOR OUTPUT]\n" + text3);
							}
							if (!string.IsNullOrEmpty(text4))
							{
								AxonFunctions.LogMessage("[INJECTOR ERROR]\n" + text4);
							}
							bool flag2 = process.ExitCode == 0;
							AxonFunctions.LogMessage("Injection result: " + (flag2 ? "SUCCESS" : "FAILED"));
							flag = flag2;
						}
					}
				}
			}
			catch (Exception ex)
			{
				AxonFunctions.LogMessage("[EXCEPTION] " + ex.Message + "\n" + ex.StackTrace);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000299C File Offset: 0x00000B9C
		private static bool Is32BitProcess(Process process)
		{
			if (!Environment.Is64BitOperatingSystem)
			{
				return true;
			}
			bool flag = false;
			try
			{
				flag = process.MainModule != null;
			}
			catch
			{
				return false;
			}
			return flag;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000029D8 File Offset: 0x00000BD8
		private static void LogMessage(string message)
		{
			try
			{
				string text = DateTime.Now.ToString("HH:mm:ss.fff");
				string text2 = "[" + text + "] " + message;
				File.AppendAllText(AxonFunctions.logPath, text2 + Environment.NewLine);
			}
			catch
			{
			}
		}

		// Token: 0x04000001 RID: 1
		private static string logPath = "injection_debug.txt";

		// Token: 0x04000002 RID: 2
		public static string exploitdllname = "DLLs\\DiddyWare2010.dll";

		// Token: 0x04000003 RID: 3
		public static string exploitdllname2 = "DLLs\\DiddyWare2012.dll";

		// Token: 0x04000004 RID: 4
		public static string exploitdllname3 = "DLLs\\DiddyWare2014.dll";

		// Token: 0x04000005 RID: 5
		public static string exploitdllname4 = "DLLs\\DiddyWare2013.dll";

		// Token: 0x04000006 RID: 6
		public static string exploitdllname5 = "DLLs\\DiddyWare2011.dll";

		// Token: 0x04000007 RID: 7
		public static string exploitdllname6 = "DLLs\\DiddyWare2014M.dll";

		// Token: 0x04000008 RID: 8
		public static string exploitdllname7 = "DLLs\\DiddyWare2014E.dll";

		// Token: 0x04000009 RID: 9
		public static string exploitdllname8 = "DLLs\\DiddyWareSynt2x2012.dll";

		// Token: 0x0400000A RID: 10
		public static string exploitdllname9 = "DLLs\\DiddyWareSynt2x2014.dll";

		// Token: 0x0400000B RID: 11
		public static string exploitdllname10 = "DLLs\\DiddyWare2020L.dll";

		// Token: 0x0400000C RID: 12
		public static string exploitdllname11 = "DLLs\\DiddyWare2021M.dll";

		// Token: 0x0400000D RID: 13
		public static string exploitdllname12 = "DLLs\\DiddyWarePolytoria.dll";

		// Token: 0x0400000E RID: 14
		public static OpenFileDialog openfiledialog = new OpenFileDialog
		{
			Filter = "Script File|*.txt;*.lua|All files (*.*)|*.*",
			FilterIndex = 1,
			RestoreDirectory = true,
			Title = "Synapse X Script Loader"
		};
	}
}
