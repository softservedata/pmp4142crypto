package edu.lnu.crypto;

import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class VizierCipher {
    private static final int ALPHABET_SIZE = 150;
    public String encrypt(String text, String key) {
        var cipherKey = getCipherKey(text, key);
        var chars = IntStream.range(0, text.length())
                .map(i -> (text.charAt(i) + cipherKey.charAt(i)) % ALPHABET_SIZE)
                .toArray();
        return new String(chars, 0, text.length());
    }

    public String decrypt(String encryptedText, String key) {
        var cipherKey = getCipherKey(encryptedText, key);
        var chars = IntStream.range(0, encryptedText.length())
                .map(i -> (encryptedText.charAt(i) - cipherKey.charAt(i) + ALPHABET_SIZE) % ALPHABET_SIZE)
                .toArray();
        return new String(chars, 0, encryptedText.length());
    }

    private String getCipherKey(String text, String key) {
        return IntStream.range(0, text.length() / key.length())
                .mapToObj(i -> key)
                .collect(Collectors.joining())
                .concat(key.substring(0, text.length() % key.length()));
    }
}
