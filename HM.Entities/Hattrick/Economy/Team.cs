using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HM.Entities.Hattrick.Economy
{
    public class Team
    {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public int cashField { get; set; }
        public int expectedCashField { get; set; }
        public SponsorsPopularity sponsorsPopularityField { get; set; }
        public SupportersPopularity supportersPopularityField { get; set; }
        public uint fanClubSizeField { get; set; }
        public uint incomeSpectatorsField { get; set; }
        public uint incomeSponsorsField { get; set; }
        public uint incomeFinancialField { get; set; }
        public uint incomeTemporaryField { get; set; }
        public uint incomeSumField { get; set; }
        public uint costsArenaField { get; set; }
        public uint costsPlayersField { get; set; }
        public uint costsFinancialField { get; set; }
        public uint costsStaffField { get; set; }
        public uint costsTemporaryField { get; set; }
        public uint costsYouthField { get; set; }
        public uint costsSumField { get; set; }
        public int expectedWeeksTotalField { get; set; }
        public uint lastIncomeSpectatorsField { get; set; }
        public uint lastIncomeSponsorsField { get; set; }
        public uint lastIncomeFinancialField { get; set; }
        public uint lastIncomeTemporaryField { get; set; }
        public uint lastIncomeSumField { get; set; }
        public uint lastCostsArenaField { get; set; }
        public uint lastCostsPlayersField { get; set; }
        public uint lastCostsFinancialField { get; set; }
        public uint lastCostsStaffField { get; set; }
        public uint lastCostsTemporaryField { get; set; }
        public uint lastCostsYouthField { get; set; }
        public uint lastCostsSumField { get; set; }
        public int lastWeeksTotalField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team()
        {
            teamIdField = 0;
            teamNameField = string.Empty; ;
            cashField = 0;
            expectedCashField = 0;
            sponsorsPopularityField = new SponsorsPopularity();
            supportersPopularityField = new SupportersPopularity();
            fanClubSizeField = 0;
            incomeSpectatorsField = 0;
            incomeSponsorsField = 0;
            incomeFinancialField = 0;
            incomeTemporaryField = 0;
            incomeSumField = 0;
            costsArenaField = 0;
            costsPlayersField = 0;
            costsFinancialField = 0;
            costsStaffField = 0;
            costsTemporaryField = 0;
            costsYouthField = 0;
            costsSumField = 0;
            expectedWeeksTotalField = 0;
            lastIncomeSpectatorsField = 0;
            lastIncomeSponsorsField = 0;
            lastIncomeFinancialField = 0;
            lastIncomeTemporaryField = 0;
            lastIncomeSumField = 0;
            lastCostsArenaField = 0;
            lastCostsPlayersField = 0;
            lastCostsFinancialField = 0;
            lastCostsStaffField = 0;
            lastCostsTemporaryField = 0;
            lastCostsYouthField = 0;
            lastCostsSumField = 0;
            lastWeeksTotalField = 0;
        }

        #endregion
    }
}
