using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Drug form enumeration
    /// </summary>
    [Serializable]
    public enum FormEnum
    {
        /// <summary>
        /// Application
        /// </summary>
        [ParseableEnum("application", "applications")]
        Application,

        /// <summary>
        /// Buccal
        /// </summary>
        [ParseableEnum("buccal", "buccal")] 
        Buccal,

        /// <summary>
        /// Capsule
        /// </summary>
        [ParseableEnum("capsule", "capsules")] 
        Capsule,
        
        /// <summary>
        /// Cartridge
        /// </summary>
        [ParseableEnum("cartridge", "cartridges")] 
        Cartridge,
        
        /// <summary>
        /// Dose
        /// </summary>
        [ParseableEnum("dose", "doses", true)] 
        Dose,

        /// <summary>
        /// Drop
        /// </summary>
        [ParseableEnum("drop", "drops")] 
        Drop,

        /// <summary>
        /// Elixir
        /// </summary>
        [ParseableEnum("elixir", "elixir")] 
        Elixir,

        /// <summary>
        /// Film
        /// </summary>
        [ParseableEnum("film", "film")] 
        Film,

        /// <summary>
        /// Injectable
        /// </summary>
        [ParseableEnum("injectable", "injectable")]
        Injectable,

        /// <summary>
        /// Injection
        /// </summary>
        [ParseableEnum("injection", "injection")]
        Injection,

        /// <summary>
        /// Liquid
        /// </summary>
        [ParseableEnum("liquid", "liquid")] 
        Liquid,

        /// <summary>
        /// Lollipop
        /// </summary>
        [ParseableEnum("lollipop", "lollipops")]
        Lollipop,

        /// <summary>
        /// Lozenge
        /// </summary>
        [ParseableEnum("lozenge", "lozenges")] 
        Lozenge,

        /// <summary>
        /// Nasal
        /// </summary>
        [ParseableEnum("nasal", "nasal")] 
        Nasal,

        /// <summary>
        /// Oral
        /// </summary>
        [ParseableEnum("oral", "oral")] 
        Oral,

        /// <summary>
        /// Patch
        /// </summary>
        [ParseableEnum("patch", "patches")] 
        Patch,

        /// <summary>
        /// Pill
        /// </summary>
        [ParseableEnum("pill", "pills")] 
        Pill,

        /// <summary>
        /// Puff
        /// </summary>
        [ParseableEnum("puff", "puffs")] 
        Puff,

        /// <summary>
        /// Rectal
        /// </summary>
        [ParseableEnum("rectal", "rectal")] 
        Rectal,

        /// <summary>
        /// Solution
        /// </summary>
        [ParseableEnum("solution", "solution")]
        Solution,

        /// <summary>
        /// Spray
        /// </summary>
        [ParseableEnum("spray", "sprays")] 
        Spray,

        /// <summary>
        /// Sublingual
        /// </summary>
        [ParseableEnum("sublingual", "sublingual")]
        Sublingual,

        /// <summary>
        /// Suppository
        /// </summary>
        [ParseableEnum("suppository", "suppositories")]
        Suppository,

        /// <summary>
        /// Suspension
        /// </summary>
        [ParseableEnum("suspension", "suspension")]
        Suspension,

        /// <summary>
        /// Syringe
        /// </summary>
        [ParseableEnum("syringe", "syringes")] 
        Syringe,

        /// <summary>
        /// Syrup
        /// </summary>
        [ParseableEnum("syrup", "syrup")] 
        Syrup,

        /// <summary>
        /// System
        /// </summary>
        [ParseableEnum("system", "system")] 
        System,

        /// <summary>
        /// Tablet
        /// </summary>
        [ParseableEnum("tablet", "tablets")] 
        Tablet,

        /// <summary>
        /// TDP
        /// </summary>
        [ParseableEnum("tdp", "tdp")] 
        Tdp,

        /// <summary>
        /// Transdermal
        /// </summary>
        [ParseableEnum("transdermal", "transdermal")]
        Transdermal,

        /// <summary>
        /// Troche
        /// </summary>
        [ParseableEnum("troche", "troche")] 
        Troche,
    }
}
