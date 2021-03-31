package edu.lnu.crypto;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class PalisadeCipherTest {
    private PalisadeCipher palisadeCipher;

    @BeforeEach
    public void setUp() {
        palisadeCipher = new PalisadeCipher();
    }


    @ParameterizedTest
    @CsvSource(value = {
            "Lorem Ipsum, 2",
            "123456, 2",
            "qwerty abc, 3",
            "testSTR, 3"
    })
    public void shouldEncryptAndDecryptCorrectly(String text, int height) {
        String encryptedText = palisadeCipher.encrypt(text, height);
        System.out.println(encryptedText);
        assertEquals(text, palisadeCipher.decrypt(encryptedText, height));
    }
}
