using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API.Collections;

namespace fr34kyn01535.VotifierRewardUconomy
{
    public class VotifierRewardUconomy : RocketPlugin<VotifierRewardUconomyConfiguration>
    {
        protected override void Load()
        {
            Votifier.Votifier.Instance.OnPlayerVoted += Instance_OnPlayerVoted;
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    { "votifierrewarduconomy_player_has_voted","Thanks for voting on {0}, you have received {1} and now have {2} in your bank account." }
                };
            }
        }

        private void Instance_OnPlayerVoted(UnturnedPlayer player, Votifier.ServiceDefinition definition)
        {
            string moneyReceived = Configuration.Instance.RewardAmount + Uconomy.Uconomy.Instance.Configuration.Instance.MoneyName;
            string newTotalMoney = Uconomy.Uconomy.Instance.Database.IncreaseBalance(player.Id, Configuration.Instance.RewardAmount) + Uconomy.Uconomy.Instance.Configuration.Instance.MoneyName;

            UnturnedChat.Say(player, Translate("votifierrewarduconomy_player_has_voted", definition.Name, moneyReceived, newTotalMoney));
            Logger.Log(player.DisplayName + " has received " + moneyReceived + " because he voted on " + definition.Name);
        }
    }
}
