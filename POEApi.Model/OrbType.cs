using System.ComponentModel;

namespace POEApi.Model
{
    public enum OrbType
    {
        [Description("Eternal Orb")]
        Eternal,

        [Description("Imprint")]
        Imprint,

        [Description("Exalted Orb")]
        Exalted,

        [Description("Divine Orb")]
        Divine,

        [Description("Gemcutter's Prism")]
        GemCutterPrism,

        [Description("Regal Orb")]
        Regal,

        [Description("Blessed Orb")]
        Blessed,

        [Description("Chaos Orb")]
        Chaos,

        [Description("Orb of Regret")]
        Regret,

        [Description("Cartographer's Chisel")]
        Chisel,

        [Description("Orb of Alchemy")]
        Alchemy,

        [Description("Orb of Scouring")]
        Scouring,

        [Description("Orb of Fusing")]
        Fusing,

        [Description("Orb of Chance")]
        Chance,

        [Description("Chromatic Orb")]
        Chromatic,

        [Description("Jeweller's Orb")]
        JewelersOrb,

        [Description("Orb of Alteration")]
        Alteration,

        [Description("Orb of Augmentation")]
        Augmentation,

        [Description("Orb of Transmutation")]
        Transmutation,

        [Description("Portal Scroll")]
        PortalScroll,

        [Description("Scroll of Wisdom")]
        WisdomScroll,

        [Description("Armourer's Scrap ")]
        ArmourersScrap,

        [Description("Glassblower's Bauble")]
        GlassblowersBauble,

        [Description("Blacksmith's Whetstone")]
        BlacksmithsWhetstone,

        [Description("Scroll Fragment")]
        ScrollFragment,

        [Description("Scroll of Wisdom")]
        ScrollofWisdom,

        [Description("Albino Rhoa Feather")]
        AlbinaRhoaFeather,

        [Description("Alchemy Shard")]
        AlchemyShard,

        [Description("Mirror of Kalandra")]
        Mirror,

        [Description("Vaal Orb")]
        VaalOrb,

        [Description("Perandus Coin")]
        PerandusCoin,

        [Description("Silver Coin")]
        SilverCoin,
        TransmutationShard,
        AlterationShard,
        AncientOrb,
        AncientShard,
        AnnulmentShard,
        BindingShard,
        ChaosShard,
        EngineersOrb,
        EngineersShard,
        ExaltedShard,
        HarbingersOrb,
        HarbingersShard,
        HorizonShard,
        MirrorShard,
        AnnulmentOrb,
        BindingOrb,
        HorizonOrb,
        RegalShard,

        //Must always be last
        [Description("Unknown")]
        Unknown
    }
}
