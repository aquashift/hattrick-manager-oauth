using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Club
{
    public class Specialists
    {
        #region Properties

        public uint keeperTrainersField { get; set; }
        public uint assistantTrainersField { get; set; }
        public uint psychologistsField { get; set; }
        public uint pressSpokesmenField { get; set; }
        public uint economistsField { get; set; }
        public uint physiotherapistsField { get; set; }
        public uint doctorsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Specialists()
        {
            this.keeperTrainersField = 0;
            this.assistantTrainersField = 0;
            this.psychologistsField = 0;
            this.pressSpokesmenField = 0;
            this.economistsField = 0;
            this.physiotherapistsField = 0;
            this.doctorsField = 0;
        }

        #endregion
    }
}
