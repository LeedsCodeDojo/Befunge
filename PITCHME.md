## To Infinity & Befunge
### Experiments with an Esoteric Language

---
## Introduction
* What is an Esoteric Language?
  * Intended as a challenge/fun rather than a serious language.
  * Designed to be as hard to compile as possible.
---
## Why Befunge?
  * One of the most popular Esoteric languages
  * Easy to get started.
    * Simple syntax
    * Availability of online parsers
  * It's a bit of fun and mental challenge :)
---
##  Befunge Overview
* Befunge programs are written on a 2D Grid.
* Each instruction is a single character.
* Program executes by moving the pointer to the current instruction across the grid.
* Values/Results are `pushed` to a stack and subsequent instructions `pop` these values and apply the operation.

###### NB - The Stack will only contain Integer values (either numbers or ASCII values of characters) 

---
### Maths Instructions

  * `0` -> `9` - Add integer to Stack
  * `+` - Addition: Pop a and b, then push a+b
  * `-` - Subtraction: Pop a and b, then push b-a
  * `*`	- Multiplication: Pop a and b, then push a*b
  * `/`	- Integer division: Pop a and b, then push b/a, rounded towards 0.
  * `%` - Modulo: Pop a and b, then push the remainder of the integer division of b/a.
---
### Stack Manipulation Instructions
  * `:` - Duplicate value on top of the stack
  *  \ - Swap two values on top of the stack
  * `$`	- Pop value from the stack and discard it
  * `.`	- Pop value and output as an integer followed by a space
  * `,`	- Pop value and output as ASCII character
  * `@`	- End of Program
---
### Loops
* Loops are represented by circular paths on the 2D Grid. Implemented by changing the direction that the next instruction is read from.
  * `>` - Start moving RIGHT
  * `<` - Start moving LEFT
  * `^` - Start moving UP
  * `v` - Start moving DOWN
  * `#` - Bridge, jump over next instruction.

* Operation will continue in the new direction until direction is changed again.

---
### Branching/Conditional Statements

  * `!` - Logical NOT: Pop a value. If the value is zero, push 1; otherwise, push zero.
  * `  - Greater than: Pop a and b, then push 1 if b>a, otherwise zero.
  * `_` - Pop a value; move right if value=0, left otherwise
  * `|` - Pop a value; move down if value=0, up otherwise

---
### Handling Strings
Strings can be embedded into the 2D Grid between quotes.
The ASCII value of each character between the quotes is pushed onto the stack.
```
"dlroW olleH">:v
             ^,_@
```
---
### Advanced Statements

  * `p` - Put a value into a grid element 
  * `g` - Get a value from a grid element
  
These commands can be used to:
1. Use grid element(s) as registers/variables
2. Create self-modifying code by overwriting instructions in the grid.

Request input from the user:
 * `&` - Ask user for a number and push it
 * `~` - Ask user for a character and push its ASCII value
  
---
## Build a Befunge Parser

* Use your preferred language to build a Befunge parser.
  * Given a program in a 2D Grid, your parser should navigate through the program & output the result.
  * Start by implementing a `simple` calculator which just reads across a single line & outputs a result.
  * For example, this calculation should give you a result of 42:
  
  ```32*81-*.@``` 

---
## Create Befunge Programs
* Extend your parser to handle loops and conditional statements.
  * Test your parser by creating a Befunge program which counts down from 10 until 1 before printing "Liftoff"
  * Create a Befunge program which calculates `x` to the power of `y` i.e. x=2, y=4 should give a result of 16.  For simplicity x & y are both between 1 & 9.
  * Create a Befunge program which calculates the first 10 Fibonacci numbers.
  * Create a Befunge program which calculates `x` Factorial.
  
######  NB - If possible try & solve the above problems **without** using the `p` & `g` operators to update the Program Grid. 
   

