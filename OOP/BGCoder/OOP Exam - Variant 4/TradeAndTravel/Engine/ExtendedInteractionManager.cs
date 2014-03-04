using System;
using System.Linq;
using System.Collections.Generic;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    break;
            }

            base.HandlePersonCommand(commandWords, actor);
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            var location = actor.Location as IGatheringLocation;
            if (location != null)
            {
                var actorInventory = actor.ListInventory();
                foreach (var item in actorInventory)
                {
                    if (item.ItemType == location.RequiredItem)
                    {
                        var producedItem = location.ProduceItem(itemName);
                        this.AddToPerson(actor, producedItem);
                        break;
                    }
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            switch (itemType)
            {
                case "armor":
                    if (actor.ListInventory().Any(m => m.ItemType == ItemType.Iron))
                    {
                        this.AddToPerson(actor, new Armor(itemName));
                    }
                    break;
                case "weapon":
                    if (actor.ListInventory().Any(m => m.ItemType == ItemType.Iron) &&
                        actor.ListInventory().Any(m => m.ItemType == ItemType.Wood))
                    {
                        this.AddToPerson(actor, new Weapon(itemName));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
