package co.leedsdojo.befunge

import org.junit.Test

class BefungeParserTest {

    @Test
    fun `Given a simple string Then generates expected answer`(){
        "32*81-*.@".befunge()
    }

}


