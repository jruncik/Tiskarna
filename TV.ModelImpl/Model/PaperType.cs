using System;
using System.Drawing;
using TV.Model;

namespace TV.ModelImpl.Model
{
    public class PaperType : IPaperType
    {
        public Guid Id { get; set; }
        public Color Color { get; set; }
        public string Type { get; set; }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}