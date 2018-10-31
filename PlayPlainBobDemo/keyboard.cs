using Bells;
using Commons.Music.Midi;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrintPlainBob
{
    public class Keyboard : IStrikeable, IDisposable
    {
        public int[] NoteMappings { get; set; } = { 0, 2, 4, 5, 7, 9, 11, 12 };

        public int BaseNote { get; set; } = 60;

        private IMidiOutput _midiOutput;

        public Keyboard()
        {
            var access = MidiAccessManager.Default;
            this._midiOutput = access.OpenOutputAsync(access.Outputs.Last().Id).Result;
            this._midiOutput.Send(new byte[] { 0xC0, 112 }, 0, 2, 0); // Midi instrument #40.
        }

        public void Strike(int bellNumber)
        {
            byte note = GetByteCodeForBellNumber(bellNumber);
            Task.Run(() => StrikeNote(note));
        }

        private void StrikeNote(byte note)
        {
            _midiOutput.Send(new byte[] { MidiEvent.NoteOn, note, 0x70 }, 0, 3, 0); // There are constant fields for each MIDI event
            Thread.Sleep(400);
            _midiOutput.Send(new byte[] { MidiEvent.NoteOff, note, 0x70 }, 0, 3, 0);
        }

        private byte GetByteCodeForBellNumber(int bellNumber)
        {
            return (byte)(BaseNote - NoteMappings[bellNumber - 1]);
        }

        public void Dispose()
        {
            for (int i = 1; i <= NoteMappings.Length; i++)
            {
                byte note = GetByteCodeForBellNumber(i);
                _midiOutput.Send(new byte[] { MidiEvent.NoteOff, note, 0x70 }, 0, 3, 0);
            }
            
            _midiOutput.CloseAsync();
        }
    }
}
