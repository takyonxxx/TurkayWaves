using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
namespace TurkayWaves
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll", EntryPoint = "PlaySound", SetLastError = true)]
        private extern static int PlaySound(byte[] wavData, IntPtr hModule, PlaySoundFlags flags);

        //#define SND_SYNC            0x0000  /* play synchronously (default) */
        //#define SND_ASYNC           0x0001  /* play asynchronously */
        //#define SND_NODEFAULT       0x0002  /* silence (!default) if sound not found */
        //#define SND_MEMORY          0x0004  /* pszSound points to a memory file */
        //#define SND_LOOP            0x0008  /* loop the sound until next sndPlaySound */
        //#define SND_NOSTOP          0x0010  /* don't stop any currently playing sound */

        //#define SND_NOWAIT      0x00002000L /* don't wait if the driver is busy */
        //#define SND_ALIAS       0x00010000L /* name is a registry alias */
        //#define SND_ALIAS_ID    0x00110000L /* alias is a predefined ID */
        //#define SND_FILENAME    0x00020000L /* name is file name */
        //#define SND_RESOURCE    0x00040004L /* name is resource name or atom */

        enum PlaySoundFlags
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_MEMORY = 0x0004
        }

        // Play a wav file appearing in a byte array
        static void PlayWav(byte[] wav)
        {
            PlaySound(wav, System.IntPtr.Zero, PlaySoundFlags.SND_MEMORY | PlaySoundFlags.SND_SYNC);
        }
        static byte[] ConvertSamplesToWavFileFormat(short[] left, short[] right, int sampleRate)
        {
            Debug.Assert(left.Length == right.Length);

            const int channelCount = 2;
            int sampleSize = sizeof(short) * channelCount * left.Length;
            int totalSize = 12 + 24 + 8 + sampleSize;

            byte[] wav = new byte[totalSize];
            int b = 0;

            // RIFF header
            wav[b++] = (byte)'R';
            wav[b++] = (byte)'I';
            wav[b++] = (byte)'F';
            wav[b++] = (byte)'F';
            int chunkSize = totalSize - 8;
            wav[b++] = (byte)(chunkSize & 0xff);
            wav[b++] = (byte)((chunkSize >> 8) & 0xff);
            wav[b++] = (byte)((chunkSize >> 16) & 0xff);
            wav[b++] = (byte)((chunkSize >> 24) & 0xff);
            wav[b++] = (byte)'W';
            wav[b++] = (byte)'A';
            wav[b++] = (byte)'V';
            wav[b++] = (byte)'E';

            // Format header
            wav[b++] = (byte)'f';
            wav[b++] = (byte)'m';
            wav[b++] = (byte)'t';
            wav[b++] = (byte)' ';
            wav[b++] = 16;
            wav[b++] = 0;
            wav[b++] = 0;
            wav[b++] = 0; // Chunk size
            wav[b++] = 1;
            wav[b++] = 0; // Compression code
            wav[b++] = channelCount;
            wav[b++] = 0; // Number of channels
            wav[b++] = (byte)(sampleRate & 0xff);
            wav[b++] = (byte)((sampleRate >> 8) & 0xff);
            wav[b++] = (byte)((sampleRate >> 16) & 0xff);
            wav[b++] = (byte)((sampleRate >> 24) & 0xff);
            int byteRate = sampleRate * channelCount * sizeof(short); // byte rate for all channels
            wav[b++] = (byte)(byteRate & 0xff);
            wav[b++] = (byte)((byteRate >> 8) & 0xff);
            wav[b++] = (byte)((byteRate >> 16) & 0xff);
            wav[b++] = (byte)((byteRate >> 24) & 0xff);
            wav[b++] = channelCount * sizeof(short);
            wav[b++] = 0; // Block align (bytes per sample)
            wav[b++] = sizeof(short) * 8;
            wav[b++] = 0; // Bits per sample

            // Data chunk header
            wav[b++] = (byte)'d';
            wav[b++] = (byte)'a';
            wav[b++] = (byte)'t';
            wav[b++] = (byte)'a';
            wav[b++] = (byte)(sampleSize & 0xff);
            wav[b++] = (byte)((sampleSize >> 8) & 0xff);
            wav[b++] = (byte)((sampleSize >> 16) & 0xff);
            wav[b++] = (byte)((sampleSize >> 24) & 0xff);

            Debug.Assert(b == 44);

            for (int s = 0; s != left.Length; ++s)
            {
                wav[b++] = (byte)(left[s] & 0xff);
                wav[b++] = (byte)(((ushort)left[s] >> 8) & 0xff);
                wav[b++] = (byte)(right[s] & 0xff);
                wav[b++] = (byte)(((ushort)right[s] >> 8) & 0xff);

            }

            Debug.Assert(b == totalSize);

            return wav;
        }

        // Create a simple sine wave
        public void CreateSamples(out short[] left, out short[] right, int sampleRate,int time)
        {
            //const double middleC = 261.626;
            int count = sampleRate * time; // Two seconds
            left = new short[count];
            right = new short[count];

            for (int i = 0; i != count; ++i)
            {
               
                double t = (double)i / sampleRate; // Time of this sample in seconds
                short s = (short)Math.Floor(Math.Sin(t * 2 * Math.PI * hScrollfreq.Value) * short.MaxValue);
                left[i] = s;
                right[i] = s;
               
            }           
           
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelfrq.Text = hScrollfreq.Value.ToString() + "Hz";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short[] left;
            short[] right;
            int sampleRate = 44100;
            button1.Enabled = false;
            labelfrq.Text = "playing";
            Application.DoEvents();
            CreateSamples(out left, out right, sampleRate,Convert.ToInt16(playtime.Text));
            byte[] wav = ConvertSamplesToWavFileFormat(left, right, sampleRate);
            PlayWav(wav);
            labelfrq.Text = hScrollfreq.Value.ToString() + "Hz";
            button1.Enabled = true;
            Application.DoEvents();
           
            /*
            // Write the data to a wav file
            using (FileStream fs = new FileStream(@"C:\documents and settings\carlos\desktop\a440stereo.wav", FileMode.Create))
            {
                fs.Write(wav, 0, wav.Length);
            }
            */
        }

        private void hScrollfreq_Scroll(object sender, ScrollEventArgs e)
        {
            labelfrq.Text = hScrollfreq.Value.ToString() + "Hz";
        }
    }
}
