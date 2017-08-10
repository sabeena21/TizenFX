/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Diagnostics;
using Native = Interop.AudioEffect;

namespace Tizen.Multimedia
{

    /// <summary>
    /// Represents a equalizer band of <see cref="AudioEffect"/>.
    /// </summary>
    public class EqualizerBand
    {
        private readonly AudioEffect _owner;
        private readonly int _index;

        internal EqualizerBand(AudioEffect owner, int index)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            Debug.Assert(owner != null);

            _owner = owner;
            _index = index;

            int frequency = 0;
            int range = 0;

            Native.GetEqualizerBandFrequency(_owner.Player.Handle, _index, out frequency).
                ThrowIfFailed("Failed to initialize equalizer band");

            Native.GetEqualizerBandFrequencyRange(_owner.Player.Handle, _index, out range).
                ThrowIfFailed("Failed to initialize equalizer band");

            Frequency = frequency;
            FrequencyRange = range;
            Log.Debug(PlayerLog.Tag, "frequency : " + frequency + ", range : " + range);
        }

        /// <summary>
        /// Sets or gets the gain for the equalizer band.
        /// </summary>
        /// <param name="value">The value indicating new gain in decibel(dB).</param>
        /// <exception cref="ObjectDisposedException">The player that this EqualizerBand belongs to has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than <see cref="AudioEffect.MinBandLevel"/>.\n
        ///     -or-\n
        ///     <paramref name="value"/> is greater than <see cref="AudioEffect.MaxBandLevel"/>.
        /// </exception>
        public int Level
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                _owner.Player.ValidateNotDisposed();

                int value = 0;
                Native.GetEqualizerBandLevel(_owner.Player.Handle, _index, out value).
                    ThrowIfFailed("Failed to get the level of the equalizer band");
                Log.Info(PlayerLog.Tag, "get level : " + value);
                return value;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                _owner.Player.ValidateNotDisposed();

                if (value < _owner.BandLevelRange.Min || _owner.BandLevelRange.Max < value)
                {
                    Log.Error(PlayerLog.Tag, "invalid level : " + value);
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"valid value range is { nameof(AudioEffect.BandLevelRange) }." +
                        $"but got {value}.");
                }

                Native.SetEqualizerBandLevel(_owner.Player.Handle, _index, value).
                    ThrowIfFailed("Failed to set the level of the equalizer band");
            }
        }


        /// <summary>
        /// Gets the frequency in dB.
        /// </summary>
        public int Frequency { get; }

        /// <summary>
        /// Gets the frequency range in dB.
        /// </summary>
        public int FrequencyRange { get; }

    }
}