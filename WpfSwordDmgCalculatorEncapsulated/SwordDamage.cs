using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WpfSwordDmgCalculatorEncapsulated
{
    class SwordDamage
    {
        /// <summary>
        /// This constructor take an intial 3d6 roll right at the begninning before things kick off. And it also calculates the damage right off the bat.
        /// This calculates damage with default magic and flaming values.
        /// </summary>
        /// <param name="initialRoll"></param>
        public SwordDamage(int initialRoll) 
        {
            roll = initialRoll;
            CalculateDamage();
        }
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        private int roll;
        /// <summary>
        /// This Roll property returns the value of the 3d6 roll. It also calculates the damage
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set { 
                  roll = value;
                  CalculateDamage();
                }
            
        }
        /// <summary>
        /// This auto property returns the value of damage. Its set accessor for updating the damage value is private.
        /// </summary>
        public int Damage { get; private set; }
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic)
            {
                magicMultiplier = 1.75M;
            }
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            Debug.WriteLine($"Rolled {Roll} for damage {Damage}.");
            if (Flaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"Rolled {Roll} for damage {Damage}.");
    }
        private bool magic;
        /// <summary>
        /// Magic property returns if its magic or not (true or false). It also calculates the damage afterwards
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }
        private bool flaming;
        /// <summary>
        /// Flaming property checks the condition if its flaming or not (true or false). It also calculates the damage afterwards.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }
      
    }
}
