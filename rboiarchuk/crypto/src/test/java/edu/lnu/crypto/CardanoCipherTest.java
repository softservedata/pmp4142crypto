package edu.lnu.crypto;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class CardanoCipherTest {

    CardanoCipher cardanoCipher;

    @BeforeEach
    public void setUp() {
        cardanoCipher = new CardanoCipher();
    }

    @ParameterizedTest
    @ValueSource(strings = {
            "Lorem Ipsum", "123456", "qwerty abc", "testSTR"
    })
    public void shouldEncryptAndDecryptCorrectly(String text) {
        String encryptedText = cardanoCipher.encrypt(text);
        System.out.println(encryptedText);
        assertEquals(text, cardanoCipher.decrypt(encryptedText));
    }
}
