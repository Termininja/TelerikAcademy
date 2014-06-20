## Test Driven Development

Finish the given "Poker" project by using TDD.

**Task 01.** Write a class `Card` implementing the `ICard` interface. Implement the properties. Write a constructor. Implement the `ToString()` method. Test all cases.

**Task 02.** Write a class `Hand` implementing the `IHand` interface. Implement the properties. Write a constructor. Implement the `ToString()` method. Test all cases.

**Task 03.** Write a class `PokerHandsChecker` (+ tests) and start implementing the `IPokerHandsChecker` interface. Implement the `IsValidHand(IHand)`. A hand is valid when it consists of exactly 5 different cards.

**Task 04.** Implement `IPokerHandsChecker.IsFlush(IHand)` method. Follow the official poker rules from Wikipedia: http://en.wikipedia.org/wiki/List_of_poker_hands

**Task 05.** Implement `IsFourOfAKind(IHand)` method. Did you test all the scenarios?

**Task 06\*.** Implement the other check for poker hands: `IsHighCard(IHand hand)`, `IsOnePair(IHand hand)`, `IsTwoPair(IHand hand)`, `IsThreeOfAKind(IHand hand)`, `IsFullHouse(IHand hand)`, `IsStraight(IHand hand)` and `IsStraightFlush(IHand hand)`. Did you test all the scenarios well?

**Task 07\*.** Implement a card comparison logic for Poker hands (+ tests). `CompareHands(…)` should return `-1`, `0` or `1`.