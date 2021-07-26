# PromotionEngine
Coding exercise to design a promotion engine

I spent longer than the recommended time on this, as checkins will show. 

In particular, I made a mistake reading the spec and didn't notice that multiple promotions had to be applied at simultaneously - the wording around this
is a little ambiguous, though ultimately the test cases make it clear. If I had taken more of a TDD-driven approach I might have avoided this issue.

When I spotted my mistake I took the safer approach of testing what I had; however, once I'd done that, it was relatively easy to refactor my code to 
accommodate multiple promotions and test the provided scenarios.

I could have gone further and required a collection of promotions to be passed into the Cart constructor, but having over-run already I will leave it where it is.
