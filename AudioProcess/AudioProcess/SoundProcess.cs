using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcess
{
    class SoundProcess
    {
        public SoundProcess()
        {
        }

        /// <summary>
        /// Increases or descrease the volume of a sound
        /// </summary>
        /// <param name="sound">the sound to change</param>
        /// <param name="volume">the new amplitude multiplier</param>
        public void OnProcessVolume(Sound sound, float volume)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.Samples.Length;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            for (int i = 0; i < n; i++)
            {
                sound.Samples[i] = sound.Samples[i] * volume;

                progress.UpdateProgress( (double)i / n);
            }
        }

        public void OnProcessVolumeRamp(Sound sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.Samples.Length;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Format.Channels;

            for (int i = 0; i < sound.Samples.Length; i += channels, time += 1.0f / sound.Format.SampleRate)
            {
                float ramp;
                if (time < 0.5)
                {
                    ramp = time / 0.5f;
                }
                else
                {
                    ramp = 1;
                }

                for (int c = 0; c < channels; c++)
                    sound.Samples[i + c] = sound.Samples[i + c] * ramp;

                progress.UpdateProgress((double)i / n);
            }
        }

        public void OnProcessVolumeDeRamp(Sound sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.Samples.Length;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Format.Channels;

            float total = (float)sound.Samples.Length;
            float fullTime = (total / ((float)sound.Format.SampleRate)) / 2f;
            float soundLengthFade = (float)(total - ((float)sound.Format.SampleRate) );

            for (int i = 0; i < sound.Samples.Length; i += channels, time += 1.0f / sound.Format.SampleRate)
            {
                float ramp;
                if (time < 0.5)
                {
                    ramp = time / 0.5f;
                }
                else if (i > soundLengthFade)
                {
                    ramp = (fullTime - time) / 0.5f;
                }
                else
                {
                    ramp = 1;
                }

                for (int c = 0; c < channels; c++)
                    sound.Samples[i + c] = sound.Samples[i + c] * ramp;

                progress.UpdateProgress((double)i / n);
            }
        }

        public void OnTremelo(Sound sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.Samples.Length;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Format.Channels;

            float depth = 0.2f;
            float frequency = 4f;

            for (int i = 0; i < sound.Samples.Length; i += channels, time += 1.0f / sound.Format.SampleRate)
            {
                float a = (float)(1f + depth * Math.Sin(frequency * 2 * Math.PI * time));

                for (int c = 0; c < channels; c++)
                    sound.Samples[i + c] = sound.Samples[i + c] * a;

                progress.UpdateProgress((double)i / n);
            }
        }
    }
}
