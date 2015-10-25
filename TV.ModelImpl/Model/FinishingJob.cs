using System;

namespace TV.ModelImpl.Model
{
    public class FinishingJob
    {
        /// <summary> Cislovani </summary>
        public bool Numbering
        {
            get { return _flags == FinishingJobFlag.Numbering; }
            set { SetFlag(value, FinishingJobFlag.Numbering); }
        }

        /// <summary> Falcovani </summary>
        public bool Foldding
        {
            get { return _flags == FinishingJobFlag.Foldding; }
            set { SetFlag(value, FinishingJobFlag.Foldding); }
        }

        /// <summary> Perforace </summary>
        public bool Perforation
        {
            get { return _flags == FinishingJobFlag.Perforation; }
            set { SetFlag(value, FinishingJobFlag.Perforation); }
        }

        /// <summary> Vysek </summary>
        public bool Cut
        {
            get { return _flags == FinishingJobFlag.Cut; }
            set { SetFlag(value, FinishingJobFlag.Cut); }
        }

        /// <summary> Bigovani </summary>
        public bool Bigovani
        {
            get { return _flags == FinishingJobFlag.Bigovani; }
            set { SetFlag(value, FinishingJobFlag.Bigovani); }
        }

        /// <summary> Snaseni </summary>
        public bool Assembling
        {
            get { return _flags == FinishingJobFlag.Assembling; }
            set { SetFlag(value, FinishingJobFlag.Assembling); }
        }

        /// <summary> Lepeni </summary>
        public bool Gluing
        {
            get { return _flags == FinishingJobFlag.Gluing; }
            set { SetFlag(value, FinishingJobFlag.Gluing); }
        }

        /// <summary> Siti </summary>
        public bool Needling
        {
            get { return _flags == FinishingJobFlag.Needling; }
            set { SetFlag(value, FinishingJobFlag.Needling); }
        }

        /// <summary> Saminace </summary>
        public bool Lamination
        {
            get { return _flags == FinishingJobFlag.Lamination; }
            set { SetFlag(value, FinishingJobFlag.Lamination); }
        }

        /// <summary> Jine prace </summary>
        public string Other { get; set; }

        public FinishingJobFlag Flags
        {
            get { return _flags; }
            set { _flags = value; }
        }

        private void SetFlag(bool value, FinishingJobFlag flag)
        {
            if (value)
            {
                _flags |= flag;
            }
            else
            {
                _flags &= ~flag;
            }
        }

        private FinishingJobFlag _flags = FinishingJobFlag.None;
    }
}