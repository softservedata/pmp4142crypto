package edu.lnu.crypto;

import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class CardanoCipher {
    private static final int N = 4;
    private int[] secret = new int[]{2, 5, 0, 8};

    public String encrypt(String text) {
        int textLength = 0;
        var keys = getCipherKeys(secret);
        var initialMatrix = keys.get(0);
        var rotatedMatrix90 = keys.get(90);
        var rotatedMatrix180 = keys.get(180);
        var rotatedMatrix270 = keys.get(270);

        var res = new StringBuilder();
        var encryptedMatrix = new char[N][N];
        while (textLength < text.length()) {
            var initialPair = updateMatrix(encryptedMatrix, initialMatrix, text, textLength);
            textLength = initialPair.getKey();
            encryptedMatrix = initialPair.getValue();

            var rotatedPair90 = updateMatrix(encryptedMatrix, rotatedMatrix90, text, textLength);
            textLength = rotatedPair90.getKey();
            encryptedMatrix = rotatedPair90.getValue();

            var rotatedPair180 = updateMatrix(encryptedMatrix, rotatedMatrix180, text, textLength);
            textLength = rotatedPair180.getKey();
            encryptedMatrix = rotatedPair180.getValue();

            var rotatedPair270 = updateMatrix(encryptedMatrix, rotatedMatrix270, text, textLength);
            textLength = rotatedPair270.getKey();
            encryptedMatrix = rotatedPair270.getValue();

            var finalEncryptedMatrix = encryptedMatrix;
            IntStream.range(0, N).forEach(i ->
                    IntStream.range(0, N).forEach(j -> res.append(finalEncryptedMatrix[i][j])
                    )
            );

        }
        return res.toString();
    }

    public String decrypt(String text) {
        var res = "";
        int textLength = 0;
        char[][] matrixEncrypted = new char[N][N];
        while (textLength < text.length()) {
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    matrixEncrypted[i][j] = text.charAt(textLength);
                    textLength++;
                }
            }
            var keys = getCipherKeys(secret);
            res = updateDecryptedText(matrixEncrypted, keys.get(0), res);
            res = updateDecryptedText(matrixEncrypted, keys.get(90), res);
            res = updateDecryptedText(matrixEncrypted, keys.get(180), res);
            res = updateDecryptedText(matrixEncrypted, keys.get(270), res);
        }
        return res;
    }

    public char[][] rotate90(char[][] a) {
        char[][] arr = new char[N][N];
        for (int i = 0; i < N / 2; i++) {
            for (int j = i; j < N - i - 1; j++) {
                char temp = a[i][j];
                arr[i][j] = a[N - 1 - j][i];
                arr[N - 1 - j][i] = a[N - 1 - i][N - 1 - j];
                arr[N - 1 - i][N - 1 - j] = a[j][N - 1 - i];
                arr[j][N - 1 - i] = temp;
            }
        }
        return arr;
    }

    public Map<Integer, char[][]> getCipherKeys(int[] arr) {
        char[][] initialMatrix = new char[N][N];
        for (int i = 0; i < N; i++) {
            char[] chars = fillWithZeros(Integer.toBinaryString(arr[i]), N).toCharArray();
            System.arraycopy(chars, 0, initialMatrix[i], 0, N);
        }

        var rotatedMatrix90 = rotate90(initialMatrix);
        var rotatedMatrix180 = rotate90(rotatedMatrix90);
        var rotatedMatrix270 = rotate90(rotatedMatrix180);

        return Map.of(
                0, initialMatrix,
                90, rotatedMatrix90,
                180, rotatedMatrix180,
                270, rotatedMatrix270
        );
    }

    public String fillWithZeros(String str, int length) {
        return IntStream.range(0, length - str.length()).mapToObj(i -> "0")
                .collect(Collectors.joining("")).concat(str);
    }

    public Pair<Integer, char[][]> updateMatrix(char[][] matrix, char[][] key, String inputText, int offset) {
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (key[i][j] == '1' && offset < inputText.length()) {
                    matrix[i][j] = inputText.charAt(offset);
                    offset++;
                }
            }
        }
        return new Pair<>(offset, matrix);
    }

    public String updateDecryptedText(char[][] matrix, char[][] key, String resText) {
        StringBuilder resTextBuilder = new StringBuilder(resText);
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (key[i][j] == '1' && matrix[i][j] != '\0') {
                    resTextBuilder.append(matrix[i][j]);
                }
            }
        }
        resText = resTextBuilder.toString();
        return resText;
    }

}