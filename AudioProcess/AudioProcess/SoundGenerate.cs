using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcess
{
    public struct SineParams
    {
        public float freq1;
        public float freq2;
        public float sampleRate;
        public float amplitude;
    }
    class SoundGenerate
    {


        private SineParams sineParams;

        public SoundGenerate()
        {
            sineParams.freq1 = 440.0f;
            sineParams.freq2 = 440.0f;
            sineParams.amplitude = 1f;
        }

        public void MakeParamSine()
        {
            Generic_Sine dlg = new Generic_Sine(sineParams);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sineParams = dlg.SineParams;
            }
        }


       


        /// <summary>
        ///      Example procedure that generates a sine wave.
        ///      The sine wave frequency is set by freq1
        ///
        /// </summary>
        /// <param name="sound">The Sound to fill</param>
        public void MakeSine(Sound sound)
        {

            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.Format.SampleRate;
            int channels = sound.Format.Channels;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            int index = 0;
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the value at this frame
                float val = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1));

                //fill all channels with the value
                for (int c = 0; c < channels; c++)
                {
                    sound.Samples[index + c] = val;
                }

                index += channels;

                progress.UpdateProgress(time / duration);
            }
        }

        public void MakeSineAdditive(Sound sound)
        {

            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.Format.SampleRate;
            int channels = sound.Format.Channels;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            int index = 0;
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                float val = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1));
                float val2 = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq2));
                sound.Samples[index] = val;

                //sanity check for stereo
                if (channels == 2)
                {
                    sound.Samples[index + 1] = val2;
                }

                index += channels;

                progress.UpdateProgress(time / duration);
            }
        }

        public void make234(Sound sound)
        {
            int[] harmonics = { 2, 3, 4 };
            MakeHarmonics(sound, harmonics, harmonics);
        }

        public void make357(Sound sound)
        {
            int[] harmonics = { 3, 5, 7 };
            MakeHarmonics(sound, harmonics, harmonics);
        }

        private int[] GetFrequencies(int freq, bool odd)
        {
            int niquist = 22000 / 2;
            int max_harmonic = niquist / freq;
            int arr_len = max_harmonic - 1;
            if (odd)
            {
                arr_len /= 2;
            }

            int[] harmonics = new int[arr_len];

            for (int i = 0; i < arr_len; i++)
            {
                int val = i + 2;
                if (odd)
                {
                    val = i * 2 + 3;
                }
                harmonics[i] = val;
            }
            return harmonics;
        }

        public void makeAllHarmonics(Sound sound)
        {
            int[] harmonics1 = GetFrequencies((int)sineParams.freq1, false);
            int[] harmonics2 = GetFrequencies((int)sineParams.freq2, false);
            MakeHarmonics(sound, harmonics1, harmonics2);
        }

        public void makeOddHarmonics(Sound sound)
        {
            int[] harmonics = { 9 };
            MakeHarmonics(sound, harmonics, harmonics);
        }

        public void MakeHarmonics(Sound sound, int[] harmonics1, int[] harmonics2)
        {

            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.Format.SampleRate;
            int channels = sound.Format.Channels;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            int index = 0;
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                sound.Samples[index] = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1)); ;
                //sanity check for stereo
                if (channels == 2)
                {
                    sound.Samples[index + 1] = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq2));
                }

                foreach (int h in harmonics1)
                {
                    float amplitude = 1f / h;
                    float val = (float)(amplitude * sineParams.amplitude * Math.Sin(time * 2 * Math.PI * h * sineParams.freq1));
                    
                    sound.Samples[index] += val;
                }

                foreach (int h in harmonics2)
                {
                    float amplitude = 1f / h;
                    float val = (float)(amplitude * sineParams.amplitude * Math.Sin(time * 2 * Math.PI * h * sineParams.freq2));
                    //sanity check for stereo
                    if (channels == 2)
                    {
                        sound.Samples[index + 1] += val;
                    }
                }

                index += channels;

                progress.UpdateProgress(time / duration);
            }
        }
    }
}
