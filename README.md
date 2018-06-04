# Befunge

## Introduction
This project is an implementation of the Esoteric Language Befunge for the Leeds Code Dojo meetup group.

Befunge is a stack-based programming language which uses instructions passed in on a 2D array.

## Getting Started
Initially we will consider simple programs as just a list of instructions
(i.e. a 1D line of instructions rather than a 2D array).  
This will allow us to test our Befunge processor and provide quick feed back.

An online Befunge Parser is available at: https://leedscodedojo.github.io/Befunge/


### Simple Operations:
| Symbol |Meaning|
| :-------------: |:-------------|
| 0-9 | Push this number on the stack |
| + | Addition: Pop a and b, then push a+b |
| - | Subtraction: Pop a and b, then push b-a |
| * | Multiplication: Pop a and b, then push a*b |
| / | Integer division: Pop a and b, then push b/a, rounded towards 0. |
| % | Modulo: Pop a and b, then push the remainder of the integer division of a/b. |
| ! | Logical NOT: Pop a value. If the value is zero, push 1; otherwise, push zero. |
| ` | Greater than: Pop a and b, then push 1 if b>a, otherwise zero. |
| : | Duplicate value on top of the stack |
| \ | Swap two values on top of the stack |
| $	| Pop value from the stack and discard it |
| . | Pop value and output as an integer followed by a space |
| , | Pop value and output as ASCII character (no following space) |
| @ | End program |
| ' ' |	No-op. Does nothing |
| " | Start string mode: push each character's ASCII value all the way up to the next " |

## Create Befunge Parser
Time to create our own implementation of a Befunge parser which will take a single line program and calculate an answer.

## Simple Befunge Problems

### Hello World


### Calculator
74%2*81-*.@  Should produce an answer of 42 -> (3*2)*(8-1)



## Advanced Befunging

This is all very well for working with simple, linear programs but 'real' programs need logic with loops & branches.
For that we need to break out of the 1D world into the 2nd dimension.

Actually the program can be more correctly though of as a 3D torus since it wraps both horizontally & vertically.

TODO - Insert image of Torus

### Change Direction / Loops
| Symbol |Meaning|
| :-------------: |:-------------|
| ^ | Change Direction to UP |
| v | Change Direction to DOWN |
| &gt; | Change Direction to RIGHT |
| < | Change Direction to DOWN|
| # | Skip next instruction, can act as a 'bridge'|

### Branching / If Conditions
| Symbol |Meaning|
| :-------------: |:-------------|
| _ | Pop a value; move right if value=0, left otherwise |
| &#124;| Pop a value; move down if value=0, up otherwise |

### Self-Modifying Code
| Symbol |Meaning|
| :-------------: |:-------------|
| g | Get a value from a specific cell & put it on the stack. Pop x & y and then get value of grid(x,y) |
| p | Put the top value on the stack into a specific cell. Pop x, y & n and then set grid(x,y) = n |


## Advanced Problems

### Count down loop
Create a loop which counts down from an initial value. (Bonus marks write "10.9.8.7.6.5.4.3.2.1.Liftoff")

### Math.power - Calculate x to the power y where x & y are the first 2 digits in the program
e.g 23 -> 8, 32 -> 9, 93 -> 729

### Factorial Calculation
Use Befunge to calculate the factorial of a given number (1-9) supplied in 1st position
3! -> 6 (3*2*1)
4! -> 24 (4*3*2*1)
5! -> 120 (5*4*3*2*1)

### Fibonnaci Sequence 
1 1 2 3 5 8 13 21 34 55 89 ... 

(Bonus point, try stopping after 10 numbers rather than getting into infinite loop)

## Useful Links



