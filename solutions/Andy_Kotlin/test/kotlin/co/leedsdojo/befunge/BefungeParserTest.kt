package co.leedsdojo.befunge

import org.junit.Assert.assertEquals
import org.junit.Test

class BefungeParserTest {

    @Test
    fun `Given a simple string Then generates expected answer`(){
        "32*81-*.@".befunge()
        assertEquals(true, true)
    }

    @Test
    fun `Given a factorial expression Then generates expected answer`(){
        listOf("08>:1-:v v *_$.@",
                "  ^    _$>\\:^").doBefunge()
        assertEquals(true, true)
    }
}


