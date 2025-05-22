using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewCard", menuName = "Marmel/Card")]
public class CardData : ScriptableObject
{
    public LocalizedString cardName;
    public LocalizedString cardDescription;

    public Faction faction;
    public int maxHP;
    public int attackPower;
    public int defensePower;
    public CardState currentState;
}

public enum Faction
{
    Choco,
    Marshmallow
}

public enum CardState
{
    FaceUp,
    FaceDown,
    Suppressed
}
