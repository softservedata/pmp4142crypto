package edu.lnu.crypto;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class VizierCipherTest {
    private VizierCipher vizierCipher;

    @BeforeEach
    public void setUp() {
        vizierCipher = new VizierCipher();
    }

    @ParameterizedTest
    @CsvSource(value = {
            "Lorem Ipsum, abcd",
            "ABC abc def DEF, qwerty",
            "qwerty, zx",
            "test text, abc"
    })
    public void shouldEncryptAndDecryptCorrectly(String text, String key) {
        String encryptedText = vizierCipher.encrypt(text, key);
        System.out.println(encryptedText);
        assertEquals(text, vizierCipher.decrypt(encryptedText, key));
    }

}
