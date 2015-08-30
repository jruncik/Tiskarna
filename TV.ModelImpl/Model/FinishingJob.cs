namespace TV.ModelImpl.Model
{
    public class FinishingJob
    {
        /// <summary> Cislovani </summary>
        public bool Numbering { get; set; }

        /// <summary> Falcovani </summary>
        public bool Foldding { get; set; }

        /// <summary> Perforace </summary>
        public bool Perforation { get; set; }

        /// <summary> Vysek </summary>
        public bool Cut { get; set; }

        /// <summary> Bigovani </summary>
        public bool Bigovani { get; set; }

        /// <summary> Snaseni </summary>
        public bool Assembling { get; set; }

        /// <summary> Lepeni </summary>
        public bool Gluing { get; set; }

        /// <summary> Siti </summary>
        public bool Needling { get; set; }

        /// <summary> Saminace </summary>
        public bool Lamination { get; set; }

        /// <summary> cislovani </summary>
        public string Other { get; set; }
    }
}