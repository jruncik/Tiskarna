using System;
using System.Drawing;
using TV.Core;
using TV.Model;

namespace TV.ModelImpl.Model.PaperFormats
{
    public class PaperFormatBuildin : IPaperFormat
    {
        public string Name
        {
            get { return _name; }
            set { throw new TvException("Buildin format can't be modifies"); }
        }

        public Size Size
        {
            get { return _size; }
            set { throw new TvException("Buildin format can't be modifies"); }
        }

        public bool IsBuildIn
        {
            get { return true; }
        }

        public PaperFormatBuildin(string name, int width, int height)
        {
            _name = name;
            _size = new Size(width, height);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}x{2}", Name, Size.Width, Size.Height);
        }

        public void Save()
        {
            throw new InvalidOperationException();
        }

        public void Reload()
        {
            throw new InvalidOperationException();
        }

        private readonly string _name;
        private readonly Size _size;
    }
}