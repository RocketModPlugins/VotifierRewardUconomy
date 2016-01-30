using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.VotifierRewardUconomy
{
    public class VotifierRewardUconomyConfiguration : IRocketPluginConfiguration
    {
        public decimal RewardAmount;

        public void LoadDefaults()
        {
            RewardAmount = 30;
        }
    }
}
