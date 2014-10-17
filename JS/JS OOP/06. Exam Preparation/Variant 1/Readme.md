## JS OOP Exam – Variant 1

You must complete the functionality for a TODO list
 * A TODO list has a single container
 * A container can contain only sections
  * Sections can be zero or more
 * A section have a title (string) and only contain items
  * Items can be zero or more
 * Items have content (string)
 * Implement the methods for the types Item, Section and Container
  * You are allowed only to extend the scripts inside the files `'container.js'`, `'item.js'` and `'section.js'`
 * Methods descriptions:
  * `Container.add(section)` adds a section to the container
  * `Container.getData()` returns a JSON array with sections
  * `Section.add(item)` adds an item to the given section
  * `Section.getData()` returns its title and an array with items
  * `Item.getData()` returns the content of the item
 * Your are given a few files, **that must not be changed**