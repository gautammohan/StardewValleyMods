using System.Collections.Generic;
using StardewValley;

namespace JsonAssets.Data
{
    public class ObjectRecipe
    {
        public string SkillUnlockName { get; set; } = null;
        public int SkillUnlockLevel { get; set; } = -1;

        public int ResultCount { get; set; } = 1;
        public IList<ObjectIngredient> Ingredients { get; set; } = new List<ObjectIngredient>();

        public bool IsDefault { get; set; } = false;
        public bool CanPurchase { get; set; } = false;
        public int PurchasePrice { get; set; }
        public string PurchaseFrom { get; set; } = "Gus";
        public IList<string> PurchaseRequirements { get; set; } = new List<string>();
        public IList<PurchaseData> AdditionalPurchaseData { get; set; } = new List<PurchaseData>();

        internal string GetRecipeString(ObjectData parent)
        {
            string str = "";
            foreach (var ingredient in this.Ingredients)
                str += Mod.instance.ResolveObjectId(ingredient.Object) + " " + ingredient.Count + " ";
            str = str.Substring(0, str.Length - 1);
            str += $"/what is this for?/{parent.Id} {this.ResultCount}/";
            if (parent.Category != ObjectCategory.Cooking)
                str += "false/";
            if (this.SkillUnlockName?.Length > 0 && this.SkillUnlockLevel > 0)
                str += "/" + this.SkillUnlockName + " " + this.SkillUnlockLevel;
            else
                str += "/null";
            if (LocalizedContentManager.CurrentLanguageCode != LocalizedContentManager.LanguageCode.en)
                str += "/" + parent.LocalizedName();
            return str;
        }
    }
}
