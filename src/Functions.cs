using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace synapsesex
{
	// Token: 0x02000004 RID: 4
	internal class Functions
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000030FC File Offset: 0x000012FC
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
				select s[Functions.Rnd.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00003138 File Offset: 0x00001338
		public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
		{
			foreach (FileInfo fileInfo in new DirectoryInfo(Folder).GetFiles(FileType))
			{
				lsb.Items.Add(fileInfo.Name);
			}
		}

		// Token: 0x04000015 RID: 21
		public static OpenFileDialog OpenFile = new OpenFileDialog
		{
			Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt",
			FilterIndex = 1,
			RestoreDirectory = true,
			Title = "Synapse X - Open File"
		};

		// Token: 0x04000016 RID: 22
		public static OpenFileDialog ExecuteFile = new OpenFileDialog
		{
			Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt",
			FilterIndex = 1,
			RestoreDirectory = true,
			Title = "Synapse X - Execute File"
		};

		// Token: 0x04000017 RID: 23
		public static readonly Random Rnd = new Random();
	}
}
