# String Calculator

This kata was created by Roy Osherove. [TDD Kata 1](https://osherove.com/tdd-kata-1)

## Guidance

We are practicing *iteration*. The key to this kata is to not "work ahead". Be intentionally ignorant
of the next requirement even if you know what it is. That is what we are practicing here.

**Writing the simplest thing that can make the current test pass**. 

If you have a passing test, and you move on to the next requirement, and the test just passes before you change your code,
you have "failed" this kata. Or at least missed the point. 

## Rules

1. Practice the form of TDD
	- Red: Write a meaningfully failing test that expresses a capability the software needs that it doesn't yet have.
	- Green: Make the test pass. Pretend like you are holding your breath until that test is green again. The faster you can make it pass, the better you are doing. This will require you to frequently write cringe code. Nobody will critique your swimming style as you fight to reach the surface to get your next breath. Just get the test to pass **without any of your previous tests failing**.
	- Refactor: Once you are at the surface, breathing normally, take a deep breath and see if there is a better way to do what you just did. The rule on refactoring though is you cannot add any new functionality. Often you will find that it takes several rounds of red/green before you see some refactoring work to do. No problem. It would be neurotic for you to take out the trash every time you toss a single item in the bin. Let it get a little "stinky" first.

2. Try not to "anticipate" the next move. Just write the code to make the test pass. If you have a passing test, and then you move on to the next requirement, write the test, and it just passes, you missed the point. We are practicing here, which means we are *pretending* we don't know what is coming next, because that is more like the reality of the job of a software developer.

The more code you write *preemptively* in software development, the greater the likelihood that you will interpret all future requirements in terms of your code base as opposed to what is actually needed is. Another way to say this is that we write code that has to be quality, but also there is
value in getting code "out there" as quickly as possible. By getting code shipped we make more money, or reduce our liability in some way, and we get *feedback* on our design and implementation that is helpful for the next iteration.

## Requirements

> Do *not* read through these before beginning. And even if you've done this dozens of times and know what is coming next, pretend like you don't know. 

In this project there is a class called `Calculator` and it has a single public method called `int Add(string numbers)`. This is the *only* allowed public member on this class. Do not add more, and do not change the signature of this method.

> **Note**: You do not have to handle invalid input. Unless you want to. So, don't feel like you have to check for `null`, or other bad input.

The idea is that this method, when given a string, has some rules on how to convert that string into an integer.

1. An empty string returns 0. (note, we already have a failing test for this, make it pass.)
2. A string with a single integer in it is converted to an integer and returned.
	- For example, if you call `Add("2")`, it returns `2`. 
	- Write as many examples of passing integers (Theories?) until you are confident it handles this case correctly.
3. It can take a string with two integers, separated by a comma. So `Add("1,2")` would produce 3.
4. It can take an arbitrary length string, so:
	- `Add("1,2") => 3`
	- `Add("1,2,3") => 6`
	- `Add("1,2,3,4,5,6,7,8,9") => 45`
5. We can "mix" delimeters. Where before you could only separate numbers with a comma, now you can use a newline. (in C#, a newline is represented with the `\n` escape sequence).
	- `Add("1\n2") => 3`
	- `Add("1\n2,3") => 6`
6. Custom delimeters. Users can use any single letter delimeter they'd like, and they indicate it by passing an argument to add in the following form:
	- If they want to use an hash/pound/octothorpe as their delimeter, they would pass:
		- `Add("//#\n1#2#3") => 6`
		- All previous delimeters are still supported, so, for example
		- `Add("//#\n1#2,3\n1") => 7`
7. Negative numbers are not allowed. If any of the numbers are negative, an exception is thrown.
8. The exception should have a message property that has a list of all the negative numbers passed.
9. Numbers bigger than 1000 are just silently ignored.
	- `Add("2,3,9876") => 5`
10. Custom delimeters can be of any length (not just a single character)
	- `Add("//[***]\n1***2") => 3` (note the square brackets around the delimeter)
11. Multiple custom delimeters can be supplied:
	- `Add("//[***, #, !]\n1***2#3\n1!2") => 9`

