using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;
[CreateAssetMenu(fileName = "Card", menuName = "Card/Normal")]
public class Card : ScriptableObject {
    //Immagine della carta
    public Sprite cardImage;
    public string cardName = "DefaultName"; //Da sostituire in futuro, se si vuole, con int per le traduzioni
    public enum DeckType {
        Deck, Bazaar, Tavern, Crystal
    }
    public DeckType deckType;
    //Rank della carta (Personaggio), le carte basic possono essere messe subito, le carte superior e legendary richiedono una promozione
    public enum Rank {
        basic, superior, legendary
    
    }
    public Rank rank;
    //La carta è tappata/esaurita?
    public bool tapped = false;
    #region Personaggio
    [Header("Personaggio")]
    //Statistiche varie del personaggio
    public int attack = 0;
    public int life = 0;
    public int defense = 0;
    //Attivi dopo un buff
    public int additionalAttack = 0;
    public int additionalLife = 0;
    public int additionalDefense = 0;

    [HideInInspector]
    public int currentAttack, currentLife, currentDefense;

    //Classe del personaggio
    public enum CharacterClass {
        None, Thief, Fighter, Warrior, Archer, Hunter, Ninja, White_Mage, Summoner
    }
    public CharacterClass characterClass;

    //Razza del Personaggio 
    public enum Race {
        None, Human
    }
    public Race race;

    //Attributo del personaggio, fisico o magico
    public enum AttackCharacteristic {
        None, Physical, Magic
    }
    public AttackCharacteristic characterAttribute;

    //Tipo di danno fisico
    public enum PhysicalCaracteristic {
        None, Melee, Range
    }
    public PhysicalCaracteristic physicalCaracteristic;

    //Tipo di danno Magico
    public enum MagicCharacteristic {
        None, WhiteMagic, BlueMagic, BlackMagic, RedMagic, TimeMagic, Summoner
    }
    public MagicCharacteristic magicCharacteristic, secondMagicAttribute;
    //Elemento, da quanto ho capito, un personaggio con un elemeno solo può essere evocato sempre mentre uno che ne ha due, anche simili, deve essere già presente almeno uno con lo stesso elemento in campo
    public enum Elemental {
        Fuoco_1, Ghiaccio_1, Terra_1, Tuono_1, Vento_1,
        Fuoco_2, Ghiaccio_2, Terra_2, Tuono_2, Vento_2
    }
    public Elemental elemental;
    //Effetti all'evocazione
    public enum EffectOnSummon {
        None, drawCardFromDeckOrTavern, guess2, drawCardFromTavern, draw1_foesDiscard1
    }
    public EffectOnSummon effectOnSummon;
    //Effetto continuo, questo tipo di effetto permette l'attivazione di alcune abilità quali "Assalto"
    public enum ContinuousEffect {
        None, Assault
    }
    public ContinuousEffect continuousEffect;
    //Effetto all'uccisione di un nemico
    public enum EffectOnKill {
        None, soulsSlash
    }
    public EffectOnKill effectOnKill;

    //Effetto quando muoio (o sto per morire)
    public enum EffectOnDeath {
        None, guardianSoul
    }
    public EffectOnDeath effectOnDeath;

    //Effetto rilascio, attivo lo spell nella mia colonna per usare questo effetto, si attivano tutti e due
    public enum Release {
        None, def2_tillEndTurn, returnToHand, nullify1Attack, cardFromTavernUnderCrystal_KO
    }
    public Release releaseEffect;

    //Effetto quando un alleato nella stessa colonna va KO, questa carta deve essere messa nella zona "Abilità preparata" (magie/istantanee)
    public enum Ambush {
        None, EnterInGameWhenAlliesDies, cardFromTavernUnderCrystal_Draw1Card
    }
    public Ambush ambushEffect;

    //Effetto quando un personaggio è da solo
    public enum WhileAloneEffect {
        None, atk1, def1, atk1_def1, atk2, def2, atk3
    }
    public WhileAloneEffect whileAloneEffect;

    //Effetto utilizzabile solo dai Superior e dai Legendary, dopo una promozione, la carta, ha i personaggi promossi sotto di sè. Staccane uno per attivare "Fendente dell'anima"
    public enum SoulsSlashEffect {
        None, GuardianSoul, SlowAttack, Untap, Def2_tillTurnEnd
    }
    public SoulsSlashEffect soulsSlashEffect;

    public CharacterClass summonRequisite;

    [Range(0, 2)]
    public int attackSpeedType;
    [Range(0, 2)]
    public int effectSpeedType;
    [Range(0, 2)]
    public int secondaryEffectSpeedType;
    #endregion





    public void OnSummon() {
        switch (effectOnSummon) {
            
        }
    }
    public void OnKill() {
        switch (effectOnKill) {

        }
    }
    public void OnDeath() {
        bool blockDeath = false;
        switch (effectOnDeath) {

        }
        if (blockDeath)
            return;
        //Chiama morte e distruzione della carta
    }
    public void OnAmbush() {
        switch (ambushEffect) {

        }
    }
    public void WhileAlone() {
        switch (whileAloneEffect) {

        }
    }

    public void OnSoulsSlashEffect() {
        switch (soulsSlashEffect) {

        }
    }

    public void MyContinuousEffect() {
        switch (continuousEffect) {

        }
    }
}