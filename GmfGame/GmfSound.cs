using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;
using System.IO;

namespace GmfGame
{
    public class GmfSound
    {
        public static void Play(int index)
        {
            if (index < 0 || index >= sounds.Length)
                return;

            FMOD.Channel channel = null;
            sys.playSound(FMOD.CHANNELINDEX.FREE, sounds[index], false, ref channel);
        }

        /// <summary>
        /// volume은 0 ~ 1
        /// </summary>
        public static void Play(int index, float volume)
        {
            FMOD.Channel channel = null;
            sys.playSound(FMOD.CHANNELINDEX.FREE, sounds[index], true, ref channel);
            channel.setVolume(volume);
            channel.setPaused(false);
        }

        static FMOD.Sound[] sounds = new FMOD.Sound[7];
        static FMOD.System sys;

        static GmfSound()
        {
            sys = new FMOD.System();
            FMOD.Factory.System_Create(ref sys);
            sys.init(64, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);

            for (int i = 0; i < sounds.Length; ++i)
                sys.createStream(string.Format("Sound/{0}.wav", i), FMOD.MODE.DEFAULT, ref sounds[i]);
        }
    }
}
