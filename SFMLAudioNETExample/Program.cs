using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace SFMLAudioNETExample
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr sfMusic_createFromFile(string Filename);

		// Token: 0x06000002 RID: 2
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr sfMusic_createFromStream(IntPtr stream);

		// Token: 0x06000003 RID: 3
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr sfMusic_createFromMemory(IntPtr data, UIntPtr size);

		// Token: 0x06000004 RID: 4
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void sfMusic_destroy(IntPtr MusicStream);

		// Token: 0x06000005 RID: 5
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void sfMusic_play(IntPtr Music);

		// Token: 0x06000006 RID: 6
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void sfMusic_pause(IntPtr Music);

		// Token: 0x06000007 RID: 7
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void sfMusic_stop(IntPtr Music);

		// Token: 0x06000008 RID: 8
		[SuppressUnmanagedCodeSecurity]
		[DllImport("csfml-audio-2.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void sfMusic_setLoop(IntPtr Music, bool Loop);

		// Token: 0x06000009 RID: 9 RVA: 0x00002048 File Offset: 0x00000248
		private static void Main(string[] args)
		{
			Console.Title = "SFMLAudioNETExample by RiritoXXL";
			IntPtr music = Program.sfMusic_createFromFile("ODDNUMBER.mp3");
			if (music.ToInt64() == 0L)
			{
				Console.WriteLine("Not Founded Music(ODDNUMBER.mp3");
				return;
			}
			Program.sfMusic_setLoop(music, true);
			Program.sfMusic_play(music);
			for (;;)
			{
				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.M)
				{
					Program.sfMusic_stop(music);
					Environment.Exit(122);
				}
				Thread.Sleep(200);
			}
		}

		// Token: 0x04000001 RID: 1
		public const string SFMLAud_Version2 = "csfml-audio-2.dll";
	}
}
