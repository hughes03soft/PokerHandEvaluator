# PokerHandEvaluator
 Poker Hand Evaluator

Assumptions:
1. 5 card standard poker rules ((https://www.contrib.andrew.cmu.edu/~gc00/reviews/pokerrules)
1.1. no wild cards
1.2. suite is irrelevant to hand rank
2. Assumes input is always correct e.g. set of cards and no duplicates
3. Aside from rank, the evaluator will also identify the hand rank names
4. Since requirement is to impliment 5+ or more poker hands, I'm assuming the design should:
4.1. focus more on making it easy to add new poker hands (as classes) with the least possible risk
4.2. don't focus on optimizing runtime speed (still try to not write slow code if possible)
5. Try to avoid copying poker evaluators online as much as possible
