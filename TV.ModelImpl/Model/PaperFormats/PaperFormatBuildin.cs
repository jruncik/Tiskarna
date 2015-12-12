using System;
using System.Drawing;
using TV.Core;
using TV.Model;

namespace TV.ModelImpl.Model.PaperFormats
{
    public class PaperFormatBuildin : PaperFormat
    {
        public override string Name
        {
            set { throw new TvException("Buildin format can't be modifies"); }
        }

        public override Size Size
        {
            set { throw new TvException("Buildin format can't be modifies"); }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Reload()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }
}