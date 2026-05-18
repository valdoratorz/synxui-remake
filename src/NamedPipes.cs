using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace synapsesex
{
	// Token: 0x02000007 RID: 7
	internal class NamedPipes
	{
		// Token: 0x0600002C RID: 44
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);

        // Token: 0x0600002D RID: 45 RVA: 0x00005574 File Offset: 0x00003774
        public static bool NamedPipeExist(string pipeName)
        {
            try
            {
                if (!NamedPipes.WaitNamedPipe("\\\\.\\pipe\\" + pipeName, 0))
                {
                    int lastWin32Error = Marshal.GetLastWin32Error();
                    if (lastWin32Error == 0 || lastWin32Error == 2)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Token: 0x0600002E RID: 46 RVA: 0x000055D0 File Offset: 0x000037D0
        public static void LuaPipe(string script)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
			{
                new Thread((ThreadStart)delegate
                {
					try
					{
						using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", NamedPipes.luapipename, PipeDirection.Out))
						{
							namedPipeClientStream.Connect();
							using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999))
							{
								streamWriter.Write(script);
								streamWriter.Flush();
							}
						}
					}
					catch (IOException)
					{
					}
					catch (Exception)
					{
					}
				}).Start();
			}
		}

		// Token: 0x0400002F RID: 47
		public static readonly string luapipename = "AustibloxWillGoDownWithASadStatueOfLibertyAndAGenerationThatDidntAgree";
	}
}
