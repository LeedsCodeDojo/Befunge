package co.leedsdojo.befunge

import java.util.*

fun CharSequence.befunge() {
    return listOf(this.toList()).befunge()
}

fun List<List<Char>>.befunge() {
    var state = BefungeState(this)

    while (!state.finished) {
        state = state.next()
    }

}

enum class Direction(val dx: Int, val dy: Int) {
    RIGHT(1, 0), LEFT(-1, 0), UP(0, -1), DOWN(0, 1)
}

typealias Position = Pair<Int, Int>

operator fun Position.plus(dir: Direction) = Position(this.first + dir.dx, this.second + dir.dy)

data class BefungeState(private val instructions: List<List<Char>>,
                        private val stack: Stack<Int> = Stack(),
                        private val position: Pair<Int, Int> = Position(0, 0),
                        private val direction: Direction = Direction.RIGHT,
                        private val withinQuotes: Boolean = false,
                        val finished: Boolean = false) {

    fun next(): BefungeState {
        val currentChar = instructions[position.second][position.first]
        return if (withinQuotes) {
            when(currentChar){
                '"' -> this.copy(withinQuotes=false, position = position+direction)
                else -> {
                    stack.push(currentChar.toInt())
                    this.copy(position = position + direction)
                }
            }
        } else when (currentChar) {
            in ('0'..'9') -> {
                stack.push(currentChar.toString().toInt())
                this.copy(position = position + direction)
            }
            '"' -> this.copy(withinQuotes = true, position = position + direction)
            '>' -> {
                val newDirection = Direction.RIGHT
                this.copy(direction = newDirection, position = position + newDirection)
            }
            '<' -> {
                val newDirection = Direction.LEFT
                this.copy(direction = newDirection, position = position + newDirection)
            }
            '^' -> {
                val newDirection = Direction.UP
                this.copy(direction = newDirection, position = position + newDirection)
            }
            'v' -> {
                val newDirection = Direction.DOWN
                this.copy(direction = newDirection, position = position + newDirection)
            }
            '+' -> {
                val a = stack.pop()
                val b = stack.pop()
                stack.push(a + b)
                this.copy(position = position + direction)
            }
            '-' -> {
                val a = stack.pop()
                val b = stack.pop()
                stack.push(b-a)
                this.copy(position = position + direction)
            }
            '*' -> {
                val a = stack.pop()
                val b = stack.pop()
                stack.push(b * a)
                this.copy(position = position + direction)
            }
            '/' -> {
                val a = stack.pop()
                val b = stack.pop()
                stack.push(b / a)
                this.copy(position = position + direction)
            }
            ':' -> { // Duplicate top item on stack
                stack.push(stack.peek())
                this.copy(position = position + direction)
            }
            '!' -> { //
                val a = stack.pop()
                stack.push(if (a==0) 1 else 0)
                this.copy(position = position + direction)
            }
            '\\' -> { // Swap top to characters
                val a = stack.pop()
                val b = stack.pop()
                stack.push(a)
                stack.push(b)
                this.copy(position = position + direction)
            }
            '.' -> { // Print top integer
                val a = stack.pop()
                print("$a ")
                this.copy(position = position + direction)
            }
            ',' -> { // Print top element
                val a = stack.pop().toChar()
                print("$a")
                this.copy(position = position + direction)
            }
            '_' -> {
                val a = stack.pop()
                val newDirection = if (a==0) Direction.LEFT else Direction.RIGHT
                this.copy(direction =  newDirection, position = position + newDirection)
            }
            '|' -> {
                val a = stack.pop()
                val newDirection = if (a==0) Direction.UP else Direction.DOWN
                this.copy(direction =  newDirection, position = position + newDirection)
            }
            '#' -> { // Bridge Character
                this.copy( position = position + direction + direction)
            }
            '@' -> this.copy(finished = true)
            else -> throw IllegalArgumentException("Unexpected Character in Bagging Area: '$currentChar'")
        }
    }
}

