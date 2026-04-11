using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;

namespace RpgGame.Core.Items
{
    public interface IItem  // Created an interace for items to allow for more flexible item types and to enable the use of decorators for modifying item properties without changing the underlying item class
    {
        string Name { get; }             // A name for the item, used for display and identification purposes
        char Symbol { get; }            // A character symbol representing the item, used for display in the game world (e.g., on a map or inventory screen)
        bool GoesToInventory { get; }  // A flag indicating whether the item can be picked up and stored in the player's inventory (true) or if it is a static object in the game world (false)
        string GetDescription();      // A method to provide a description of the item, which can be displayed to the player when they examine the item or view it in their inventory
        
        Modifiers.PlayerStatModifier GetStatModifier();                      // A method to return any stat modifiers that the item provides when equipped or used, allowing for dynamic changes to the player's stats based on the items they have
        void OnPickUp(Player player);                                       // A method that is called when the player picks up the item, allowing for any special effects or interactions to occur (e.g., healing the player, triggering a trap, etc.)
        IEnumerable<IInventoryAction> GetInventoryActions(Player player);  // A method to return a list of actions that can be performed with the item when it is in the player's inventory, allowing for context-sensitive actions based on the item type (e.g., equipping a weapon, consuming a potion, etc.)
    }
}
