using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Record
    {
        private string name;

        private string time;

        public Record(string name, string time)
        {
            Name = name;

            Time = time;
        }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class BinWriterRecord : BinaryWriter
    {
        public BinWriterRecord(Stream bw) : base(bw)
        {

        }

        public void WriteRecord(Record record)
        {
            base.Write(record.Name);
            base.Write(record.Time);
        }
    }

    class BinReaderRecord : BinaryReader
    {
        public BinReaderRecord(Stream br) : base(br)
        {
        }

        public Record ReadRecord()
        {       
            return new Record(base.ReadString(), base.ReadString());
        }
    }
}
