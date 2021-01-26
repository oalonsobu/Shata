using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public abstract class Upgrade
    {
        public abstract List<ResourceModifier> Price { get; }

        public abstract List<ResourceModifier> Modifiers { get; }
        
        public abstract List<Upgrade> Upgrades { get; }
        
        //TODO Move to another class
        public string PriceToString()
        {
            string text = "";
            foreach (var resourceModifier in Price)
            {
                text += resourceModifier.ResourceType.ToString() + ": " + resourceModifier.Amount + "  ";
            }

            if (text == "")
            {
                text = "Price: Free";
            }

            return text;
        }
    }
}