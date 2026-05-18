using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace synapsesex
{
	// Token: 0x0200000A RID: 10
	internal static class SXREInjector
	{
		// Token: 0x06000042 RID: 66
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000043 RID: 67
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

		// Token: 0x06000044 RID: 68
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x06000045 RID: 69
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x06000046 RID: 70
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x06000047 RID: 71
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000048 RID: 72
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x06000049 RID: 73
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x0600004A RID: 74
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr LoadLibraryA(string lpLibFileName);

		// Token: 0x0600004B RID: 75 RVA: 0x00006124 File Offset: 0x00004324
		public static bool Inject(int pid, string dllPath, out string error)
		{
			error = null;
			if (!File.Exists(dllPath))
			{
				error = "DLL not found: " + dllPath;
				return false;
			}
			IntPtr intPtr = SXREInjector.OpenProcess(2035711U, false, pid);
			if (intPtr == IntPtr.Zero)
			{
				error = "Failed to open process. Error: " + Marshal.GetLastWin32Error().ToString();
				return false;
			}
			byte[] bytes = Encoding.ASCII.GetBytes(dllPath + "\0");
			IntPtr intPtr2 = SXREInjector.VirtualAllocEx(intPtr, IntPtr.Zero, (uint)bytes.Length, 12288U, 4U);
			if (intPtr2 == IntPtr.Zero)
			{
				error = "Failed to allocate memory in target process. Error: " + Marshal.GetLastWin32Error().ToString();
				SXREInjector.CloseHandle(intPtr);
				return false;
			}
			IntPtr intPtr3;
			if (!SXREInjector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, out intPtr3))
			{
				error = "Failed to write memory in target process. Error: " + Marshal.GetLastWin32Error().ToString();
				SXREInjector.CloseHandle(intPtr);
				return false;
			}
			IntPtr procAddress = SXREInjector.GetProcAddress(SXREInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (procAddress == IntPtr.Zero)
			{
				error = "Failed to get LoadLibraryA address. Error: " + Marshal.GetLastWin32Error().ToString();
				SXREInjector.CloseHandle(intPtr);
				return false;
			}
			IntPtr intPtr4 = SXREInjector.CreateRemoteThread(intPtr, IntPtr.Zero, 0U, procAddress, intPtr2, 0U, out intPtr3);
			if (intPtr4 == IntPtr.Zero)
			{
				error = "Failed to create remote thread. Error: " + Marshal.GetLastWin32Error().ToString();
				SXREInjector.CloseHandle(intPtr);
				return false;
			}
			SXREInjector.WaitForSingleObject(intPtr4, 100U);
			SXREInjector.CloseHandle(intPtr4);
			SXREInjector.CloseHandle(intPtr);
			return true;
		}

		// Token: 0x0400003E RID: 62
		private const uint PROCESS_ALL_ACCESS = 2035711U;

		// Token: 0x0400003F RID: 63
		private const uint MEM_COMMIT = 4096U;

		// Token: 0x04000040 RID: 64
		private const uint MEM_RESERVE = 8192U;

		// Token: 0x04000041 RID: 65
		private const uint PAGE_READWRITE = 4U;

		// Token: 0x02000013 RID: 19
		// (Invoke) Token: 0x06000073 RID: 115
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate bool DllMain(IntPtr hinstDLL, uint fdwReason, IntPtr lpvReserved);
	}
}
