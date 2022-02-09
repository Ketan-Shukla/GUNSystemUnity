// attachment effect for example 2x 4x scope or accuracy from muzzle or less recoil
public enum ModifierType
{
    Additive, // Adds to the exhisting effect
    Multiplicative, // Mutiplies the existing effect
    Flat // Set it as new effect
}

/*Weapon Attributes:
   */
public enum WeaponAttributes
{
    FireRate, // how many bullets it can fire in x time
    Damage, // how much damage opponent will receive
    Range, // what is the range of weapon
    Mobility, // more it is more time take by player to fire/move around
    Accuracy, // probability of it hitting at precise location where it is aimed
    ReloadTime // Time take to reload
}

/* Magazine: 
    -Quick Reload 
    -Extended
    -Extended Quick reload
*/
public enum AttachmentName
{
    LightMag, // quick reload
    HeavyMag, // more bullets
    FastMag, // more bullets and fast
    Stock, // for shotguns/ sniper rifles
    Suppressor // for pisols
}

// Weapon types
public enum WeaponType
{
    primary,
    secondary
}

// Weapon Firing modes
public enum WeaponFiring
{
    Auto,
    Burst,
    Single
}

// Attachment available to the player
[Flags]
public enum Attachments
{
    Stock = (1<<0),
    Sight= (1<<1),
    Grip = (1<<2),
    Magazine = (1<<3)
}

// Scoped vision / Thermal vision/ normal
[Flags]
public enum SightType
{
    Scoped = (1<<0),
    Normal = (1<<1),
    Thermal = (1<<2),
    RedDot = (1<<3),
}

// Shoot mode selected by player
[Flags]
public enum AvailableShootModes
{
    Normal = (1<<0),
    Burst = (1<<1),
    Single = (1<<2)
}
