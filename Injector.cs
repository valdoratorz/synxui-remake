using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace synapsesex
{
	internal class Injector
	{
		public enum DllInjectionResult
		{
			DllNotFound,
			GameProcessNotFound,
			InjectionFailed,
			Success
		}

		public sealed class DllInjector
		{
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000057 RID: 87
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int CloseHandle(IntPtr hObject);

			// Token: 0x06000058 RID: 88
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

			// Token: 0x06000059 RID: 89
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);

			// Token: 0x0600005A RID: 90
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x0600005B RID: 91
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

			// Token: 0x0600005C RID: 92
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			// Token: 0x0600005D RID: 93
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

			// Token: 0x0600005E RID: 94
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern uint SuspendThread(IntPtr hThread);

			// Token: 0x0600005F RID: 95
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern uint ResumeThread(IntPtr hThread);

			// Token: 0x06000060 RID: 96
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

			// Token: 0x06000061 RID: 97
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool Thread32First(IntPtr hSnapshot, ref Injector.DllInjector.THREADENTRY32 lpte);

			// Token: 0x06000062 RID: 98
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool Thread32Next(IntPtr hSnapshot, ref Injector.DllInjector.THREADENTRY32 lpte);

			// Token: 0x06000063 RID: 99
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000064 RID: 100 RVA: 0x00006338 File Offset: 0x00004538
			public static Injector.DllInjector GetInstance
			{
				get
				{
					if (Injector.DllInjector._instance == null)
					{
						Injector.DllInjector._instance = new Injector.DllInjector();
					}
					return Injector.DllInjector._instance;
				}
			}

			// Token: 0x06000065 RID: 101 RVA: 0x00002A34 File Offset: 0x00000C34
			private DllInjector()
			{
			}

			// Token: 0x06000066 RID: 102 RVA: 0x00006354 File Offset: 0x00004554
			public Injector.DllInjectionResult Inject(string sProcName, string sDllPath)
			{
				Injector.DllInjectionResult dllInjectionResult;
				if (!File.Exists(sDllPath))
				{
					dllInjectionResult = Injector.DllInjectionResult.DllNotFound;
				}
				else
				{
					uint num = 0U;
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						if (processes[i].ProcessName == sProcName)
						{
							num = (uint)processes[i].Id;
							break;
						}
					}
					if (num == 0U)
					{
						dllInjectionResult = Injector.DllInjectionResult.GameProcessNotFound;
					}
					else if (!this.bInject(num, sDllPath))
					{
						dllInjectionResult = Injector.DllInjectionResult.InjectionFailed;
					}
					else
					{
						dllInjectionResult = Injector.DllInjectionResult.Success;
					}
				}
				return dllInjectionResult;
			}

			// Token: 0x06000067 RID: 103 RVA: 0x000063C0 File Offset: 0x000045C0
			public Injector.DllInjectionResult ScanAndInject(string processName, string searchString, string dllPath)
			{
				Injector.DllInjectionResult dllInjectionResult;
				if (!File.Exists(dllPath))
				{
					dllInjectionResult = Injector.DllInjectionResult.DllNotFound;
				}
				else
				{
					foreach (Process process in Process.GetProcessesByName(processName))
					{
						try
						{
							ProcessModule mainModule = process.MainModule;
							if ((((mainModule != null) ? mainModule.FileName : null) ?? "").Contains(searchString))
							{
								if (this.bInject((uint)process.Id, dllPath))
								{
									return Injector.DllInjectionResult.Success;
								}
								return Injector.DllInjectionResult.InjectionFailed;
							}
						}
						catch
						{
						}
					}
					dllInjectionResult = Injector.DllInjectionResult.GameProcessNotFound;
				}
				return dllInjectionResult;
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00006450 File Offset: 0x00004650
			private bool bInject(uint pToBeInjected, string sDllPath)
			{
				IntPtr intPtr = Injector.DllInjector.OpenProcess(1082U, 1, pToBeInjected);
				bool flag;
				if (intPtr == Injector.DllInjector.INTPTR_ZERO)
				{
					flag = false;
				}
				else
				{
					if (this.IsProcess64Bit(intPtr))
					{
						flag = this.InjectX64LoadLibrary(intPtr, sDllPath);
					}
					else
					{
						flag = this.InjectX86LdrLoadDll(intPtr, sDllPath);
					}
					Injector.DllInjector.CloseHandle(intPtr);
				}
				return flag;
			}

			// Token: 0x06000069 RID: 105 RVA: 0x000064A0 File Offset: 0x000046A0
			private bool InjectX64LoadLibrary(IntPtr hndProc, string sDllPath)
			{
				IntPtr procAddress = Injector.DllInjector.GetProcAddress(Injector.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				if (procAddress == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				byte[] bytes = Encoding.ASCII.GetBytes(sDllPath + "\0");
				IntPtr intPtr = Injector.DllInjector.VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)bytes.Length, 12288U, 64U);
				return !(intPtr == Injector.DllInjector.INTPTR_ZERO) && Injector.DllInjector.WriteProcessMemory(hndProc, intPtr, bytes, (uint)bytes.Length, 0) != 0 && !(Injector.DllInjector.CreateRemoteThread(hndProc, (IntPtr)null, Injector.DllInjector.INTPTR_ZERO, procAddress, intPtr, 0U, (IntPtr)null) == Injector.DllInjector.INTPTR_ZERO);
			}

			// Token: 0x0600006A RID: 106 RVA: 0x00006554 File Offset: 0x00004754
			private bool InjectX86LdrLoadDll(IntPtr hndProc, string sDllPath)
			{
				IntPtr procAddress = Injector.DllInjector.GetProcAddress(Injector.DllInjector.GetModuleHandle("ntdll.dll"), "LdrLoadDll");
				if (procAddress == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				byte[] bytes = Encoding.Unicode.GetBytes(sDllPath + "\0");
				IntPtr intPtr = Injector.DllInjector.VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)bytes.Length, 12288U, 64U);
				if (intPtr == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				if (Injector.DllInjector.WriteProcessMemory(hndProc, intPtr, bytes, (uint)bytes.Length, 0) == 0)
				{
					return false;
				}
				int num = 12;
				IntPtr intPtr2 = Injector.DllInjector.VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)num, 12288U, 64U);
				if (intPtr2 == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				ushort num2 = (ushort)(sDllPath.Length * 2);
				ushort num3 = (ushort)(sDllPath.Length * 2 + 2);
				byte[] array = new byte[num];
				Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, array, 0, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num3), 0, array, 2, 2);
				Buffer.BlockCopy(BitConverter.GetBytes((uint)(int)intPtr), 0, array, 4, 4);
				if (Injector.DllInjector.WriteProcessMemory(hndProc, intPtr2, array, (uint)num, 0) == 0)
				{
					return false;
				}
				byte[] array2 = Injector.DllInjector.GenerateLdrLoadDllStubX86(procAddress, intPtr2);
				IntPtr intPtr3 = Injector.DllInjector.VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)array2.Length, 12288U, 64U);
				return !(intPtr3 == Injector.DllInjector.INTPTR_ZERO) && Injector.DllInjector.WriteProcessMemory(hndProc, intPtr3, array2, (uint)array2.Length, 0) != 0 && !(Injector.DllInjector.CreateRemoteThread(hndProc, (IntPtr)null, Injector.DllInjector.INTPTR_ZERO, intPtr3, (IntPtr)null, 0U, (IntPtr)null) == Injector.DllInjector.INTPTR_ZERO);
			}

			// Token: 0x0600006B RID: 107 RVA: 0x000066F0 File Offset: 0x000048F0
			private bool IsProcess64Bit(IntPtr hProcess)
			{
				if (!Environment.Is64BitOperatingSystem)
				{
					return false;
				}
				bool flag = false;
				return Injector.DllInjector.IsWow64Process(hProcess, out flag) && !flag;
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00006718 File Offset: 0x00004918
			private static byte[] GenerateLdrLoadDllStubX86(IntPtr lpLdrLoadDll, IntPtr lpUnicodeString)
			{
				List<byte> list = new List<byte>();
				list.Add(85);
				list.AddRange(new byte[] { 139, 236 });
				list.AddRange(new byte[] { 131, 236, 8 });
				list.AddRange(new byte[] { 141, 69, 252 });
				list.Add(80);
				list.Add(184);
				list.AddRange(BitConverter.GetBytes((uint)(int)lpUnicodeString));
				list.Add(80);
				List<byte> list2 = list;
				byte[] array = new byte[2];
				array[0] = 106;
				list2.AddRange(array);
				List<byte> list3 = list;
				byte[] array2 = new byte[2];
				array2[0] = 106;
				list3.AddRange(array2);
				list.Add(184);
				list.AddRange(BitConverter.GetBytes((uint)(int)lpLdrLoadDll));
				list.AddRange(new byte[] { byte.MaxValue, 208 });
				list.AddRange(new byte[] { 139, 229 });
				list.Add(93);
				list.Add(195);
				return list.ToArray();
			}

			// Token: 0x0400004E RID: 78
			private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

			// Token: 0x0400004F RID: 79
			private const uint THREAD_SUSPEND_RESUME = 2U;

			// Token: 0x04000050 RID: 80
			private const uint TH32CS_SNAPTHREAD = 4U;

			// Token: 0x04000051 RID: 81
			private static Injector.DllInjector _instance;

			// Token: 0x02000015 RID: 21
			private struct THREADENTRY32
			{
				// Token: 0x04000057 RID: 87
				public uint dwSize;

				// Token: 0x04000058 RID: 88
				public uint cntUsage;

				// Token: 0x04000059 RID: 89
				public uint th32ThreadID;

				// Token: 0x0400005A RID: 90
				public uint th32OwnerProcessID;

				// Token: 0x0400005B RID: 91
				public int tpBasePri;

				// Token: 0x0400005C RID: 92
				public int tpDeltaPri;

				// Token: 0x0400005D RID: 93
				public uint dwFlags;
			}
		}
	}
}
